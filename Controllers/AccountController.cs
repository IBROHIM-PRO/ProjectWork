using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessegeProject.Models;

public class AccountController : Controller {
    
    private readonly DataContext _context; 

    public AccountController(DataContext context){
        _context = context;
    }
    [HttpGet]
    public IActionResult Register(){
        return View();
    }
    [HttpGet]
    public IActionResult MessageInfo(){
        return View();
    }
    [HttpPost]
    public IActionResult RegisterPost(Account newAccount){
        _context.Accounts.Add(newAccount);
        _context.SaveChanges();

        return View("MessageInfo", "Home");
    }
    
}