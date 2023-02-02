using Domain.Entities;
using MediatR;
using TaxCalculatorAPI.Commands;
using TaxCalculatorAPI.Services;

namespace TaxCalculatorAPI.Handlers
{
    public class PurchaseAmountVatRateCommandHandler : IRequestHandler<PurchaseByVatRateAmountCommand, Purchase>
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseAmountVatRateCommandHandler(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public async Task<Purchase> Handle(PurchaseByVatRateAmountCommand command, CancellationToken cancellationToken)
        {
            return _purchaseService.CalculateAmountVatRate(command.Net, command.Gross, command.Vat);
        }
    }
}
