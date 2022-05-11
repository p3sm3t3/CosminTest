using AuditInspect.DataAccess.IRepository;
using AuditInspect.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace AuditInspect.web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            this.roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           
            return View("Index");
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }


      
  
    }
}
