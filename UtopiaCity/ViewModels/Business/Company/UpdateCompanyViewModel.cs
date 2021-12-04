using System.Collections.Generic;
using UtopiaCity.Models.Business.Dictionaries;

namespace UtopiaCity.ViewModels.Business.Company
{
    public class UpdateCompanyViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyType { get; set; }
        public string CompanyActivityId { get; set; }
        public string CompanyActivity { get; set; }
        public List<CompanyType> CompanyTypes { get; set; }
        public List<CompanyActivity> CompanyActivities { get; set; }
    }
}
