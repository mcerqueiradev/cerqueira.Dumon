using System.Runtime.Serialization;

namespace cerqueira.Dumon.Domain.Core.Exceptions;

[Serializable]
public class DomainException : Exception
{
    public string ErrorCode { get; }
    public string UserFriendlyMessage { get; }

    public DomainException() { }

    public DomainException(string message) : base(message)
    {
        UserFriendlyMessage = message;
    }

    public DomainException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
        UserFriendlyMessage = message;
    }

    public DomainException(string message, Exception innerException) : base(message, innerException)
    {
        UserFriendlyMessage = message;
    }

    public DomainException(string message, string errorCode, Exception innerException)
        : base(message, innerException)
    {
        ErrorCode = errorCode;
        UserFriendlyMessage = message;
    }

    protected DomainException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        ErrorCode = info.GetString(nameof(ErrorCode));
        UserFriendlyMessage = info.GetString(nameof(UserFriendlyMessage));
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(ErrorCode), ErrorCode);
        info.AddValue(nameof(UserFriendlyMessage), UserFriendlyMessage);
    }

    public static void ThrowIfNull(object argument, string parameterName, string message = null)
    {
        if (argument is null)
        {
            throw new DomainException(
                message ?? $"Argument '{parameterName}' cannot be null",
                "ARGUMENT_NULL",
                new ArgumentNullException(parameterName)
            );
        }
    }

    public static void ThrowIfNullOrEmpty(string argument, string parameterName, string message = null)
    {
        if (string.IsNullOrEmpty(argument))
        {
            throw new DomainException(
                message ?? $"Argument '{parameterName}' cannot be null or empty",
                "ARGUMENT_NULL_OR_EMPTY",
                new ArgumentException(parameterName)
            );
        }
    }
}