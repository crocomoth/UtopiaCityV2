namespace UtopiaCity.ViewModels.Business
{
    public class IndexViewModel
    {
        public int CompaniesAmount { get; set; }
        public int EmployeesAmount { get; set; }
        public int VacanciesAmount { get; set; }

        public IndexViewModel()
        {

        }

        public IndexViewModel(int companiesAmount)
        {
            CompaniesAmount = companiesAmount;
        }
    }
}
