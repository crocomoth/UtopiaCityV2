using System.Collections.Generic;

namespace UtopiaCity.ViewModels.Business.Company
{
    public class CompanyListViewModel
    {
        public List<Models.Business.Entities.Company> Companies { get; set; }

        public CompanyListViewModel(List<Models.Business.Entities.Company> companies)
        {
            Companies = companies;
        }
    }
}
