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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductService(IGenericRepository<Product> repository,IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductsWithCategoryDto>> GetProductsWithCategory()
        {
            var products=await _productRepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductsWithCategoryDto>>(products);
            return productsDto;
        }
    }
}
