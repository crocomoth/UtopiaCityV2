﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.ViewModels.Business;

namespace UtopiaCity.Services.Business.Impl
{
    public class BusinessService: IBusinessService
    {
        private readonly AppDbContext _appDbContext;

        public BusinessService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IndexViewModel> CreateIndexViewModel()
        {
            var companiesAmount = await _appDbContext.Companies
                .Where(c => !c.IsDeleted)
                .CountAsync();
            return new IndexViewModel(companiesAmount);
        }
    }
}