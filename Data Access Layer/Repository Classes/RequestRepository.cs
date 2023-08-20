using Microsoft.EntityFrameworkCore;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;
using System.Linq.Expressions;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class RequestRepository : GenericRepository<Requestt>, IRequestRepository
    {
        private TrackingContext context;

        public RequestRepository(TrackingContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Requestt> AddAsync(Requestt entity)
        {
            await context.Set<Requestt>().AddAsync(entity);
           // await context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Requestt entity)
        {  
             context.Set<Requestt>().Remove(entity);
        }

        public async Task DeleteManyAsync(Expression<Func<Requestt, bool>> filter)
        {
            var entities = await GetManyAsync(filter);
            context.Set<Requestt>().RemoveRange(entities);
            
        }

        public async Task<IEnumerable<Requestt>> GetAllAsync()
        {
            return await context.Set<Requestt>().ToListAsync();
        }

        public async Task<Requestt> GetByIdAsync(int id)
        {
            return await context.Set<Requestt>().FindAsync(id);
        }

        public async Task<IEnumerable<Requestt>> GetManyAsync(Expression<Func<Requestt, bool>> filter = null,
          Func<IQueryable<Requestt>, IOrderedQueryable<Requestt>> orderBy = null, int? top = null, int? skip = null,
          params string[] includeProperties)
        {
            IQueryable<Requestt> query = context.Set<Requestt>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (top.HasValue)
            {
                query = query.Take(top.Value);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<List<Requestt>> GetRequestListAsync()
        {
            return await context.Set<Requestt>().ToListAsync();
        }

        public async Task UpdateRequestAsync(Requestt entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

      
    }
}

