using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreatePosition(CreatePositionDto createPositionDto)
        {
            var company = await _appDbContext.Companies
                .FirstOrDefaultAsync(c => c.Id == createPositionDto.CompanyId);

            if (company == null)
            {
                throw new Exception($"{this} couldn't find the company.");
            }

            _appDbContext.Add(_mapper.Map<Position>(createPositionDto));

            await _appDbContext.SaveChangesAsync(createPositionDto.CancellationToken);
        }

        public async Task CreateEmployment(CreateEmploymentDto createEmploymentDto)
        {
            var position = await _appDbContext.Positions
                .FirstOrDefaultAsync(p => p.Id == createEmploymentDto.PositionId);

            if (position == null)
            {
                throw new Exception("{this} couldn't find the position");
            }
            
            var person = await _appDbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == createEmploymentDto.PersonId);

            if (person == null)
            {
                throw new Exception("{this} couldn't find the person");
            }
            
            _appDbContext.Add(_mapper.Map<Employment>(createEmploymentDto));

            await _appDbContext.SaveChangesAsync(createEmploymentDto.CancellationToken);
        }
    }
}