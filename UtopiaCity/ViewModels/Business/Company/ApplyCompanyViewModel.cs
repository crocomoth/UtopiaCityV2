using System.Collections.Generic;
using UtopiaCity.Models.Business.Dictionaries;

namespace UtopiaCity.ViewModels.Business.Company
{
    public class ApplyCompanyViewModel
    {
        public string Title { get; set; }
        public string FounderId { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyActivityId { get; set; }
        public List<CompanyType> CompanyTypes { get; set; }
        public List<CompanyActivity> CompanyActivities { get; set; }

        public ApplyCompanyViewModel()
        {
        }

        public ApplyCompanyViewModel(List<CompanyType> companyTypes, List<CompanyActivity> companyActivities, string userId)
        {
            FounderId = userId;
            CompanyTypes = companyTypes;
            CompanyActivities = companyActivities;
        }
    }
}
