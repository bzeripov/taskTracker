namespace project.Context;
using Microsoft.EntityFrameworkCore;
using project.Models;
public class ApplicationContext : DbContext
{
    public DbSet<Project> Projects { get; set;} = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //there should be connection data here
        string server = "[yourserver]";  // the name of server
        string user = "[yourusername]"; // user
        string password = "[yourpassword]"; // password
        string database = "[yourdatabase]"; // database
        String con = String.Format("server={0};user={1};password={2};database={3};", server, user, password, database);
        optionsBuilder.UseMySQL(con);
    }
}