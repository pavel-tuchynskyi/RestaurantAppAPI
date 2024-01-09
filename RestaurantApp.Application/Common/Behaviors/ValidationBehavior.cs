using FluentValidation;
using MediatR;
using RestaurantApp.Domain.Common.Exceptions;
using ValidationException = RestaurantApp.Application.Common.Exceptions.ValidationException;

namespace RestaurantApp.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }
            else
            {
                var compositeException = new CompositeException("Validation Error", 403, "Validation Errors", "Failed to validate form");

                foreach (var error in validationResult.Errors)
                {
                    compositeException.Push(new ValidationException(error.ErrorMessage));
                }

                throw compositeException;
            }
        }
    }
}
