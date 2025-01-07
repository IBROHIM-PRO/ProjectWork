using System.ComponentModel.DataAnnotations;

public class Message{
    
    public int Id { get; set; } 

    public string? Name { get; set; }

    public string Matn { get; set; }  

    public DateTime Data { get; set; } = DateTime.Now;
}