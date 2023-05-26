using CRM.API.Interfaces;
using CRM.Data;
using CRM.Domain.ViewModel;
using CRM.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRM.Controllers
{
    public class AccountController : Controller
    {

        DiaryApiStore diary = new DiaryApiStore();
        public IActionResult Login()
        {
            return View();
        }
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel author)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(author);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));

                return RedirectToAction("Index", "Worker");

            }
            return View(author);
        }
    }
}
