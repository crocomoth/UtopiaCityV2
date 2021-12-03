using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Company;

namespace UtopiaCity.Services.Business.Impl
{
    public class CompanyService: ICompanyService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ApplyCompanyViewModel> CreateApplyCompanyViewModel()
        {
            var companyTypes = await _appDbContext.CompanyTypes.ToListAsync();
            var companyActivities = await _appDbContext.CompanyActivities.ToListAsync();
            return new ApplyCompanyViewModel(companyTypes, companyActivities);
        }

        public async Task ApplyCompany(ApplyCompanyViewModel applyCompanyViewModel)
        {
            var company = _mapper.Map<Company>(applyCompanyViewModel);
            await CreateCompany(company);
        }

        public async Task CreateCompany(Company company)
        {
            _appDbContext.Add(company);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
