namespace Domain.Entities
{
    public class Purchase
    {
        public const int PERCENTAGE = 100;
        public const int ROUND_DIGIT = 2;
        public const string VAT_RATE_NET = "net";
        public const string VAT_RATE_VAT = "vat";
        public const string VAT_RATE_GROSS = "gross";

        public Amount Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Created { get; }

        public Purchase()
        {
            Amount = new();
            Currency = "euro";
            Created = DateTime.Now;
        }

        public Purchase(Amount amount)
        {
            Amount = amount;
            Currency = "euro";
            Created = DateTime.Now;
        }
    }
}
