using FluentValidation;
using TaxCalculatorAPI.Commands;

namespace TaxCalculatorAPI.Validators
{
    public sealed class PurchaseGrossRequestValidator : AbstractValidator<PurchaseByGrossAmountCommand>
    {
        public int[] VALID_VAT_RATES = { 10, 13, 20 };

        public PurchaseGrossRequestValidator()
        {
            RuleFor(x => x.Gross).Must(IsGraterThenZeroValue).WithMessage("Gross amount value should be grather then 0!");
            RuleFor(x => x.VatRate).Must(IsValidVatRate).WithMessage("VAT rate value should be valid Austrian value like: 10, 13 or 20!");
        }

        private bool IsGraterThenZeroValue(double value)
        {
            return value > 0;
        }

        private bool IsValidVatRate(double vatRate)
        {
            return Array.Exists(VALID_VAT_RATES, element => element == vatRate);
        }
    }
}
