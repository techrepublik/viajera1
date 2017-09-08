using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class ProductInManager
    {
        public static DataRepository<ProductIn> _d;
        public static int Save(ProductIn prodIn)
        {
                var a = new ProductIn
                {
                    ProductInId = prodIn.ProductInId,
                    ProductInReceiptNo = prodIn.ProductInReceiptNo,
                    ProductInDate = prodIn.ProductInDate,
                    ProductInQnty = prodIn.ProductInQnty,
                    ProductInPrice = prodIn.ProductInPrice,
                    ProductInExpiryDate = prodIn.ProductInExpiryDate,
                    ProductInIsActive = prodIn.ProductInIsActive,
                    ProductId = prodIn.ProductId
                };
                using (_d = new DataRepository<ProductIn>())
                {
                    if (prodIn.ProductInId > 0)
                        _d.Update(a);
                    else
                        _d.Add(a);
                    _d.SaveChanges();
                }
                return a.ProductInId;
        }
        public static bool Delete(ProductIn prodIn)
        {
            using (_d = new DataRepository<ProductIn>())
            {
                _d.Delete(prodIn);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<ProductIn>())
            {
                _d.Delete(d => d.ProductInId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<ProductIn> GetAll()
        {
            using (_d = new DataRepository<ProductIn>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        //}
        //public static List<ProductIn> GetAll(bool bActive)
        //{
        //    using (_d = new DataRepository<ProductIn>())
        //    {
        //        _d.LazyLoadingEnabled = false;
        //        return _d.Find(f => f.ProductInIsActive == bActive)
        //            .OrderBy(o => o.ProductInReceiptNo).ThenBy(o => o.ProductInPrice).ToList();
        //    }
        }
    }
}