using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options){ }
        public DbSet<ProductDetails> Products { get; set; }
    }
}
