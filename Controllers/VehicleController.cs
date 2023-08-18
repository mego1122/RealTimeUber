using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        ILoggerManager _logger;
        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper, ILoggerManager logger)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }


        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<VehicleDTO> Get()
        {
            _logger.LogInfo("Request received to Get All Vehicles");
            List<Vehicle> Vehicles = unitOfWork.Vehicles.GetAll().ToList();
            //log vehicles
            _logger.LogInfo("Get Vehicles requested" + Vehicles);
            var x= _mapper.Map<List<VehicleDTO>>(Vehicles);
            return x.ToList();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public VehicleDTO Get(int id)
        {   var v= unitOfWork.Vehicles.GetById(id);
            VehicleDTO vd = _mapper.Map<VehicleDTO>(v);
            return vd;
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] VehicleDTO VehicleDto)
       {
            
            Vehicle v = _mapper.Map<Vehicle>(VehicleDto);
            //v.Id = 432;
            unitOfWork.Vehicles.Add(v);
            unitOfWork.Complete();
        }

        // PUT api/<VehicleController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //    unitOfWork.
        //}

        // DELETE api/<VehicleController>/5

        //Add CORS headers to specific controller actions:
        [EnableCors("MyPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Vehicle vehicle = unitOfWork.Vehicles.GetById(id);
            unitOfWork.Vehicles.Remove(vehicle);
            unitOfWork.Complete();
        }
    }
}
