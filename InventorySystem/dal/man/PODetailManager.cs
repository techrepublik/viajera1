using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.data;

namespace InventorySystem.dal.man
{
    class PODetailManager
    {
        public static DataRepository<PODetail> _d;
        public static int Save(PODetail poDetail)
        {
            var a = new PODetail
            {
                PODetailId = poDetail.PODetailId,
                PODetailQnty = poDetail.PODetailQnty,
                PurchaseOrderId = poDetail.PurchaseOrderId,
                ProductId = poDetail.ProductId
            };
            using (_d = new DataRepository<PODetail>())
            {
                if (poDetail.PODetailId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.PODetailId;
        }
        public static int Save(List<PODetail> poDetails, int iPOid)
        {
            try
            {
                using (_d = new DataRepository<PODetail>())
                {
                    foreach (var poDetail in poDetails)
                    {
                        var a = new PODetail
                        {
                            PODetailId = poDetail.PODetailId,
                            PODetailQnty = poDetail.PODetailQnty,
                            PurchaseOrderId = iPOid,
                            ProductId = poDetail.ProductId,
                            UnitId = poDetail.UnitId
                        };
                        if (poDetail.PODetailId > 0)
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
        public static bool Delete(PODetail poDetail)
        {
            using (_d = new DataRepository<PODetail>())
            {
                _d.Delete(poDetail);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<PODetail>())
            {
                _d.Delete(d => d.PODetailId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<PODetail> GetAll(int iPOId)
        {
            using (_d = new DataRepository<PODetail>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.Find(f => f.PurchaseOrderId == iPOId).ToList();
            }
        }
        
    }
}
