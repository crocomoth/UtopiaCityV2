using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Vacancy;

namespace UtopiaCity.Services.Business.Impl
{
    public class VacancyService: IVacancyService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public VacancyService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<CreateVacancyViewModel> CreateCreateVacancyViewModel(string companyId)
        {
            var companyPositions = await _appDbContext.Positions
                .Where(p => p.CompanyId == companyId)
                .ToListAsync();

            return new CreateVacancyViewModel(companyPositions);
        }

        public async Task CreateVacancy(CreateVacancyViewModel createVacancyViewModel)
        {
            var newVacancy = _mapper.Map<Vacancy>(createVacancyViewModel);
            _appDbContext.Add(newVacancy);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteVacancy(string vacancyId)
        {
            var vacancy = await _appDbContext.Vacancies.FirstOrDefaultAsync(v => v.Id == vacancyId);
            vacancy.IsDeleted = true;
            _appDbContext.Update(vacancy);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
