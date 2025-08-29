using cerqueira.Dumon.Domain.Core.Common;

namespace cerqueira.Dumon.Domain.Core.Exceptions;

public class ValidationException : DomainException
{
    public IEnumerable<ValidationError> Errors { get; }

    public ValidationException(IEnumerable<ValidationError> errors)
        : base("Validation failed: " + string.Join(", ", errors.Select(e => e.Message)))
    {
        Errors = errors;
    }

    public ValidationException(string message, string propertyName)
        : base(message)
    {
        Errors = new[] { new ValidationError(message, propertyName) };
    }
}