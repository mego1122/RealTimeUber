using MediatR;

namespace RealTimeUber.Handlers.Payment.Commands
{
    public class DeletePaymentCommand : IRequest
    {
        public int Id { get; set; }
    }
}
