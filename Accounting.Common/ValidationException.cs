namespace Accounting.Common;

public class ValidationException : ExceptionBase
{
    public ValidationException(ErrorCode errorCode) : base(errorCode)
    {
    }

    public ValidationException(ErrorCode errorCode, string? message) :
        base(errorCode, message)
    {
    }

    public ValidationException(ErrorCode errorCode, string? message,
        Exception? innerException) : base(errorCode, message, innerException)
    {
    }
}
