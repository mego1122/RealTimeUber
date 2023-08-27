using Microsoft.EntityFrameworkCore;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;
using System.Linq.Expressions;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TrackingContext context;
        //protected readonly TrackingContext context;
        public GenericRepository(TrackingContext context)
        {
            this.context = context;
        }

        public IQueryable<T> Entities =>context.Set<T>();


        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
