using Domain.Entities;
using MediatR;

namespace TaxCalculatorAPI.Commands
{
    public class PurchaseByNetAmountCommand : IRequest<Purchase>
    {
        public double Net { get; set; }
        public double VatRate { get; set; }
    }
}
