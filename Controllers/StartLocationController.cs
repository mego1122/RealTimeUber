using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Models;

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartLocationController : ControllerBase
    {
    
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper _mapper;

        public StartLocationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

     
        [HttpGet]
        public IEnumerable<StartLocation> Get()
        {
            List<StartLocation> StartLocations = unitOfWork.StartLocations.GetAll().ToList();

            //var x = _mapper.Map<List<VehicleDTO>>(Vehicles);

            return StartLocations;
        }

        [HttpGet("{id}")]
        public StartLocation Get(int id)
        {
            var v = unitOfWork.StartLocations.GetById(id);
            //VehicleDTO vd = _mapper.Map<VehicleDTO>(v);
            return v;
        }

       

        
        [HttpPost]
        public void Post([FromBody] StartLocationDTO StartLocationDTO)
        {

            var stl = _mapper.Map<StartLocation>(StartLocationDTO);
            //v.Id = 432;
            unitOfWork.StartLocations.Add(stl);
            unitOfWork.Complete();
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var v = unitOfWork.StartLocations.GetById(id);
            unitOfWork.StartLocations.Remove(v);
            unitOfWork.Complete();
        }



    }
}
