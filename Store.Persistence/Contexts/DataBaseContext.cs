using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Attributes;
using Store.Domain.Entities.User;

namespace Store.Persistence.Contexts;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), false).Length > 0)
            {
                builder.Entity(entityType.Name).Property<DateTime?>("CreatedAt");
                builder.Entity(entityType.Name).Property<DateTime?>("UpdatedAt");
                builder.Entity(entityType.Name).Property<bool>("Deleted");
                builder.Entity(entityType.Name).Property<DateTime?>("DeletedAt");
                
            }
        }
        
        
        
        
        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        var modifiedEntries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added 
            || e.State == EntityState.Modified || e.State == EntityState.Deleted);

        foreach (var item in modifiedEntries)
        {
            var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
            if (entityType != null)
            {
                var createdAt = entityType.FindProperty("CreatedAt");  
                var updatedAt = entityType.FindProperty("UpdatedAt");  
                var deleted = entityType.FindProperty("Deleted");  
                var deletedAt = entityType.FindProperty("DeletedAt");

                if (item.State == EntityState.Added && createdAt != null)
                {
                    item.Property("CreatedAt").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified && updatedAt != null)
                {
                    item.Property("UpdatedAt").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Deleted && deleted != null && deletedAt != null)
                {
                    item.Property("Deleted").CurrentValue = DateTime.Now;
                    item.Property("DeletedAt").CurrentValue = true;
                }
                
            }
                           
        }
        return base.SaveChanges();
    }
}