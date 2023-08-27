using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;
using System.Linq.Expressions;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class PaymentRepository : GenericRepository<Payment> , IPaymentRepository
    {
        private TrackingContext _context;
        public PaymentRepository(TrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> AddAsync(Payment entity)
        {
            await _context.Set<Payment>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Payment entity)
        {
              _context.Set<Payment>().Remove(entity);
        }

        public Task DeleteManyAsync(Expression<Func<Payment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Set<Payment>().ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Set<Payment>().FirstOrDefaultAsync(x=>x.Id== id);
        }

        public async Task UpdateAsync(Payment paymentDetails)
        {
             _context.Entry(paymentDetails).State = EntityState.Modified;
        }
    }
}
