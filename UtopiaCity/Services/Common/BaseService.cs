using AutoMapper;
using UtopiaCity.Data;

namespace UtopiaCity.Services.Common
{
    public class BaseService
    {
        protected readonly AppDbContext _appDbContext;
        protected readonly IMapper _mapper;

        public BaseService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
    }
}