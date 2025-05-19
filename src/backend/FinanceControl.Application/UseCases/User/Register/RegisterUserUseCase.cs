using FinanceControl.Communication.Requests;
using FinanceControl.Communication.Responses;

namespace FinanceControl.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterJson request)
    {
        Validate(request);
        
        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage);
            throw new Exception();
        }
    }
}