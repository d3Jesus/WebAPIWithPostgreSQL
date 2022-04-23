using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithPostgreSQL.Models;

namespace WebAPIWithPostgreSQL.Interface
{
    public interface IProductModel
    {
        List<ProductModel> GetProducts();

        ProductModel GetProduct(Guid id);

        ProductModel CreateProduct(ProductModel productModel);

        ProductModel UpdateProduct(ProductModel productModel);

        void DeleteProduct(Guid id);
    }
}
