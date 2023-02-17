using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nlayer.Core;
using Nlayer.Core.DTOs;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using NLayer.Repository;

namespace NLayer.WEB.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService _service;
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        private readonly IExportDataRepository _expData;

        public SalesController(ISaleService service, AppDbContext dbContext, IMapper mapper, IExportDataRepository expData)
        {
            _service = service;
            _db = dbContext;
            _mapper = mapper;
            _expData = expData;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetSalesWithProduct());
        }

        [HttpGet]
        public async Task<IActionResult> AddWithoutID()
        {
            var productsDto = await _db.Products.ToListAsync();
            ViewBag.products = new SelectList(productsDto, "productId", "productName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWithoutID(SaleDto sale)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Sale>(sale));
                return RedirectToAction(nameof(Index));
            }
            var productsDto = await _db.Products.ToListAsync();
            ViewBag.products = new SelectList(productsDto, "productId", "productName");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int prodId)
        {
            var product = _mapper.Map<ProductDto>(_db.Products.Find(prodId));
            var productDto = _mapper.Map<SalesWithProductDto>(product);
            productDto.Product = product;
            var productsList = _db.Products.ToList();
            ViewBag.products = new SelectList(productsList, "productId", "productName");
            ViewBag.prodId = prodId;
            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(SaleDto sale)
        {
            if(ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Sale>(sale));
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var sale = await _service.GetByIdAsync(id);
            var saleDto = _mapper.Map<SaleDto>(sale);
            var productsDto = _db.Products.ToList();
            ViewBag.products = new SelectList(productsDto, "productId", "productName", sale.productId);
            return View(saleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SaleDto sale)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Sale>(sale));
                return RedirectToAction(nameof(Index));
            }
            var productsDto = _db.Products.ToList();
            ViewBag.products = new SelectList(productsDto, "productId", "productName", sale.productId);
            return View(sale);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.RemoveAsync(await _service.GetByIdAsync(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Report()
        {
            var arraylist = _expData.ExportCustomer();

            using (var xl = new XLWorkbook())
            {
                var worksheet = xl.Worksheets.Add(arraylist);

                int n= worksheet.Rows().Count();

                string totalColumnLetter = worksheet.Column(6).ColumnLetter();
                string subTotalFormula = $"=SUM({totalColumnLetter}2:{totalColumnLetter}{n})";

                //worksheet.Cell(n + 1, 6).SetFormulaA1(subTotalFormula).Style.Font.SetFontSize(12);
                worksheet.Cell(n + 1, 6).Style.Font.SetBold();
                worksheet.Column(2).Cells(2, n).Style.DateFormat.SetFormat("dd/MM/yyyy hh:mm");
                

                // tüm formülleri hesaplatıyoruz
                worksheet.RecalculateAllFormulas();

                // sütunların içeriğe göre otomatik genişletilmesini sağlıyoruz
                worksheet.Columns().AdjustToContents();

                using (MemoryStream mstream = new MemoryStream())
                {
                    xl.SaveAs(mstream);
                    return File(mstream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Customer.xlsx");
                }
            }
        }


    }
}
