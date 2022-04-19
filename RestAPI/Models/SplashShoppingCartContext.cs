using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class SplashShoppingCartContext : DbContext
    {
        public SplashShoppingCartContext(DbContextOptions<SplashShoppingCartContext> options)
            : base(options)
        {
        }
        public DbSet<Page> Pages { get; set; }
       
    }
}
