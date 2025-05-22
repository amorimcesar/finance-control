using AutoMapper;
using FinanceControl.Communication.Requests;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
    }
    
    private void DomainToRequest()
    {
        
    }
}