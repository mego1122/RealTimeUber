using MediatR;

namespace RealTimeUber.Handlers.Payment.Commands
{
    public class UpdatePaymentCommand : IRequest<RealTimeUber.Models.Payment>
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int TripId { get; set; }

        public UpdatePaymentCommand(int id, double amount, string paymentMethod, int tripId)
        {
            Id = id;
            Amount = amount;
            PaymentMethod = paymentMethod;
            TripId = tripId;
        }
    }
}
