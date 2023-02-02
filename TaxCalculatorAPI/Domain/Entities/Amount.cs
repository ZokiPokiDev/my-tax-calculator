namespace Domain.Entities
{
    public class Amount
    {
        public double Net { get; set; }
        public double Gross { get; set; }
        public double VAT { get; set; }
        public double VATRate { get; set; }

        public Amount()
        {
        }

        public Amount(double net, double gross, double vat, double vatRate)
        {
            Net = Math.Round(net, 2);
            Gross = Math.Round(gross, 2);
            VAT = Math.Round(vat, 2);
            VATRate = Math.Round(vatRate, 2);
        }
    }
}
