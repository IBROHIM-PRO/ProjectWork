using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessegeProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller {
    
    private readonly DataContext _context; 

    public AccountController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public IActionResult Register(){
        return View();
    }


    [HttpPost]
    public IActionResult RegisterPost(Account newAccount){
        _context.Accounts.Add(newAccount);
        _context.SaveChanges();

        return RedirectToAction("MessageInfo", "Message");
    }
    [HttpGet]
    public IActionResult Login(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest newLogin){
        var user = _context.Accounts.FirstOrDefault(
            x => x.Name == newLogin.Name && x.Password == newLogin.Password
        );

        if (user is null)  {
            Console.WriteLine("yoft nashud");
            return NotFound();
        }
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Name)
        };
        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

        return RedirectToAction("MessageInfo", "Message");
    }
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("CookieAuth");
        return RedirectToAction("Login", "Account");
    }

}