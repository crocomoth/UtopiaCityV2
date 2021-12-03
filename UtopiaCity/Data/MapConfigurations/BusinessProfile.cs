using AutoMapper;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Data.MapConfigurations
{
    public class BusinessProfile: Profile
    {
        public BusinessProfile()
        {
            CreateMap<ApplyCompanyViewModel, Company>();
        }
    }
}
