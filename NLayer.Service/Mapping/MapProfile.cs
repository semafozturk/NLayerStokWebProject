using AutoMapper;
using Nlayer.Core;
using Nlayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Product, ProductsWithCategoryDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Sale, SalesWithProductDto>();
            CreateMap<ProductDto, SalesWithProductDto>().ReverseMap();
        }
    }
}
