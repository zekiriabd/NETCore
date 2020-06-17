using MecroECommerce.Products.Models;
using MecroECommerce.Products.Persistence;

namespace MecroECommerce.Products.Mapper
{
    public class ProductMapper : AutoMapper.Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductModel>();            
        }
    }
}
