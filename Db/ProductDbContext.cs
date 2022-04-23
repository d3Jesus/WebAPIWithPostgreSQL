using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithPostgreSQL.Models;

namespace WebAPIWithPostgreSQL.Db
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options){}

        public DbSet<ProductModel> ProductModels { get; set; }
    }
}
