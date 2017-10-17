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
                    ProductId = prodIn.ProductId,
                    InInfoId = prodIn.InInfoId,
                    UnitId = prodIn.UnitId,
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
        public static int Save(List<ProductIn> prodIns, int iInfoId)
        {
            try
            {
                using (_d = new DataRepository<ProductIn>())
                {
                    foreach (var prodIn in prodIns)
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
                            ProductId = prodIn.ProductId,
                            InInfoId = iInfoId,
                            UnitId = prodIn.UnitId,
                        };
                        if (prodIn.ProductInId > 0)
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
        }
        public static List<ProductIn> GetAll(bool bActive, int iId)
        {
            using (_d = new DataRepository<ProductIn>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.Find(f => f.ProductInIsActive == bActive && f.InInfoId == iId).ToList();
            }
        }
    }
}