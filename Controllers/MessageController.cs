using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MessegeProject.Models;

public class MessageController : Controller {
    private readonly DataContext _context;
    public MessageController(DataContext context){
        _context = context;
    } 
    public IActionResult MessageInfo(){
        var Message = _context.Messages.ToList();
        return View(Message);
    }
    public IActionResult MessagePost(Message newMessage){
        _context.Messages.Add(newMessage);
        _context.SaveChanges();

        return View("MessageInfo", "Home");
    }
}