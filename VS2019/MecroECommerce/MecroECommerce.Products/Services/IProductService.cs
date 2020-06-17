
using System.Collections.Generic;

using MecroECommerce.Products.Models;

namespace MecroECommerce.Products.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
        ProductModel GetProductById(int id);

    }
}
