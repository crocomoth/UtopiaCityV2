using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using UtopiaCity.Data;
using UtopiaCity.Dtos.Business;
using UtopiaCity.Models.Business.Entities;

namespace UtopiaCity.Services.Business
{
    public class CompanyService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public CompanyService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyDto createCompanyDto, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(createCompanyDto);
            _appDbContext.Companies.Add(company);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}