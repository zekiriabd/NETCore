using System.Collections.Generic;
using MecroECommerce.Products.Models;
using MecroECommerce.Products.Services;
using Microsoft.AspNetCore.Mvc;


namespace MecroECommerce.Products.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService _productService)
        {
            this.productService = _productService;
        }

        [HttpGet]
        [Route("api/products")]
        public List<ProductModel> GetProducts()
        {
            return productService.GetProducts();
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public ProductModel GetProductById(int id)
        {
            return productService.GetProductById(id);
        }

    }
}
