using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace eTicket.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;
        public EntityBaseRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task AddAsync(T entity)
        {
            await appDbContext.Set<T>().AddAsync(entity);
            await appDbContext.SaveChangesAsync();
        }           

        public async Task DeleteAsync(int id)
        {
            var entity = await appDbContext.Set<T>().FirstOrDefaultAsync( e => e.Id == id);
            EntityEntry entityEntry = appDbContext.Entry(entity);
            entityEntry.State = EntityState.Deleted;

            await appDbContext.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(int id) => await appDbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            
        public async Task<IEnumerable<T>> GetAllAsync() => await appDbContext.Set<T>().ToListAsync();            

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = appDbContext.Entry(entity);
            entityEntry.State = EntityState.Modified;

            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProps)
        {
            IQueryable<T> query = appDbContext.Set<T>();
            query = includeProps.Aggregate(query, (current, includeProps) => current.Include(includeProps));
            return await query.ToListAsync();
        }
    }
}
