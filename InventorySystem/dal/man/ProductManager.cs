using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class ProductManager
    {
        public static DataRepository<Product> _d;
        public static int Save(Product prod)
        {
            var a = new Product
            {
                ProductId = prod.ProductId,
                ProductCode = prod.ProductCode,
                ProductName = prod.ProductName,
                ProductLevel = prod.ProductLevel,
                ProductIsActive = prod.ProductIsActive,
                SupplierId = prod.SupplierId,
                UnitId = prod.UnitId,
                CategoryId = prod.CategoryId

            };
            using (_d = new DataRepository<Product>())
            {
                if (prod.ProductId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.ProductId;
        }
        public static bool Delete(Product prod)
        {
            using (_d = new DataRepository<Product>())
            {
                _d.Delete(prod);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Product>())
            {
                _d.Delete(d => d.ProductId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<Product> GetAll()
        {
            using (_d = new DataRepository<Product>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
        public static List<Product> GetAll(bool bActive)
        {
            using (_d = new DataRepository<Product>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.Find(f => f.ProductIsActive == bActive)
                    .OrderBy(o => o.ProductName).ThenBy(o => o.ProductDescription ).ToList();
            }
        }
    }
}