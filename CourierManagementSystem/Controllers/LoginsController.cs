using Microsoft.AspNetCore.Mvc;
using CourierManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using CourierManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CourierManagementSystem.Controllers
{
    public class LoginsController : Controller
    {
        private readonly DataContext _db;
        public LoginsController(DataContext db) 
        { 
            _db = db;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Couriers");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] Login login)
        {
            var user = await _db.Logins.Where(l => l.Email == login.Email && l.Password ==login.Password)
                                       .FirstOrDefaultAsync();
            if(user is not null)
            {
                cookieSetUp(user);
                return RedirectToAction("Index", "Couriers");
            }
            TempData["LoginError"] = "Invalid Credential!";
            return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private async void cookieSetUp(Login login)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, login.Email),
                new Claim(ClaimTypes.Role, login.Role)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));
        }
    }
}
