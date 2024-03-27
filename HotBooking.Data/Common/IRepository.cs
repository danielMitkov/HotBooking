using HotBooking.Data.Models;

namespace HotBooking.Data.Common;
public interface IRepository
{
    IQueryable<T> All<T>() where T : BaseEntity;
    IQueryable<T> AllReadOnly<T>() where T : BaseEntity;
    Task AddAsync<T>(T entity) where T : class;
    Task SaveChangesAsync();
    Task<T?> GetByIdAsync<T>(object id) where T : BaseEntity;
    Task<bool> DeleteAsync<T>(object id) where T : BaseEntity;
    Task<bool> DeleteUserAsync<T>(object id) where T : ApplicationUser;
    Task<int> CountAsync<T>(IQueryable<T> query) where T : class;
}
