using System.Collections.Generic;

namespace UtopiaCity.ViewModels.Business.Vacancy
{
    public class CreateVacancyViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PositionId { get; set; }
        public List<Models.Business.Entities.Position> Positions { get; set; }

        public CreateVacancyViewModel()
        {

        }

        public CreateVacancyViewModel(List<Models.Business.Entities.Position> positions)
        {
            Positions = positions;
        }
    }
}
