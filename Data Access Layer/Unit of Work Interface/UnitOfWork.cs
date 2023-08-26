using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface
{
    public class UnitOfWork : IUnitOfWork
    {
         TrackingContext _context;
        public IVehicleRepository Vehicles { get;  }
        public IStartLocationRepository StartLocations { get; }
        public IEndLocationRepository EndLocations { get; }

        public IRequestRepository Requests { get; }
        public IDriverRepository Drivers { get; }

        //IStartLocationRepository IUnitOfWork.StartLocations => throw new NotImplementedException();
        //public IGenericRepository<Vehicle> Vehicles => new GenericRepository<Vehicle>(_context);

        public UnitOfWork(TrackingContext ctx)
        {
            _context = ctx;

            Vehicles = new VehicleRepository(_context);

            StartLocations = new StartLocationRepository(_context);

            EndLocations = new EndLocationRepository(_context);
            StartLocations=new StartLocationRepository(ctx);
            Requests=new RequestRepository(_context);
            Drivers = new DriverRepository(_context);
        }

        //public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        //{
        //    return new GenericRepository<TEntity>(_context);
        //}
       

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }




        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

    }
}
