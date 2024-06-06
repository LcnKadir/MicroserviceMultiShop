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
        private readonly IProductImageService _ProductsImageService;

        public ProductsImagesController(IProductImageService ProductsImageService)
        {
            _ProductsImageService = ProductsImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsImageList()
        {
            var values = await _ProductsImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsImageById(string id)
        {
            var values = await _ProductsImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductsImage(CreateProductImageDto createProductsImageDto)
        {
            await _ProductsImageService.CreateProductImageAsync(createProductsImageDto);
            return Ok("Ürün görselleri başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductsImage(string id)
        {
            await _ProductsImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görselleri başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductsImage(UpdateProductImageDto updateProductsImageDto)
        {
            await _ProductsImageService.UpdateProductImageAsync(updateProductsImageDto);
            return Ok("Ürün görselleri başarıyla güncellendi");
        }
    }
}
