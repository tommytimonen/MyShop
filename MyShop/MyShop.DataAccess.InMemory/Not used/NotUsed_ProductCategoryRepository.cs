using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{  
    /*************************************************************************
    
        This class is no longer used since we added the generic class InMemoryRepository

    *************************************************************************/

    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> _productCategories;

        public ProductCategoryRepository()
        {
            _productCategories = cache["productCategories"] as List<ProductCategory>;

            if (_productCategories == null)
                _productCategories = new List<ProductCategory>();
        }

        public void Commit()
        {
            cache["productCategories"] = _productCategories;
        }

        public void Insert(ProductCategory productCategory)
        {
            _productCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            var productCategoryToUpdate = _productCategories.Find(p => p.Id == productCategory.Id);

            if (productCategoryToUpdate != null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            var product = _productCategories.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return _productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            var productCategoryToDelete = _productCategories.Find(p => p.Id == Id);

            if (productCategoryToDelete != null)
            {
                _productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

    }
    
}
