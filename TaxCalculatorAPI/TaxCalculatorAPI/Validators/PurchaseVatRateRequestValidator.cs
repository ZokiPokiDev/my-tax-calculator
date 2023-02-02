using FluentValidation;
using TaxCalculatorAPI.Commands;

namespace TaxCalculatorAPI.Validators
{
    public sealed class PurchaseVatRateRequestValidator : AbstractValidator<PurchaseByVatRateAmountCommand>
    {
        public int[] VALID_VAT_RATES = { 10, 13, 20 };

        public PurchaseVatRateRequestValidator()
        {
            RuleFor(x => x.Net).Must(IsGraterThenZeroValue).WithMessage("Net amount value should be grather then 0!");
            RuleFor(x => x.Gross).Must(IsGraterThenZeroValue).WithMessage("Gross amount value should be grather then 0!");
            RuleFor(x => x.Vat).Must(IsGraterThenZeroValue).WithMessage("VAT amount value should be grather then 0!");
        }

        private bool IsGraterThenZeroValue(double value)
        {
            return value > 0;
        }
    }
}
