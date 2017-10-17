using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class ProductOutManager
    {
        public static DataRepository<ProductOut> _d;

        public static int Save(ProductOut prodOut)
        {
            var a = new ProductOut
            {
                ProductOutId = prodOut.ProductOutId,
                ProductOutQnty = prodOut.ProductOutQnty,
                ProductOutPrice = prodOut.ProductOutPrice,
                ProductOutIsActive = prodOut.ProductOutIsActive,
                ProductInId = prodOut.ProductInId,
                OutInfoId = prodOut.OutInfoId
            };
            using (_d = new DataRepository<ProductOut>())
            {
                if (prodOut.ProductOutId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.ProductOutId;
        }
        public static int Save(List<ProductOut> products, int iPOid)
        {
            try
            {
                using (_d = new DataRepository<ProductOut>())
                {
                    foreach (var product in products)
                    {
                        var a = new ProductOut
                        {
                            ProductOutId = product.ProductOutId,
                            ProductInId = product.ProductInId,
                            ProductOutIsActive = product.ProductOutIsActive,
                            ProductOutPrice = product.ProductOutPrice,
                            ProductOutQnty = product.ProductOutQnty,
                            OutInfoId = iPOid
                        };
                        if (product.ProductOutId > 0)
                            _d.Update(a);
                        else
                            _d.Add(a);
                    }
                    _d.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public static bool Delete(ProductOut prodOut)
        {
            using (_d = new DataRepository<ProductOut>())
            {
                _d.Delete(prodOut);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<ProductOut>())
            {
                _d.Delete(d => d.ProductOutId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<ProductOut> GetAll()
        {
            using (_d = new DataRepository<ProductOut>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
    }
}