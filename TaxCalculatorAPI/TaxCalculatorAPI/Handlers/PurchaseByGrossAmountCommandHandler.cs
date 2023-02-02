using Domain.Entities;
using MediatR;
using TaxCalculatorAPI.Commands;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Handlers
{
    public class PurchaseByGrossAmountCommandHandler : IRequestHandler<PurchaseByGrossAmountCommand, Purchase>
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseByGrossAmountCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public async Task<Purchase> Handle(PurchaseByGrossAmountCommand command, CancellationToken cancellationToken)
        {
            return _purchaseService.CalculateByGrossAmount(command.Gross, command.VatRate);
        }
    }
}
