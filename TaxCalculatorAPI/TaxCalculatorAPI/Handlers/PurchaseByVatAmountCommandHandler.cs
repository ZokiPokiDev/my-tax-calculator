using Domain.Entities;
using MediatR;
using TaxCalculatorAPI.Commands;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Handlers
{
    public class PurchaseByVatAmountCommandHandler : IRequestHandler<PurchaseByVatAmountCommand, Purchase>
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseByVatAmountCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public async Task<Purchase> Handle(PurchaseByVatAmountCommand command, CancellationToken cancellationToken)
        {
            return _purchaseService.CalculateByVatAmount(command.VAT, command.VatRate);
        }
    }
}
