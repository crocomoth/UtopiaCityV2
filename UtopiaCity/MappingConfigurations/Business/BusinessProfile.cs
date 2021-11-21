using AutoMapper;
using UtopiaCity.Dtos.Business.Company;
using UtopiaCity.Models.Business.Entities;

namespace UtopiaCity.MappingConfigurations.Business
{
    public class BusinessProfile: Profile
    {
        public BusinessProfile()
        {
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<CreatePositionDto, Position>();
            CreateMap<CreateEmploymentDto, Employment>();
        }
    }
}