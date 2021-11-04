using AutoMapper;
using UtopiaCity.Models.FireDepartment;
using UtopiaCity.ViewModels.FireDepartment;

namespace UtopiaCity.MappingConfigurations.FireDepartment
{
    public class FireIncidentReportProfile : Profile
    {
        public FireIncidentReportProfile()
        {
            CreateMap<CreateFireIncidentReportViewModel, FireIncidentReport>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(o => o.Address))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(o => o.AdditionalInfo))
                .ForMember(dest => dest.EyewitnessId, opt => opt.MapFrom(o => o.EyewitnessId));
        }
    }
}
