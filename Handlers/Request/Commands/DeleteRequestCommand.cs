using MediatR;

namespace RealTimeUber.Handlers.Request.Commands
{
    public class DeleteRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
