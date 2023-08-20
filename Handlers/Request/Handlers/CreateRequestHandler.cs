using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Commands;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Handlers
{
    public class CreateRequestHandler : IRequestHandler<CreateRequestCommand, Requestt>
    {
        private readonly IRequestRepository _IRequestRepository;
        private readonly IMapper _mapper;
        public CreateRequestHandler(IMapper mapper, IRequestRepository RequestRepository)
        {
            _IRequestRepository = RequestRepository;
            _mapper = mapper;
        }
        public async Task<Requestt> Handle(CreateRequestCommand command, CancellationToken cancellationToken)
        {
            var RequestDTO = new RequestDTO()
            {
       
                PassengerId = command.PassengerId,
                StartLocationId = command.StartLocationId,
                EndLocationId = command.EndLocationId
            };
            var x = _mapper.Map<Requestt>(RequestDTO);

            return await _IRequestRepository.AddAsync(x);
        }
    }
}
