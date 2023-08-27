using RealTimeUber.Models;
using System.Linq.Expressions;

namespace RealTimeUber.Data_Access_Layer.Repository_Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<Payment> AddAsync(Payment entity);
        Task DeleteAsync(Payment entity);
        Task DeleteManyAsync(Expression<Func<Payment, bool>> filter);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        //Task<IEnumerable<Requestt>> GetManyAsync(Expression<Func<Requestt, bool>> filter = null,
        //                                  Func<IQueryable<Requestt>, IOrderedQueryable<Requestt>> orderBy = null,
        //                                  int? top = null,
        //                                  int? skip = null,
        //                                  params string[] includeProperties);

        //public Task UpdateRequestAsync(Payment studentDetails);
        public Task UpdateAsync(Payment paymentDetails);
    }
}
