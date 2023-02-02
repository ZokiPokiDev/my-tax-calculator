using Domain.Entities;
using MediatR;

namespace TaxCalculatorAPI.Commands
{
    public class PurchaseByVatRateAmountCommand : IRequest<Purchase>
    {
        public double Net { get; set; }
        public double Vat { get; set; }
        public double Gross { get; set; }
    }
}
