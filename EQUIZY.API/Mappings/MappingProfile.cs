using AutoMapper;
using EQUIZY.API.Resources;
using EQUIZY.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EQUIZY.API.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<StateProvince, StateProvinceResource>().ReverseMap();
            CreateMap<StateProvince, SaveStateProvinceResource>().ReverseMap();
            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<Country, SaveCountryResource>().ReverseMap();
            CreateMap<Address, AddressResource>().ReverseMap();
            CreateMap<City, CityResource>().ReverseMap();
            CreateMap<AppUser, AppUserResource>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateResource>().ReverseMap();
            CreateMap<Address, SaveAddressResource>().ReverseMap();
            CreateMap<TypeAddress, TypeAddressResource>().ReverseMap();
            CreateMap<TypeEvaluation, TypeEvaluationResource>().ReverseMap();
            CreateMap<TopicEvaluation, TopicEvaluationResource>().ReverseMap();
            CreateMap<CategoryEvaluation, CategoryEvaluationResource>().ReverseMap();
            CreateMap<Evaluation, EvaluationResource>().ReverseMap();
            CreateMap<ProfessorEvaluationList, ProfessorEvaluationListResource>().ReverseMap();
            CreateMap<Composer, ComposerResource>()
                    .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id.ToString())).ReverseMap();
            CreateMap<Composer, SaveComposerResource>().ReverseMap();
            CreateMap<UserSignUpResource, AppUser>()
                    .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
