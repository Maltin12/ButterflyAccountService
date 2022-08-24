using FluentValidation.Results;

namespace Butterfly.Account.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }
        public ValidationException()
            : base("One or more validation failures have occurrred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(x => x.PropertyName == propertyName)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}