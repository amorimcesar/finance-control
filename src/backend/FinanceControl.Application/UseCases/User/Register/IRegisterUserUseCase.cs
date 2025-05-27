using FinanceControl.Communication.Requests;
using FinanceControl.Communication.Responses;

namespace FinanceControl.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}