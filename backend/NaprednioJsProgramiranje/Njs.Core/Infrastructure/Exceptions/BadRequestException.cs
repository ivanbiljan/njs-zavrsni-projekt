﻿namespace Njs.Core.Infrastructure.Exceptions;

public sealed class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
    }
    
    public BadRequestException(string message, Exception? innerException) : base(message, innerException)
    {
    }
}