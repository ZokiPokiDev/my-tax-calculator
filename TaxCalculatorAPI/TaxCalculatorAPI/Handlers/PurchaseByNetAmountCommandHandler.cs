using Domain.Entities;
using MediatR;
using TaxCalculatorAPI.Commands;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Handlers
{
    public class PurchaseByNetAmountCommandHandler : IRequestHandler<PurchaseByNetAmountCommand, Purchase>
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseByNetAmountCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService= purchaseService;
        }

        public async Task<Purchase> Handle(PurchaseByNetAmountCommand command, CancellationToken cancellationToken)
        {
            return _purchaseService.CalculateByNetAmount(command.Net, command.VatRate);
        }
    }
}
