﻿using KitsGade.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace KitsGade.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);

                var user = await _userManager.FindByNameAsync(loginVM.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        return Redirect(loginVM.ReturnUrl);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Falha ao realizar o login!");
                return View(loginVM);
            }
        }
    }
}
