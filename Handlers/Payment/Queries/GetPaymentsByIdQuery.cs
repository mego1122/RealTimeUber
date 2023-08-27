using MediatR;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Payment.Queries
{
    public class GetPaymentsByIdQuery : IRequest<RealTimeUber.Models.Payment>
    {
        public int Id { get; set; }
    }
}
