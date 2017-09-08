using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class UnitManager
    {
        public static DataRepository<Unit> _d;

        public static int Save(Unit unit)
        {
            var a = new Unit
            {
                UnitId = unit.UnitId,
                UnitName = unit.UnitName
            };
            using (_d = new DataRepository<Unit>())
            {
                if (unit.UnitId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.UnitId;
        }

        public static bool Delete(Unit unit)
        {
            using (_d = new DataRepository<Unit>())
            {
                _d.Delete(unit);
                _d.SaveChanges();
            }

            return true;
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Unit>())
            {
                _d.Delete(d => d.UnitId == iId);
                _d.SaveChanges();
            }

            return true;
        }

        public static List<Unit> GetAll()
        {
            using (_d = new DataRepository<Unit>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
    }
}
