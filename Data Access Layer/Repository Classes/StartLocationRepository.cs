using Microsoft.EntityFrameworkCore;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class StartLocationRepository : GenericRepository<StartLocation>, IStartLocationRepository
    {
        //TrackingContext context;
        public StartLocationRepository(TrackingContext context) : base(context) {

            //context = context;
        }

        //public IQueryable<StartLocation> StartLocations =>context.StartLocations;
    }
    
}
