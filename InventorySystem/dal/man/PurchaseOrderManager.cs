using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class PurchaseOrderManager
    {
        public static DataRepository<PurchaseOrder> _d;

        public static int Save(PurchaseOrder pOrder)
        {
            var a = new PurchaseOrder
            {
                PurchaseOrderId = pOrder.PurchaseOrderId,
                PurchaseOrderDate = pOrder.PurchaseOrderDate,
                PurchaseOrderNo = pOrder.PurchaseOrderNo,
                PurchaseOrderNote = pOrder.PurchaseOrderNote,
                PurchaseOrderIsActive = pOrder.PurchaseOrderIsActive,
                ProductId = pOrder.ProductId
            };
            using (_d = new DataRepository<PurchaseOrder>())
            {
                if (pOrder.PurchaseOrderId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.PurchaseOrderId;
        }
        public static bool Delete(PurchaseOrder pOrder)
        {
            using (_d = new DataRepository<PurchaseOrder>())
            {
                _d.Delete(pOrder);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<PurchaseOrder>())
            {
                _d.Delete(d => d.PurchaseOrderId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<PurchaseOrder> GetAll()
        {
            using (_d = new DataRepository<PurchaseOrder>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
    }
}
