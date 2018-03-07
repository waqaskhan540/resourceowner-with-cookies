using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Services;

namespace MvcApp.Controllers
{
    public class AccountController:Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Login(model.Username, model.Password);
                if (result.success)
                {

                }
            }
            return null;
        }
    }
}
