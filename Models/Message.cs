using System.Data;

public class Message{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Matn { get; set; }
    public DateTime Sana { get; set; } = DateTime.Now;
}