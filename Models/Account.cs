using System.ComponentModel.DataAnnotations;


public class Account{
    public int Id { get; set; }
    [Required(ErrorMessage="Воридсозии ном ҳатмист.")]
    public string Name { get; set; }
    [Required(ErrorMessage="Воридсозии рамз ҳатмист.")]
    public string Password { get; set; }
}