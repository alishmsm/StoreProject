using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.User;

namespace Store.Application.Interfaces.Contexts;

public interface IDataBaseContext
{
    
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    
    

}