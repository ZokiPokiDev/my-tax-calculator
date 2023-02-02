using FluentValidation.Results;

namespace TaxCalculatorAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public NotFoundException() : base()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public NotFoundException(string message) : base(message)
        {
            Errors = new Dictionary<string, string[]>
            {
                { "error", new[] { message } }
            };
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            Errors = new Dictionary<string, string[]>
            {
                { "error", new[] { message } }
            };
        }

        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
            Errors = new Dictionary<string, string[]>
            {
                { "error", new[] { name } }
            };
        }

        public NotFoundException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
