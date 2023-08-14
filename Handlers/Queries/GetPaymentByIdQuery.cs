using AutoMapper;
using MediatR;
using RealTimeUber.Data_Access_Layer.Unit_of_Work_Interface;
using System;

namespace RealTimeUber.Handlers.Queries
{
    //public class GetPaymentByIdQuery:IRequest<int>
    //{



    //    public class GetPaymentByIdQueryHandler : : IRequestHandler<CreateProductCommand, int>
    //{
    //    private readonly IUnitOfWork _uow;
    //    private readonly IMapper _mapper;

    //    public GetPaymentByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    //    {
    //        _uow = uow;
    //        _mapper = mapper;
    //    }

    //    public async Task<ErrorOr<PersonResource>> Handle(GetPersonByIdQuery request,
    //        CancellationToken cancellationToken)
    //    {
    //        //var employee = await _uow.Repository().GetById<Person>(request.Id);
    //        //if (employee is null)
    //        //    return Error.NotFound(code: "Person not found", description: "Please enter the existing Person Id");

    //        //return _mapper.Map<PersonResource>(employee);
    //    }
    //}


}
