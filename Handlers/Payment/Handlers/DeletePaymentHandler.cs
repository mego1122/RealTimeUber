using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Handlers.Payment.Commands;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Payment.Handlers
{
    public class DeletePaymentHandler : IRequest
    {
        private readonly IPaymentRepository _IPaymentRepository;
        private readonly IMapper _mapper;

        public DeletePaymentHandler(IPaymentRepository iPaymentRepository, IMapper mapper)
        {
            _IPaymentRepository = iPaymentRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            var paymentDetails = await _IPaymentRepository.GetByIdAsync(command.Id);
            if (paymentDetails != null) 
            {
                var mapper = _mapper.Map<RealTimeUber.Models.Payment>(paymentDetails);

                 await _IPaymentRepository.DeleteAsync(mapper);
            }
            
        }
    }
}
