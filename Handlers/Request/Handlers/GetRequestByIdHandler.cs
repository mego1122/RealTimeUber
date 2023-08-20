using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Queries;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Handlers
{
    public class GetRequestByIdHandler : IRequestHandler<GetRequestByIdQuery, Requestt>
    {
        private readonly IRequestRepository _IRequestRepository;
        private readonly IMapper _mapper;
        public GetRequestByIdHandler(IMapper mapper, IRequestRepository RequestRepository)
        {
            _IRequestRepository = RequestRepository;
            _mapper = mapper;
        }

        public  async Task<Requestt> Handle(GetRequestByIdQuery query, CancellationToken cancellationToken)
        {
            return await _IRequestRepository.GetByIdAsync(query.Id);
        }
    }
}
