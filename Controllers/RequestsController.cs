using AutoMapper;
using LoggerService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Queries;
using RealTimeUber.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {

        private readonly IStringLocalizer<VehicleController> _localizer;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        ILoggerManager _logger;
        private readonly IMediator mediator;
        public RequestsController(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger, IStringLocalizer<VehicleController> localizerr, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _localizer = localizerr;
            this.mediator = mediator;
        }

        // GET: api/<RequestsController>
        [HttpGet]
        [HttpGet]
        public async Task< IEnumerable<RequestDTO>> Get()
        {
            _logger.LogInfo("Request received to Get All requests");
            var Requestts = await mediator.Send(new GetRequestListQuery());
            _logger.LogInfo("Get requets requested" + Requestts);
            var x = _mapper.Map<List<RequestDTO>>(Requestts);
            return x.ToList();
        }

        // GET api/<RequestsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RequestsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RequestsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RequestsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
