using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Models;

namespace RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface
{
    public interface IUnitOfWork : IDisposable
    {

        IVehicleRepository Vehicles { get; }
        IStartLocationRepository  StartLocations { get; }
        IEndLocationRepository EndLocations { get; }
        IRequestRepository Requests { get; }
        IPaymentRepository Payments { get; }


        Task Complete();

    }
}
