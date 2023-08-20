using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Commands;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Handlers
{
    public class DeleteRequestHandler : IRequest
    {
        private readonly IRequestRepository _IRequestRepository;
        private readonly IMapper _mapper;
        public DeleteRequestHandler(IMapper mapper, IRequestRepository RequestRepository)
        {
            _IRequestRepository = RequestRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteRequestCommand command, CancellationToken cancellationToken)
        {
            var RequestDetails = await _IRequestRepository.GetByIdAsync(command.Id);
            var x = _mapper.Map<Requestt>(RequestDetails);
             await _IRequestRepository.DeleteAsync(x);
        }
    }
}
