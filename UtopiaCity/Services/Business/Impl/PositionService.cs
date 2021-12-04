﻿using AutoMapper;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.Business.Entities;
using UtopiaCity.ViewModels.Business.Position;

namespace UtopiaCity.Services.Business.Impl
{
    public class PositionService: IPositionService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public PositionService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task CreatePosition(CreatePositionViewModel createPositionViewModel)
        {
            var newPosition = _mapper.Map<Position>(createPositionViewModel);
            _appDbContext.Add(newPosition);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
