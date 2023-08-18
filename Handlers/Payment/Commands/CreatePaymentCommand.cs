using MediatR;

namespace RealTimeUber.Handlers.Payment.Commands
{
    public class CreatePaymentCommand : IRequest<int>
    {

        //public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
        //{
            //  private readonly IApplicationContext _context;
            //public CreatePaymentCommandHandler(/*IApplicationContext context*/)
            //{
            //    //_context = context;
            //}
            //public async Task<int> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
            //{
            //    //var product = new Product();
            //    //product.Barcode = command.Barcode;
            //    //product.Name = command.Name;
            //    //product.BuyingPrice = command.BuyingPrice;
            //    //product.Rate = command.Rate;
            //    //product.Description = command.Description;
            //    //_context.Products.Add(product);
            //    //await _context.SaveChanges();
            //    return product.Id;
            //}


        //}


    }
}
