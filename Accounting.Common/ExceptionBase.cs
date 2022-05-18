namespace Accounting.Common;

public abstract class ExceptionBase : ApplicationException
{
    public ErrorCode ErrorCode { get; }

    protected ExceptionBase(ErrorCode errorCode)
    {
        ErrorCode = errorCode;
    }

    protected ExceptionBase(ErrorCode errorCode, string? message) :
        base(message)
    {
        ErrorCode = errorCode;
    }

    protected ExceptionBase(ErrorCode errorCode, string? message,
        Exception? innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }
}
