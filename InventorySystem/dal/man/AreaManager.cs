using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class AreaManager
    {
        public static DataRepository<Area> _d;
        public static int Save(Area area)
        {
            var a = new Area
            {
               AreaId = area.AreaId,
               AreaName = area.AreaName,
               AreaIsActive = area.AreaIsActive
            };
            using (_d = new DataRepository<Area>())
            {
                if (area.AreaId > 0)
                    _d.Update(a);
                else _d.Add(a);

                _d.SaveChanges();
            }

            return a.AreaId;
        }
        public static bool Delete(Area area)
        {
            using (_d = new DataRepository<Area>())
            {
                _d.Delete(area);
                _d.SaveChanges();

            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Area>())
            {
                _d.Delete(d => d.AreaId == iId);
                _d.SaveChanges();
            }
            return true;
        }

        public static List<Area> GetAll()
        {
            _d.LazyLoadingEnabled = false;
            return _d.GetAll().OrderBy(o => o.AreaName).ToList();
        }
        public static List<Area> GetAll(bool bActive)
        {
            _d.LazyLoadingEnabled = false;
            return
                _d.Find(f => f.AreaIsActive == bActive)
                .OrderBy(o => o.AreaName).ToList();
        }
    }
}

