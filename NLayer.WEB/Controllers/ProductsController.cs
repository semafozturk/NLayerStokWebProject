using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nlayer.Core;
using Nlayer.Core.DTOs;
using Nlayer.Core.Services;
using NLayer.Repository;
using NLayer.Service.Paging;

namespace NLayer.WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, AppDbContext dbContext, IMapper mapper)
        {
            _service = service;
            _db = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _db.Categories.ToListAsync();
            ViewBag.categories = new SelectList(categoriesDto, "categoryId", "categoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = await _db.Categories.ToListAsync();
            ViewBag.categories = new SelectList(categoriesDto, "categoryId", "categoryName");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            pageNumber = pageNumber == null ? 1 : pageNumber;
            int pageSize = 3;
            var allProducts = await _service.GetProductsWithCategory();
            return View(await PaginatedList<ProductsWithCategoryDto>.CreateAsync(allProducts, pageNumber ?? 1, pageSize));
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            var categoriesDto = _db.Categories.ToList();
            ViewBag.categories = new SelectList(categoriesDto, "categoryId", "categoryName", product.categoryId);
            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto product)
        {
            if(ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Product>(product));
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = _db.Categories.ToList();
            ViewBag.categories = new SelectList(categoriesDto, "categoryId", "categoryName", product.categoryId);
            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(await _service.GetByIdAsync(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
