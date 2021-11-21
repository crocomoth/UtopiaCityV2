using AutoMapper;
using UtopiaCity.Dtos.Business;
using UtopiaCity.Models.Business.Entities;

namespace UtopiaCity.MappingConfigurations
{
    public class Business: Profile
    {
        public Business()
        {
            #region Company
            
            CreateMap<CreateCompanyDto, Company>();
            
            #endregion
        }
    }
}