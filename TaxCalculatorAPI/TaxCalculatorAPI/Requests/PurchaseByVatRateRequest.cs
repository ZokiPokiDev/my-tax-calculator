using Domain.Entities;

namespace TaxCalculatorAPI.Requests
{
    public class PurchaseByVatRateRequest
    {
        public double Amount { get; set; }
        public double VatRate { get; set; }
    }
}
