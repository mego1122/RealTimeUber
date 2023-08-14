using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(TrackingContext context) : base(context) { }

        //public string Addd(Vehicle entity)
        //{
        //    string x = context.Set<Vehicle>().Add(entity).ToString();
        //    return x;
        //}
    }

   
}

