using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Queries;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Handlers
{
    public class GetRequestListHandler : IRequestHandler<GetRequestListQuery, List<Requestt>>
    {
        private readonly IRequestRepository _IRequestRepository;
        private readonly IMapper _mapper;
        public GetRequestListHandler(IMapper mapper, IRequestRepository RequestRepository)
        {
            _IRequestRepository = RequestRepository;
            _mapper = mapper;
        }

        public async Task<List<Requestt>> Handle(GetRequestListQuery query, CancellationToken cancellationToken)
        {
            return await _IRequestRepository.GetAllAsync();
        }

        
    }
}
