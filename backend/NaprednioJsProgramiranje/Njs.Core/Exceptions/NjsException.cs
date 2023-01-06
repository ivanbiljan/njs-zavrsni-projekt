namespace Njs.Core.Exceptions;

public sealed class NjsException : Exception
{
    public NjsException(string message) : base(message)
    {
    }
    
    public NjsException(string message, IDictionary<string, IEnumerable<string>> errors) : base(message)
    {
        Errors = errors;
    }
    
    public NjsException(string message, Exception? innerException) : base(message, innerException)
    {
    }

    public IDictionary<string, IEnumerable<string>> Errors { get; } = new Dictionary<string, IEnumerable<string>>();
}