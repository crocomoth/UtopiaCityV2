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

        public async Task<CompanyInfoViewModel> GetCompanyInfo(string companyId)
        {
            var company = await _appDbContext.Companies
                .Include(c => c.CompanyType)
                .Include(c => c.CompanyActivity)
                .FirstOrDefaultAsync(c => c.Id == companyId);
            var companyInfoViewModel = _mapper.Map<CompanyInfoViewModel>(company);
            return companyInfoViewModel;
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

        public async Task<UpdateCompanyViewModel> CreateUpdateCompanyViewModel(string companyId)
        {
            var company = await _appDbContext.Companies
                .Include(c => c.CompanyType)
                .Include(c => c.CompanyActivity)
                .FirstOrDefaultAsync(c => c.Id == companyId);
            var updateCompanyViewModel = _mapper.Map<UpdateCompanyViewModel>(company);
            updateCompanyViewModel.CompanyTypes = await _appDbContext.CompanyTypes.ToListAsync();
            updateCompanyViewModel.CompanyActivities = await _appDbContext.CompanyActivities.ToListAsync();
            return updateCompanyViewModel;
        }        

        public async Task UpdateCompany(UpdateCompanyViewModel updateCompanyViewModel)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(c => c.Id == updateCompanyViewModel.Id);
            company.Title = updateCompanyViewModel.Title;
            var companyType = await _appDbContext.CompanyTypes.FirstOrDefaultAsync(c => c.Id == updateCompanyViewModel.CompanyTypeId);
            var companyActivity = await _appDbContext.CompanyActivities.FirstOrDefaultAsync(c => c.Id == updateCompanyViewModel.CompanyActivityId);
            company.CompanyType = companyType;
            company.CompanyActivity = companyActivity;
            _appDbContext.Update(company);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task ApplyDeleteCompany(string companyId)
        {
            await DeleteCompany(companyId);
        }

        public async Task DeleteCompany(string companyId)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(c => c.Id == companyId);
            _appDbContext.Remove(company);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
