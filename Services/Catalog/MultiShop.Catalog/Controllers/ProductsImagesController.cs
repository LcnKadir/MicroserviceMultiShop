using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsImagesController : ControllerBase
    {
        private readonly IProductImageService _productsImageService;

        public ProductsImagesController(IProductImageService productsImageService)
        {
            _productsImageService = productsImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsImageList()
        {
            var values = await _productsImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsImageById(string id)
        {
            var values = await _productsImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsImage(CreateProductImageDto createProductsImageDto)
        {
            await _productsImageService.CreateProductImageAsync(createProductsImageDto);
            return Ok("Ürün görselleri başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductsImage(string id)
        {
            await _productsImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductsImage(UpdateProductImageDto updateProductsImageDto)
        {
            await _productsImageService.UpdateProductImageAsync(updateProductsImageDto);
            return Ok("Ürün görselleri başarıyla güncellendi");
        }
    }
}
