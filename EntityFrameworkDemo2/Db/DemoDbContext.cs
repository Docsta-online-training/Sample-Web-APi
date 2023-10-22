using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Db;

public class DemoDbContext : DbContext
{
    
    public DbSet<Student> Students { get; set; }

    public DbSet<Address> Address { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Team> Teams { get; set; }




    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EFDemo2;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=true");
       
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      
    
    }
}

