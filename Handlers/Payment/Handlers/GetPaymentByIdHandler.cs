using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Handlers.Payment.Queries;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Payment.Handlers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentsByIdQuery, RealTimeUber.Models.Payment>
    {
        private readonly IPaymentRepository _IPaymentRepository;
        private readonly IMapper _mapper;

        public GetPaymentByIdHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _IPaymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<RealTimeUber.Models.Payment> Handle(GetPaymentsByIdQuery query, CancellationToken cancellationToken)
        {
            return await _IPaymentRepository.GetByIdAsync(query.Id);
        }
    }
}
