using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class SupplierManager
    {
        public static DataRepository<Supplier> _d;
        public static int Save(Supplier supplier)
        {
            var a = new Supplier
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                SupplierAddress = supplier.SupplierAddress,
                SupplierContactNo = supplier.SupplierContactNo,
                SupplierContactPerson = supplier.SupplierContactPerson,
                SupplierIsActive = supplier.SupplierIsActive
            };
            using (_d = new DataRepository<Supplier>())
            {
                if (supplier.SupplierId > 0)
                    _d.Update(a);
                else _d.Add(a);

                _d.SaveChanges();
            }

            return a.SupplierId;
        }
        public static bool Delete(Supplier supplier)
        {
            using (_d = new DataRepository<Supplier>())
            {
                _d.Delete(supplier);
                _d.SaveChanges();

            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Supplier>())
            {
                _d.Delete(d => d.SupplierId == iId);
                _d.SaveChanges();
            }
            return true;
        }

        public static List<Supplier> GetAll()
        {
            _d.LazyLoadingEnabled = false;
            return _d.GetAll().OrderBy(o => o.SupplierName).ToList();
        }
        public static List<Supplier> GetAll(bool bActive)
        {
            _d.LazyLoadingEnabled = false;
            return
                _d.Find(f => f.SupplierIsActive == bActive)
                .OrderBy(o => o.SupplierName).ThenBy(o => o.SupplierContactPerson).ToList();
        }
    }
}

