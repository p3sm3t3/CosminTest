﻿using AuditInspect.Models;
using AuditInspect.Models.FormModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditInspect.web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [AllowAnonymous]
    public class EmailController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        public EmailController(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return View("Error");

            var result = await userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
        [HttpGet]
        public IActionResult SuccessRegistration()
        {
            return View();
        }
    }
}
