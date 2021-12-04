namespace UtopiaCity.ViewModels.Business.Position
{
    public class CreatePositionViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CompanyId { get; set; }

        public CreatePositionViewModel()
        {

        }

        public CreatePositionViewModel(string companyId)
        {
            CompanyId = companyId;
        }
    }
}
