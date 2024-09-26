﻿using Dimchev.DiceRoller.Auth.Core.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Repositories
{
    public class BaseRepository<T>(AuthDbContext dbContext) : IRepository<T> where T : class
    {
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
