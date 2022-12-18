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
        string server = "localhost";  // the name of server
        string user = "root"; // user
        string password = "bake0706Dmysql"; // password
        string database = "project_db"; // database
        String con = String.Format("server={0};user={1};password={2};database={3};", server, user, password, database);
        optionsBuilder.UseMySQL(con);
    }
}