using AutoMapper;
using MecroECommerce.Products.Models;
using MecroECommerce.Products.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace MecroECommerce.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext productDbContext;
        private readonly IMapper mapper;
        public ProductService(ProductDbContext _productDbContext, IMapper _mapper)
        {
            this.productDbContext = _productDbContext;
            this.mapper = _mapper;
        }
        public List<ProductModel> GetProducts()
        {
            return mapper.Map<List<ProductModel>>(productDbContext.Products.ToList());
        }

        public ProductModel GetProductById(int id)
        {
            return mapper.Map<ProductModel>(productDbContext.Products.FirstOrDefault(x => x.Id == id));
        }

    }
}
