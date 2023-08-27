using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Handlers.Payment.Queries;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Payment.Handlers
{
    public class GetPaymentListHandler : IRequestHandler<GetPaymentListQuery, IEnumerable<RealTimeUber.Models.Payment>>
    {
        private readonly IPaymentRepository _IPaymentRepository;
        private readonly IMapper _Mapper;

        public GetPaymentListHandler(IPaymentRepository iPaymentRepository, IMapper mapper)
        {
            _IPaymentRepository = iPaymentRepository;
            _Mapper = mapper;
        }

        public async Task<IEnumerable<RealTimeUber.Models.Payment>> Handle(GetPaymentListQuery query, CancellationToken cancellationToken)
        {
            return await _IPaymentRepository.GetAllAsync();
        }
    }
}
