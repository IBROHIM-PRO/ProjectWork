using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessegeProject.Models;
using Microsoft.AspNetCore.Authorization;

public class MessageController : Controller {
    private readonly DataContext _context;
    public MessageController(DataContext context){
        _context = context;
    } 

    [HttpGet]
    public IActionResult MessageCreate(){
        var ms = _context.Messages.ToList();

        return View(ms);
    }

    [Authorize]
    
    [HttpGet]
    public IActionResult MessageInfo(){
        return View();
    }
    
    [HttpPost]
    public IActionResult MessagePost(Message newMessage){
        newMessage.Name = User.Identity.Name;
        _context.Messages.Add(newMessage);
        _context.SaveChanges();

        return RedirectToAction("MessageCreate", "Message");
    }
}