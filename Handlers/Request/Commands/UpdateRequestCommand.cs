using MediatR;

namespace RealTimeUber.Handlers.Request.Commands
{
    public class UpdateRequestCommand : IRequest
    {
        public int ID { get; set; }
        public string PassengerId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        

        public UpdateRequestCommand(int id, string PassengerId, int StartLocationId, int EndLocationId)
        {
            ID = id;
            PassengerId = PassengerId;
            StartLocationId = StartLocationId;
            EndLocationId = EndLocationId;

        }

     
    }
}
