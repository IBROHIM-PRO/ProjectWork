using Microsoft.AspNetCore.Mvc;

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

        return View("MessegeInfo", "MessegePage");
    }
    public IActionResult MessegeInfo(){
        return View();
    }
}