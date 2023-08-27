using AutoMapper;
using RealTimeUber.DTO;
using RealTimeUber.Models;
using System.Collections.Generic;
using System.Net;

namespace RealTimeUber.AutoMaper
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<Vehicle, VehicleDTO>()
               //  .ForMember(v => v.Id, a => a.MapFrom(vd => vd.Id))
                .ForMember(v => v.LicensePlate, a => a.MapFrom(vd => vd.LicensePlate))
                .ForMember(v => v.DriverId, a => a.MapFrom(vd => vd.DriverId)).ReverseMap();

            CreateMap<StartLocation, StartLocationDTO>()
                  //  .ForMember(v => v.Id, a => a.MapFrom(vd => vd.Id))
                  .ForMember(v => v.Timestamp, a => a.MapFrom(vd => vd.Timestamp))
                  .ForMember(v => v.Latitude, a => a.MapFrom(vd => vd.Latitude))
                  .ForMember(v => v.Latitude, a => a.MapFrom(vd => vd.Latitude))
                  .ForMember(v => v.ApplicationUserId, a => a.MapFrom(vd => vd.ApplicationUserId)).ReverseMap();

            CreateMap<Requestt, RequestDTO>()
                //  .ForMember(v => v.Id, a => a.MapFrom(vd => vd.Id))
                .ForMember(v => v.PassengerId, a => a.MapFrom(vd => vd.PassengerId))
                .ForMember(v => v.StartLocationId, a => a.MapFrom(vd => vd.StartLocationId))
                .ForMember(v => v.EndLocationId, a => a.MapFrom(vd => vd.EndLocationId)).ReverseMap();

            CreateMap<EndLocation, EndLocationDTO>().ReverseMap();

            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
        }
}
