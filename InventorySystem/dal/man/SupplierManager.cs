using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    public class SupplierManager
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
        public static int Save(List<Supplier> suppliers)
        {
            try
            {
                using (_d = new DataRepository<Supplier>())
                {
                    foreach (var supplier in suppliers)
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

                        if (supplier.SupplierId > 0)
                            _d.Update(a);
                        else _d.Add(a);
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
        public static bool Delete(List<Supplier> suppliers)
        {
            try
            {
                using (_d = new DataRepository<Supplier>())
                {
                    foreach (var supplier in suppliers)
                    {
                        _d.Delete(supplier);
                    }

                    _d.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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
            using (_d = new DataRepository<Supplier>())
            {
                _d.LazyLoadingEnabled = true;
                return _d.GetAll().OrderBy(o => o.SupplierName).ToList();
            }
        }
        public static List<Supplier> GetAll(bool bActive)
        {
            using (_d = new DataRepository<Supplier>())
            {
                _d.LazyLoadingEnabled = false;
                return
                    _d.Find(f => f.SupplierIsActive == bActive)
                    .OrderBy(o => o.SupplierName).ThenBy(o => o.SupplierContactPerson).ToList();
            }
        }
    }
}

