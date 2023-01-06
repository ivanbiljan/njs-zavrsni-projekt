using FluentValidation;
using MediatR;

namespace Njs.Core.Infrastructure.PipelineBehaviours;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults =
            await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));

        var errors = validationResults.Where(v => v.Errors.Any()).SelectMany(v => v.Errors);
        if (errors.Any())
        {
            throw new ValidationException(errors);
        }

        return await next();
    }
}