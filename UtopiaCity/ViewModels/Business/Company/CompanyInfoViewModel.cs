using System.Collections.Generic;

namespace UtopiaCity.ViewModels.Business.Company
{
    public class CompanyInfoViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyTypeId { get; set; }
        public string CompanyType { get; set; }
        public string CompanyActivityId { get; set; }
        public string CompanyActivity { get; set; }
        public List<Models.Business.Entities.Position> Positions { get; set; }
        public List<Models.Business.Entities.Vacancy> Vacancies { get; set; }
    }
}
