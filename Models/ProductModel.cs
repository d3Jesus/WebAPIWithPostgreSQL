using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithPostgreSQL.Models
{
    [Table("Product")]
    public class ProductModel
    {
        [Key]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
