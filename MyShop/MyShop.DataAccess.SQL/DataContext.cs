using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()

            // Means that DbContext will look in our web.Config for the connection string setting.
            // Note: copied the connection string setting to App.config in the MyShop.DataAccess.SQL project as well.
            // EF will look in both files for the setting.
            : base("DefaultConnection") 
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}
