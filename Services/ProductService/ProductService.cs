using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithPostgreSQL.Db;
using WebAPIWithPostgreSQL.Interface;
using WebAPIWithPostgreSQL.Models;

namespace WebAPIWithPostgreSQL.Services.ProductService
{
    public class ProductService : IProductModel
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ProductModel CreateProduct(ProductModel productModel)
        {
            _dbContext.ProductModels.Add(productModel);
            _dbContext.SaveChanges();
            return productModel;
        }
        public void DeleteProduct(Guid id)
        {
            var prd = _dbContext.ProductModels.Where(x => x.ProductId == id).FirstOrDefault();
            if(prd != null)
            {
                _dbContext.ProductModels.Attach(prd);
                _dbContext.ProductModels.Remove(prd);
                _dbContext.SaveChanges();
            }
        }
        public ProductModel GetProduct(Guid id)
        {
            return _dbContext.ProductModels.Where(x => x.ProductId == id).FirstOrDefault();
        }
        public List<ProductModel> GetProducts()
        {
            return _dbContext.ProductModels.ToList();
        }
        public ProductModel UpdateProduct(ProductModel productModel)
        {
            var prd = _dbContext.ProductModels.Where(x => x.ProductId == productModel.ProductId).FirstOrDefault();
            if (prd != null)
            {
                prd.ProductName = productModel.ProductName;
                _dbContext.SaveChanges();
            }
            return productModel;
        }
    }
}
