using AutoMapper;
using FinanceControl.Application.Services.AutoMapper;
using FinanceControl.Application.Services.Cryptography;
using FinanceControl.Communication.Requests;
using FinanceControl.Communication.Responses;
using FinanceControl.Domain.Repositories;
using FinanceControl.Domain.Repositories.User;
using FinanceControl.Exceptions.ExceptionsBase;

namespace FinanceControl.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IWorkUnity _workUnity;
    private readonly IMapper _mapper;
    private readonly PasswordEncrypter _passwordEncrypter;

    public RegisterUserUseCase(
        IUserWriteOnlyRepository writeOnlyRepository, 
        IUserReadOnlyRepository readOnlyRepository,
        IWorkUnity workUnity,
        IMapper mapper, 
        PasswordEncrypter passwordEncrypter)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _workUnity = workUnity;
        _mapper = mapper;  
        _passwordEncrypter = passwordEncrypter;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);
        
        user.Password = _passwordEncrypter.Encrypt(request.Password);
        
        await _writeOnlyRepository.Add(user);
        await _workUnity.Commit();
        
        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}