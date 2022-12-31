namespace Njs.Core.Infrastructure.Exceptions;

public sealed class NjsException : Exception
{
    public NjsException(string message) : base(message)
    {
    }
    
    public NjsException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}