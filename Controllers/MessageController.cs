using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessegeProject.Models;

public class MessageController : Controller {
    private readonly DataContext _context;
    public MessageController(DataContext context){
        _context = context;
    } 
    
    [HttpGet]
    public IActionResult MessageInfo(){
        return View();
    }

    [HttpGet]
    public IActionResult MessageCreate(){
        var ms = _context.Messages.ToList();

        return View(ms);
    }

    [HttpPost]
    public IActionResult MessagePost(Message newMessage){
        _context.Messages.Add(newMessage);
        _context.SaveChanges();

        return RedirectToAction("MessageCreate", "Message");
    }
}