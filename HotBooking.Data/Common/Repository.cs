using Microsoft.EntityFrameworkCore;

namespace HotBooking.Data.Common;
public class Repository : IRepository
{
    private readonly HotBookingDbContext dbContext;

    public Repository(HotBookingDbContext context)
    {
        dbContext = context;
    }

    public IQueryable<T> All<T>() where T : class
    {
        return dbContext
            .Set<T>();
    }

    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return dbContext
            .Set<T>()
            .AsNoTracking();
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
}
