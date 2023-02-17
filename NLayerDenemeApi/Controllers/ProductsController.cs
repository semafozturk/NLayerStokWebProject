using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nlayer.Core;
using Nlayer.Core.DTOs;
using Nlayer.Core.Services;

namespace NLayerDenemeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return  Ok(await _service.GetProductsWithCategory());
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var productAdded = await _service.AddAsync(_mapper.Map<Product>(product));
            var productDto = _mapper.Map<ProductDto>(productAdded);
            var asd = await _service.GetProductsWithCategory();
            return Ok(product);
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto product)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(product));
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return Ok();

        }
    }
}
