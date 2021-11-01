using AutoMapper;
using UtopiaCity.Models.FireDepartment;
using UtopiaCity.ViewModels.FireDepartment;

namespace UtopiaCity.MappingConfigurations.FireDepartment
{
    public class FireIncidentReportViewModelProfile : Profile
    {
        public FireIncidentReportViewModelProfile()
        {
            CreateMap<FireIncidentReport, FireIncidentReportViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(o => o.Address))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(o => o.AdditionalInfo))
                .ForMember(dest => dest.IncidentDate, opt => opt.MapFrom(o => o.IncidentDate));
        }
    }
}
