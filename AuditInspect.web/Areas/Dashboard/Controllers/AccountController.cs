using AuditInspect.DataAccess.IRepository;
using AuditInspect.Models;
using AuditInspect.Models.FormModels;
using AuditInspect.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtpNet;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuditInspect.web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
   
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<ApplicationUser> userManager,
                                      SignInManager<ApplicationUser> signInManager,
                                      IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }
      
       
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                  
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink, "Confirmare Cont");

                    if (emailResponse)
                        return RedirectToAction("SuccessRegistration", "Email");
                    else
                    {
                      
                    }

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            ViewBag.UserInfo = _userManager.Users;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
         

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);


                if (result.Succeeded)
                {
                    DateTime DateNow = new DateTime() ;
                    DateNow = DateTime.Now.AddSeconds(30);
                    var userInfo = await _userManager.FindByEmailAsync(user.Email);
                    var OtpUser = _unitOfWork.OtpTableInfo.GetAll(x => x.userId == userInfo.Id).LastOrDefault();
                    var OtpToken = _unitOfWork.OtpTableInfo.GetAll(x => x.userId == userInfo.Id).LastOrDefault();
                    var diffInSeconds = (DateNow - OtpToken.StartTime).TotalSeconds;
                    if (diffInSeconds >= 0 && diffInSeconds <= 30 && user.OTPToken == OtpToken.OtpToken)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.UserInfo = _userManager.Users;
                        ModelState.AddModelError(string.Empty, "Otp Invalid");
                    }

                   
                    
                }
                else
                {
                    ViewBag.UserInfo = _userManager.Users;
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt [password]");
                }

                

            }
            return View(user);
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult GenereateOTP(string UserId,DateTime DateTimeStart)
        {

          
            var key = KeyGeneration.GenerateRandomKey(20);
            var totp = new Hotp(key, mode: OtpHashMode.Sha512, hotpSize: 8);

            var OtpG = totp.ComputeHOTP(6);
            OtpTableInfo NewOTPToken = new OtpTableInfo
            {
                StartTime = DateTimeStart,
                userId = UserId,
                OtpToken = OtpG
            };
            _unitOfWork.OtpTableInfo.Add(NewOTPToken);
            _unitOfWork.Save();

            return new JsonResult(new { OtpGenerate = OtpG, DateTimeStart = DateTimeStart });






        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    // Generate the reset password token
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                    // Build the password reset link
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                            new { email = model.Email, token = token }, Request.Scheme);

                    EmailHelper emailHelper = new EmailHelper();
                    bool emailResponse = emailHelper.SendEmail(user.Email, passwordResetLink, "Resetare Parola");
                    // Log the password reset link


                    // Send the user to Forgot Password Confirmation view
                    return View("ForgotPasswordConfirmation");
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return View("ForgotPasswordConfirmation");
            }

            return View(model);
        }





        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("Login");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("Login");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }
    }
}
