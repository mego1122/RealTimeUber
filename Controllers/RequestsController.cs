using AutoMapper;
using Azure.Core;
using LoggerService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Queries;
using RealTimeUber.Models;
using RealTimeUber.Services.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        RequestService RequestService;
        private readonly IMapper _mapper;
        public RequestsController(IUnitOfWork unitOfWork, IMapper mapper, RequestService RequestService)
        {
            this.RequestService = RequestService;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task Post([FromBody] RequestDTO request)
        {

            Requestt r = _mapper.Map<Requestt>(request);

            await RequestService.CreateRequest(r);
           
           await unitOfWork.Complete();
        }



        //// GET: api/<RequestsController>
        //[HttpGet]
        //[HttpGet]
        //public async Task< IEnumerable<RequestDTO>> Get()
        //{
        //    _logger.LogInfo("Request received to Get All requests");
        //    var Requestts = await mediator.Send(new GetRequestListQuery());
        //    _logger.LogInfo("Get requets requested" + Requestts);
        //    var x = _mapper.Map<List<RequestDTO>>(Requestts);
        //    return x.ToList();
        //}

        //// GET api/<RequestsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<RequestsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RequestsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RequestsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}



        //[HttpPost("request")]
        //public async Task<IActionResult> CreateRequest(Request request)
        //{

        //    // Input validation

        //    var nearestDrivers = await GetNearestDrivers(request);

        //    if (nearestDrivers.Any())
        //    {

        //       // var assignedDriver = await AssignTrip(request, nearestDrivers);

        //        //if (assignedDriver != null)
        //        //{
        //        //    // Trip assigned, return success  
        //        //    return Ok();
        //        //}
        //    }

        //    // No driver subscribed, return error
        //    return BadRequest();
        //}

        //public async Task<List<Driver>> GetNearestDrivers(Request request)
        //{

        //    //var startLocation = await _context.StartLocations
        //    //.Include(s => s.Driver)
        //    //.FirstOrDefaultAsync(s => s.Id == request.StartLocationId);

        //    //return await _context.Drivers
        //    //.Where(d => d.StartLocations.Any(s =>
        //    //s.Location.CalculateDistance(startLocation.Location) < 5))
        //    //.ToListAsync();
        //}

        //public async Task<Driver> AssignTrip(Request request, List<Driver> drivers)
        //{

        //    // Notify drivers
        //    await NotifyDrivers(request, drivers);

        //    var driver = await _context.Drivers
        //      .FirstOrDefaultAsync(d => d.Subscribed);

        //    // Assign trip
        //    driver.Trips.Add(new Trip() { Request = request });

        //    return driver;
        //}

        //public async Task NotifyDrivers(Request request, List<Driver> drivers)
        //{
        //    foreach (var driver in drivers)
        //    {
        //        // Send notification
        //        await SendNotification(request, driver);

        //        // Track response
        //        driver.Notified = true;
        //    }

        //    await _context.SaveChangesAsync();
        //}

        //private async Task SendNotification(Request request, Driver driver)
        //{
        //    var message = CreateMessage(request);

        //    try
        //    {
        //        await _notificationService.SendPushNotificationAsync(
        //          driver.DeviceToken,
        //          message);
        //    }
        //    catch (Exception)
        //    {
        //        // log error 
        //    }
        //}



    }
}
