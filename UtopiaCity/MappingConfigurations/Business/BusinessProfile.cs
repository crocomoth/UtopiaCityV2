using AutoMapper;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Company;
using UtopiaCity.ViewModels.Business.Position;

namespace UtopiaCity.MappingConfigurations.Business
{
    public class BusinessProfile: Profile
    {
        public BusinessProfile()
        {
            ApplyCompanyMappings();
            ApplyPositionMappings();
        }

        private void ApplyCompanyMappings()
        {
            CreateMap<ApplyCompanyViewModel, Company>();
            CreateMap<Company, CompanyInfoViewModel>()
                .ForMember(ci => ci.CompanyType, s => s.MapFrom(c => c.CompanyType.Title))
                .ForMember(ci => ci.CompanyActivity, s => s.MapFrom(c => c.CompanyActivity.Title));
            CreateMap<Company, UpdateCompanyViewModel>()
                .ForMember(uc => uc.CompanyType, s => s.MapFrom(c => c.CompanyType.Title))
                .ForMember(uc => uc.CompanyActivity, s => s.MapFrom(c => c.CompanyActivity.Title));
            CreateMap<UpdateCompanyViewModel, Company>();
        }

        private void ApplyPositionMappings()
        {
            CreateMap<CreatePositionViewModel, Position>();
        }
    }
}
