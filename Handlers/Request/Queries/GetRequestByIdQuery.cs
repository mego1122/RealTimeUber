using MediatR;
using RealTimeUber.DTO;
using RealTimeUber.Models;

namespace RealTimeUber.Handlers.Request.Queries
{
    public class GetRequestByIdQuery : IRequest<Requestt>
    {
        public int Id { get; set; }
    }
    
}
