using Microsoft.EntityFrameworkCore;
using RealTimeUber.Models;
using System.Linq.Expressions;

namespace RealTimeUber.Data_Access_Layer.Repository_Interfaces
{
    public interface IRequestRepository : IGenericRepository<Requestt> 
    {
        Task<Requestt> AddAsync(Requestt entity);
        Task DeleteAsync(Requestt entity);
        Task DeleteManyAsync(Expression<Func<Requestt, bool>> filter);
        Task<List<Requestt>> GetAllAsync();
        Task<Requestt> GetByIdAsync(int id);
        Task<IEnumerable<Requestt>> GetManyAsync(Expression<Func<Requestt, bool>> filter = null,
                                          Func<IQueryable<Requestt>, IOrderedQueryable<Requestt>> orderBy = null,
                                          int? top = null,
                                          int? skip = null,
                                          params string[] includeProperties);
      
        public  Task<Requestt> UpdateRequestAsync(Requestt studentDetails);
      
    }


    
}
