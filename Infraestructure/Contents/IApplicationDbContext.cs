using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Contents
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
