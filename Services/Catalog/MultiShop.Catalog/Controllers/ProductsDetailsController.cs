using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductsDetailService;

        public ProductsDetailsController(IProductDetailService ProductsDetailService)
        {
            _ProductsDetailService = ProductsDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsDetailList()
        {
            var values = await _ProductsDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetailById(string id)
        {
            var values = await _ProductsDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsDetail(CreateProductDetailDto createProductsDetailDto)
        {
            await _ProductsDetailService.CreateProductDetailAsync(createProductsDetailDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductsDetail(string id)
        {
            await _ProductsDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductsDetail(UpdateProductDetailDto updateProductsDetailDto)
        {
            await _ProductsDetailService.UpdateProductDetailAsync(updateProductsDetailDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
