using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithPostgreSQL.Interface;
using WebAPIWithPostgreSQL.Models;

namespace WebAPIWithPostgreSQL.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductModel _productModel;

        public ProductController(IProductModel productModel)
        {
            _productModel = productModel;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts()
        {
            return Ok(_productModel.GetProducts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid id)
        {
            var prd = _productModel.GetProduct(id);
            if(prd != null)
                return Ok(prd);

            return NotFound($"Product with id: {id} not found!");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateProduct(ProductModel product)
        {
            var prd = _productModel.CreateProduct(product);
            return Created(HttpContext.Request.Scheme + "://" +
                HttpContext.Request.Host + HttpContext.Request.Path + "/" + prd.ProductId,
                prd);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var prd = _productModel.GetProduct(id);
            if(prd != null)
            {
                _productModel.DeleteProduct(id);
                return Ok("Product deleted successfully!");
            }

            return NotFound($"Product with id: {id} not found!");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult UpdateProduct(Guid id, ProductModel model)
        {
            var prd = _productModel.GetProduct(id);
            if(prd != null)
            {
                model.ProductId = prd.ProductId;
                _productModel.UpdateProduct(model);
                return Ok("Product updated successfully!");
            }

            return NotFound($"Product with id: {id} not found!");
        }
    }
}
