using Domain.Entities;

namespace TaxCalculatorAPI.Services
{
    public class PurchaseService : IPurchaseService
    {
        public Purchase CalculateByNetAmount(double net, double vatRate)
        {
            Amount amount = new Amount();
            amount.Net = Math.Round(net, Purchase.ROUND_DIGIT);
            amount.VAT = Math.Round(net * vatRate / Purchase.PERCENTAGE, Purchase.ROUND_DIGIT);
            amount.Gross = Math.Round(amount.Net + amount.VAT, Purchase.ROUND_DIGIT);
            amount.VATRate = vatRate;

            return new Purchase(amount);
        }

        public Purchase CalculateByGrossAmount(double gross, double vatRate)
        {
            Amount amount = new Amount();
            double vatCoeficient = Purchase.PERCENTAGE / vatRate;
            double vatConst = vatCoeficient + 1;

            amount.Gross = Math.Round(gross, Purchase.ROUND_DIGIT);
            amount.VAT = Math.Round(gross / vatConst, Purchase.ROUND_DIGIT);
            amount.Net = Math.Round(gross - amount.VAT, Purchase.ROUND_DIGIT);
            amount.VATRate = vatRate;

            return new Purchase(amount);
        }

        public Purchase CalculateByVatAmount(double vat, double vatRate)
        {
            Amount amount = new Amount();
            amount.VAT = Math.Round(vat, Purchase.ROUND_DIGIT);
            amount.Net = Math.Round(Purchase.PERCENTAGE * vat / vatRate, Purchase.ROUND_DIGIT);
            amount.Gross = Math.Round(amount.Net + amount.VAT, Purchase.ROUND_DIGIT);
            amount.VATRate = vatRate;

            return new Purchase(amount);
        }

        public Purchase CalculateAmountVatRate(double net, double gross, double vat)
        {
            Amount amount = new Amount();
            amount.Net = Math.Round(net, 2);
            amount.Gross = Math.Round(gross, 2);
            amount.VAT = Math.Round(vat, 2);
            amount.VATRate = Math.Round(Purchase.PERCENTAGE * vat / net, 2);

            return new Purchase(amount);
        }
    }
}
