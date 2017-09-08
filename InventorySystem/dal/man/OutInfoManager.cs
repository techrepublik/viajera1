using InventorySystem.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.dal.man
{
    class OutInfoManager
    {
        public static DataRepository<OutInfo> _d;
        public static int Save(OutInfo outInfo)
        {
            var a = new OutInfo
            {
                OutInfoId = outInfo.OutInfoId,
                OutInfoCode = outInfo.OutInfoCode,
                OutInfoDate = outInfo.OutInfoDate,
                OutInfoNote = outInfo.OutInfoNote,
                AreaId = outInfo.AreaId,
                OutInfoIsActive = outInfo.OutInfoIsActive
            };
            using (_d = new DataRepository<OutInfo>())
            {
                if (outInfo.OutInfoId > 0)
                    _d.Update(a);
                else
                    _d.Add(a);
                _d.SaveChanges();
            }
            return a.OutInfoId;
        }
        public static bool Delete(OutInfo outInfo)
        {
            using (_d = new DataRepository<OutInfo>())
            {
                _d.Delete(outInfo);
                _d.SaveChanges();
            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<OutInfo>())
            {
                _d.Delete(d => d.OutInfoId == iId);
                _d.SaveChanges();
            }
            return true;
        }
        public static List<OutInfo> GetAll()
        {
            using (_d = new DataRepository<OutInfo>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
        public static List<OutInfo> GetAll(bool bActive)
        {
            using (_d = new DataRepository<OutInfo>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.Find(f => f.OutInfoIsActive == bActive)
                    .OrderBy(o => o.OutInfoCode).ToList();
            }
        }
    }
}
