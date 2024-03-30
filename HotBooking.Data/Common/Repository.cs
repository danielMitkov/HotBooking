using HotBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotBooking.Data.Common;
public class Repository : IDbContext
{
    private readonly HotBookingDbContext dbContext;

    public Repository(HotBookingDbContext context)
    {
        dbContext = context;
    }

    public IQueryable<T> All<T>() where T : BaseEntity
    {
        var query = dbContext
            .Set<T>()
            .Where(t => t.IsActive);

        return query;
    }

    public IQueryable<T> AllReadOnly<T>() where T : BaseEntity
    {
        var query = dbContext
            .Set<T>()
            .Where(t => t.IsActive)
            .AsNoTracking();

        return query;
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await dbContext
            .Set<T>()
            .AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync<T>(object id) where T : BaseEntity
    {
        T? entity = await dbContext
            .Set<T>()
            .FindAsync(id);

        if (entity == null)
        {
            return null;
        }

        if (entity.IsActive)
        {
            return entity;
        }

        return null;
    }

    public async Task<bool> DeleteAsync<T>(object id) where T : BaseEntity
    {
        T? entity = await dbContext
            .Set<T>()
            .FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        if (entity.IsActive == false)
        {
            return false;
        }

        entity.IsActive = false;

        await SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteUserAsync<T>(object id) where T : ApplicationUser
    {
        ApplicationUser? user = await dbContext
            .Set<ApplicationUser>()
            .FindAsync(id);

        if (user == null)
        {
            return false;
        }

        if (user.IsDeleted)
        {
            return false;
        }

        user.UserName = null;
        user.NormalizedUserName = null;
        user.Email = null;
        user.NormalizedEmail = null;
        user.PhoneNumber = null;

        user.IsDeleted = true;

        return true;
    }

    public async Task<int> CountAsync<T>(IQueryable<T> query) where T : class
    {
        int count = await query.CountAsync();

        return count;
    }
}
