using AutoMapper;
using Azure.Core;
using LoggerService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using RealTimeUber.Controllers;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Handlers.Request.Commands;
using RealTimeUber.Handlers.Request.Queries;
using RealTimeUber.Models;
using RealTimeUber.SignalR;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace RealTimeUber.Services.Request
{
    public class RequestService
    {
       
        private readonly IStringLocalizer<VehicleController> _localizer;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        ILoggerManager _logger;
        private readonly IMediator mediator;
        private readonly IHubContext<NotificationCenterHub> _hubContext;
        public RequestService(IHubContext<NotificationCenterHub> hubContext,IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger, IStringLocalizer<VehicleController> localizerr, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _localizer = localizerr;
            this.mediator = mediator;
            _hubContext = hubContext;
        }

       
        public async Task<IEnumerable<RequestDTO>> Get()
        {
            _logger.LogInfo("Request received to Get All requests");
            var Requestts = await mediator.Send(new GetRequestListQuery());
            _logger.LogInfo("Get requets requested" + Requestts);
            var x = _mapper.Map<List<RequestDTO>>(Requestts);
            return x.ToList();
        }



       
        public async Task CreateRequest(Requestt request)
        {
            // Input validation
            // Add Request(passengerId, Start and Endlocation)
            var Requestt = await mediator.Send(new CreateRequestCommand(request));


            var nearestDrivers = await GetNearestDrivers(Requestt);

            if (nearestDrivers.Any())
            {

                var assignedDriver = await AssignTrip(request, nearestDrivers);

                //if (assignedDriver != null)
                //{
                //    // Trip assigned, return success  
                //    return Ok();
                //}
            }

            // No driver subscribed, return error

        }

        public async Task<List<Driver>> GetNearestDrivers(Requestt request)
        {
            var startLocation1=  await unitOfWork.StartLocations.Entities.Include(s => s.ApplicationUserId).FirstOrDefaultAsync(s => s.StartLocationId == request.StartLocationId);

            //var startLocation1 = await unitOfWork.StartLocations.StartLocations.Include(s => s.ApplicationUser).FirstOrDefaultAsync(s => s.StartLocationId == request.StartLocationId);

            //return await unitOfWork.Drivers.Drivers.Where(driver => driver.StartLocations.Any(loc =>
            //CalculateDistance(loc.Latitude, loc.Longitude,startLocation1.Latitude, startLocation1.Longitude) < 5)).ToListAsync();

            return await unitOfWork.Drivers.Entities.Where(driver => driver.StartLocations.Any(loc =>
           CalculateDistance(loc.Latitude, loc.Longitude, startLocation1.Latitude, startLocation1.Longitude) < 5)).ToListAsync();



        }

        public static double CalculateDistance(double _lat1, double _long1, double _lat2, double _long2)
        {
            var lat1 = _lat1 * Math.PI / 180;
            var long1 = _long1 * Math.PI / 180;
            var lat2 = _lat2 * Math.PI / 180;
            var long2 = _long2 * Math.PI / 180;

            var deltaLat = lat2 - lat1;
            var deltaLong = long2 - long1;

            var a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Pow(Math.Sin(deltaLong / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var distance = 6371 * c;

            return distance;
        }

        public async Task<Driver> AssignTrip(Requestt request, List<Driver> drivers)
        {

            // Notify drivers
             await NotifyDrivers(request, drivers);

            // var driver = await unitOfWork.Drivers.Drivers .FirstOrDefaultAsync(d => d.Subscribed);
            var driver = await unitOfWork.Drivers.Entities.FirstOrDefaultAsync();
            //// Assign trip
            //driver.Trips.Add(new Trip() { Request = request });

            return driver;
        }

        public async Task NotifyDrivers(Requestt request, List<Driver> drivers)
        {
            string[] driverIds = drivers.Select(d => d.Id).ToArray();
            await _hubContext.Clients.Clients(driverIds).SendAsync("SendTripRequest", request);


            //foreach (var driver in drivers)
            //{
            // Send notification
           // await SendNotification(request, drivers);
               // Track response
                 //driver.Notified = true;
            //}
            // await _context.SaveChangesAsync();
        }

        //private async Task SendNotification(Requestt request, List<Driver> drivers)
        //{
            


        //    //var message = CreateMessage(request);

        //    //try
        //    //{
        //    //    await _notificationService.SendPushNotificationAsync(
        //    //      driver.DeviceToken,
        //    //      message);
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    // log error 
        //    //}
        //}



  



    }
}

