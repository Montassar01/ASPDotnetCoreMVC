using Microsoft.EntityFrameworkCore;

namespace ASPDotnetCoreMVC.Models{

    public class DataBaseContext :DbContext
    {
    public DbSet<Employee> Employees{get; set;}
    public DbSet<Company> Companies{get; set;}
    public DataBaseContext(DbContextOptions options):base(options){}
    }
}