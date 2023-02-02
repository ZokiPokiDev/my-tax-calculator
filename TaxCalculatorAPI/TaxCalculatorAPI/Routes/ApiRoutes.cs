namespace TaxCalculatorAPI.Routes
{
    public static class ApiRoutes
    {
        public const string Domain = "api";
        public const string Version = "v1";
        public const string Base = Domain + "/" + Version + "/" + "calculate";

        public static class Purchase
        {
            public const string Net = "net";
            public const string Gross = "gross";
            public const string Vat = "vat";
            public const string VatRate = "vatrate";
        }
    }
}
