using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.User;

namespace Store.Persistence.Contexts;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
    
}