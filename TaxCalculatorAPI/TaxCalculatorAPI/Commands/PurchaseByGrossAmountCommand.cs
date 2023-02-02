using Domain.Entities;
using MediatR;

namespace TaxCalculatorAPI.Commands
{
    public class PurchaseByGrossAmountCommand : IRequest<Purchase>
    {
        public double Gross { get; set; }
        public double VatRate { get; set; }
    }
}
