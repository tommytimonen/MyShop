using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> _products;

        public ProductRepository()
        {
            _products = cache["products"] as List<Product>;

            if (_products == null)
                _products = new List<Product>();
        }

        public void Commit()
        {
            cache["products"] = _products;
        }

        public void Insert(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.Find(p => p.Id == product.Id);

            if(productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string Id)
        {
            var product = _products.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return _products.AsQueryable();
        }

        public void Delete(string Id)
        {
            var productToDelete = _products.Find(p => p.Id == Id);

            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

    }
}
