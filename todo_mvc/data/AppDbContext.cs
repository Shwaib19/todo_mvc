using Microsoft.EntityFrameworkCore;

namespace todo_mvc.data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
        
    }

    public DbSet<Todo> Todos => Set<Todo>();
    //public DbSet<Student> Students { get; set; }
    

}

