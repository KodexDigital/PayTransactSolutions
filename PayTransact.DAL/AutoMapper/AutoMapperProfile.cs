using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PayTransact.Models.Models;
using PayTransact.Models.ViewModels;

namespace PayTransact.Persistence.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductViewModel, Product>();

            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(o => o.TelePhoneNumber))
                .ForMember(d => d.PasswordHash, s => s.MapFrom(o => o.Password))
                .ForMember(d => d.UserName, s => s.MapFrom(o => o.Email));

            CreateMap<InvestViewModel, Investment>();
        }
    }
}
