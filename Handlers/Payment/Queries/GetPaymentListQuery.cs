using MediatR;

namespace RealTimeUber.Handlers.Payment.Queries
{
    public class GetPaymentListQuery : IRequest<List<RealTimeUber.Models.Payment>>
    {

    }
}
