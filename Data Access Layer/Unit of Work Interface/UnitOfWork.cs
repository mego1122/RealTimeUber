using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface
{
    public class UnitOfWork : IUnitOfWork
    {
        private TrackingContext _context;
        public IVehicleRepository Vehicles { get;  }
        public IStartLocationRepository StartLocations { get; }

        public IRequestRepository Requests { get; }

        //IStartLocationRepository IUnitOfWork.StartLocations => throw new NotImplementedException();
        //public IGenericRepository<Vehicle> Vehicles => new GenericRepository<Vehicle>(_context);

        public UnitOfWork(TrackingContext ctx)
        {
            _context = ctx;
            Vehicles = new VehicleRepository(_context);
            StartLocations=new StartLocationRepository(_context);
            Requests=new RequestRepository(_context);
        }



        
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
