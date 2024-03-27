﻿using HotBooking.Data.Models;

namespace HotBooking.Data.Common;
public interface IRepository
{
    IQueryable<T> All<T>() where T : BaseEntity;
    IQueryable<T> AllReadOnly<T>() where T : BaseEntity;
    Task AddAsync<T>(T entity) where T : class;
    Task SaveChangesAsync();

    Task<T?> GetByIdAsync<T>(object id) where T : class;

    Task<bool> DeleteAsync<T>(object id) where T : class;
    Task<ICollection<T>> ToICollectionAsync<T>(IQueryable<T> query) where T : class;
    Task<int> CountAsync<T>(IQueryable<T> query) where T : class;
}
