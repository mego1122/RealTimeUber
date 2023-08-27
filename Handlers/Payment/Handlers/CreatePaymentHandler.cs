using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Payment.Commands;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Payment.Handlers
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, RealTimeUber.Models.Payment>
    {
        private readonly IPaymentRepository _IPaymentRepository;
        private readonly IMapper _mapper;

        public CreatePaymentHandler (IPaymentRepository iPaymentRepository, IMapper mapper)
        {
            _IPaymentRepository = iPaymentRepository;
            _mapper = mapper;
        }

        public async Task<RealTimeUber.Models.Payment> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            var paymentDTO = new PaymentDTO()
            {
                Amount = command.Amount,
                PaymentMethod = command.PaymentMethod
            };
            var paymentMapper = _mapper.Map<RealTimeUber.Models.Payment>(paymentDTO);

            return await _IPaymentRepository.AddAsync(paymentMapper);
        }
    }
}
