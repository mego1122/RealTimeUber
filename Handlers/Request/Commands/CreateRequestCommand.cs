using Azure.Core;
using MediatR;
using RealTimeUber.DTO;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Commands
{
    public class CreateRequestCommand : IRequest<Requestt>
    {
        public string PassengerId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }

        public CreateRequestCommand(string PassengerId, int StartLocationId, int EndLocationId)
        {
            PassengerId = PassengerId;
            StartLocationId = StartLocationId;
            EndLocationId = EndLocationId;
        }

        public CreateRequestCommand(Requestt request)
        {
            PassengerId = request.PassengerId;
            StartLocationId = request.StartLocationId;
            EndLocationId = request.EndLocationId;
        }
    }
}
