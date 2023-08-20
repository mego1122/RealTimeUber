using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Repository_Classes;
using RealTimeUber.Data_Access_Layer.Repository_Interfaces;
using RealTimeUber.Handlers.Request.Commands;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Handlers
{
    public class UpdateRequestHandler : IRequest<Requestt>
    {
       

        private readonly IRequestRepository _IRequestRepository;
        private readonly IMapper _mapper;
        public UpdateRequestHandler(IMapper mapper, IRequestRepository RequestRepository)
        {
            _IRequestRepository = RequestRepository;
            _mapper = mapper;
        }
        public async Task<Requestt> Handle(UpdateRequestCommand command, CancellationToken cancellationToken)
        {
            var RequestDetails = await _IRequestRepository.GetByIdAsync(command.ID);
            
            RequestDetails.PassengerId = command.PassengerId;
            RequestDetails.StartLocationId = command.StartLocationId;
            RequestDetails.EndLocationId = command.EndLocationId;
  

            return await _IRequestRepository.UpdateRequestAsync(RequestDetails);
        }


    }
}
