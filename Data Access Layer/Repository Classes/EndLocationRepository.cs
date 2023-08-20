using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class EndLocationRepository : GenericRepository<EndLocation>, IEndLocationRepository
    {
        public EndLocationRepository(TrackingContext context) : base(context) { }
    }
}
