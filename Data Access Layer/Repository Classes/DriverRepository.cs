using RealTimeUber.Models;
using System;

namespace RealTimeUber.Data_Access_Layer.Repository_Classes
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(TrackingContext context) : base(context) { }
    }
}
