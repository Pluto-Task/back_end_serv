using System.Security.Cryptography.X509Certificates;
using Application.ResponseApiModel;
using AutoMapper;
using Domain.Entity;

namespace Application;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Transaction, TransactionResponseApiModel>();

        CreateMap<Credit, CreditResponseApiModel>()
            .ForMember(opt => opt.ExpectedSum, cd => cd.MapFrom(map => map.Sum * map.Percentage / 100))
            .ForMember(opt => opt.MonthlySum, cd => cd.MapFrom(map => map.Sum * map.Percentage / 100 / map.MonthQuantity));

        CreateMap<Account, AccountResponseApiModel>()
            .ConstructUsing(map => new AccountResponseApiModel(map.Id, map.Name, map.Money))
            ;
    }
}