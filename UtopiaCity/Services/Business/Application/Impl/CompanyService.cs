using System.Threading.Tasks;
using AutoMapper;
using UtopiaCity.Data;
using UtopiaCity.Dtos.Business.Company;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.Services.Common;

namespace UtopiaCity.Services.Business.Application.Impl
{
    public class CompanyService: BaseService, ICompanyService
    {
        public CompanyService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }

        public async Task ApplyCompany(ApplyCompanyDto applyCompanyDto)
        {
            // TODO call application registration service to create company application
        }
        
        public async Task CreateCompany(CreateCompanyDto createCompanyDto)
        {
            var company = _mapper.Map<Company>(createCompanyDto);
            _appDbContext.Add(company);
            await _appDbContext.SaveChangesAsync(createCompanyDto.CancellationToken);
        }
    }
}