using Domain.Entities;
using MediatR;

namespace TaxCalculatorAPI.Commands
{
    public class PurchaseByVatAmountCommand : IRequest<Purchase>
    {
        public double VAT { get; set; }
        public double VatRate { get; set; }
    }
}
