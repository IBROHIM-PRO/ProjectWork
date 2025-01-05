using Microsoft.EntityFrameworkCore;
public class DataContext : DbContext{
    public DataContext(DbContextOptions<DataContext> option) : base (option){}

    public DbSet<Account> Accounts { get; set;}
}