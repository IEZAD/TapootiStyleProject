using AutoMapper;
using AccountManagment.Domain.AccountAgg;
using AccountManagment.Application.Contracts.Account;

namespace AccountManagement.Configuration.MappingProfile
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountViewModelResponse>().ReverseMap();
        }
    }
}