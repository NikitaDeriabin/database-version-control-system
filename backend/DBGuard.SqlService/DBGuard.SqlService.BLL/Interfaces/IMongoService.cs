using DBGuard.Core.DAL.Entities.Common;

namespace DBGuard.SqlService.BLL.Interfaces;

public interface IMongoService<T> where T : Entity<int>
{
    Task<ICollection<T>> GetAllAsync();

    Task<T> GetByIdAsync(int entityId);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(int entityId, T editedEntity);

    Task DeleteAsync(int entityId);
}

