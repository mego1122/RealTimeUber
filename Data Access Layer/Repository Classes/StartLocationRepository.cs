using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class StartLocationRepository : GenericRepository<StartLocation>, IStartLocationRepository
    {
        public StartLocationRepository(TrackingContext context) : base(context) { }
    }
    
}
