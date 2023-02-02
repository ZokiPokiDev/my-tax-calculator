using FluentValidation.Results;

namespace TaxCalculatorAPI.Exceptions
{
    public class BadRequestException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public BadRequestException() : base("Value is not valid")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public BadRequestException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
