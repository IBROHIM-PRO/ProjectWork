using System.Data;
using System.ComponentModel.DataAnnotations;

public class Message{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Required(ErrorMessage="Барои маълумоти паёмро равон кардан бояд маълумот ворид карда шавад.")]
    public string Matn { get; set; }
    public DateTime Sana { get; set; } = DateTime.Now;
}