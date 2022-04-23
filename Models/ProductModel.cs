using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithPostgreSQL.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
