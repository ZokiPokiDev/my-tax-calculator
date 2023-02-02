using Domain.Entities;

namespace TaxCalculatorAPI.Services
{
    public interface IPurchaseService
    {
        public Purchase CalculateByNetAmount(double net, double vatRate);
        public Purchase CalculateByGrossAmount(double gross, double vatRate);
        public Purchase CalculateByVatAmount(double vat, double vatRate);
        public Purchase CalculateAmountVatRate(double net, double gross, double vat);
    }
}
