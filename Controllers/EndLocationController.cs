using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Models;

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndLocationController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        
        private readonly IMapper _mapper;
        
        public EndLocationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
                this.unitOfWork = unitOfWork;
                _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EndLocation> GetEndLocations()
        {
            List<EndLocation> endLocations = unitOfWork.EndLocations.GetAll().ToList();
            return endLocations;
        }
        [HttpGet("{id}")]
        public EndLocation Get(int id) 
        {
            if (id != null || id >= 0 )
            {

            }
            else
            {

            }
            var EL = unitOfWork.EndLocations.GetById(id);
            return EL;
        }

        [HttpPost]
        public void Post([FromBody] EndLocationDTO EndLocationDTO)
        {
            var EL = _mapper.Map<EndLocation>(EndLocationDTO);
            unitOfWork.EndLocations.Add(EL);
            unitOfWork.Complete();
        }

        [HttpDelete]
        public void Delete(int id) 
        {
            var EL = unitOfWork.EndLocations.GetById(id);
            unitOfWork.EndLocations.Remove(EL);
            unitOfWork.Complete();
        }
    }
}
