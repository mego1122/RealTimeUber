using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Payment.Commands;

namespace RealTimeUber.Handlers.Payment.Handlers
{
    public class UpdatePaymentHandler : IRequest<UpdatePaymentCommand>
    {
        private readonly IPaymentRepository _IPaymentRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentHandler (IPaymentRepository iPaymentRepository, IMapper mapper)
        {
            _IPaymentRepository = iPaymentRepository;
            _mapper = mapper;
        }
        public async Task Handle (UpdatePaymentCommand command, CancellationToken cancellationToken) 
        {
            var existingPayment = await _IPaymentRepository.GetByIdAsync(command.Id);

            if (existingPayment != null) 
            {
                existingPayment.Amount = command.Amount;

                existingPayment.PaymentMethod = command.PaymentMethod;

                await _IPaymentRepository.UpdateAsync(existingPayment);
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }
    }
}
