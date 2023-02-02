namespace TaxCalculatorAPI.Requests
{
    public class PurchaseAmountRequest
    {
        public double Net { get; set; }
        public double Vat { get; set; }
        public double Gross { get; set; }
    }
}
