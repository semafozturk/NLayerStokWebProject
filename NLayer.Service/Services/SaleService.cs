using AutoMapper;
using Nlayer.Core;
using Nlayer.Core.DTOs;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class SaleService : Service<Sale>, ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;
        public SaleService(IGenericRepository<Sale> repository, ISaleRepository saleRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<List<SalesWithProductDto>> GetSalesWithProduct()
        {
            var sales = await _saleRepository.GetSalesWithProduct();
            var salesDto = _mapper.Map<List<SalesWithProductDto>>(sales);
            return salesDto;
        }
    }
}
