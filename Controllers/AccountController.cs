using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        readonly ShopDbContext context;
        public AccountController(ShopDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await context.Users.FirstOrDefaultAsync(t => t.Login == model.Login && t.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Логин или пароль неверны");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await context.Users.FirstOrDefaultAsync(t => t.Login == model.Login);
                if (user == null)
                {
                    context.Users.Add(new User { Login = model.Login, Email = model.Email, Password = model.Password });
                    await context.SaveChangesAsync();
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Пользователь с таким логином уже существует!");

            }
            return View(model);
        }

        public async Task Authenticate(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username)

            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}