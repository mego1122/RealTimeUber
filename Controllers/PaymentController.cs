using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using RealTimeUber.DTO;
using RealTimeUber.Models;

namespace RealTimeUber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            var paymentList = await _unitOfWork.Payments.GetAllAsync();
            return paymentList;
        }

        [HttpGet]
        public async Task<Payment> GetById(int id)
        {
            var payment = await _unitOfWork.Payments.GetByIdAsync(id);

            return payment;
        }

        [HttpPost]
        public async void Post([FromBody] VehicleDTO VehicleDto)
        {
            Payment payment = _mapper.Map<Payment>(VehicleDto);
            _unitOfWork.Payments.Add(payment);
            await _unitOfWork.Complete();
        }

        [HttpDelete]
        public async void Delete(int id)
        {
            var deletedPayment = await _unitOfWork.Payments.GetByIdAsync(id);

             _unitOfWork.Payments.Remove(deletedPayment);
            _unitOfWork.Complete();
        }
    }
}
