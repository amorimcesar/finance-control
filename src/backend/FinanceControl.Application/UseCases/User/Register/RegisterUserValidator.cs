using FinanceControl.Communication.Requests;
using FluentValidation;
using FinanceControl.Exceptions;

namespace FinanceControl.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourcesMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourcesMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourcesMessagesException.INVALID_EMAIL);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourcesMessagesException.INVALID_PASSWORD);
    }
}