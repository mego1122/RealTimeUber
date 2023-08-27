using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Handlers.Payment.Commands
{
    public class CreatePaymentCommand : IRequest<RealTimeUber.Models.Payment>
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int TripId { get; set; }

        public CreatePaymentCommand(int id, double amount, string paymentMethod, int tripId)
        {
            Id = id;
            Amount = amount;
            PaymentMethod = paymentMethod;
            TripId = tripId;
        }
    }
}
