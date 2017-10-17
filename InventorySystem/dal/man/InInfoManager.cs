using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.data;

namespace InventorySystem.dal.man
{
    public class InInfoManager
    {
        public static DataRepository<InInfo> _d;
        public static int Save(InInfo info)
        {
            var a = new data.InInfo
            {
                InInfoId = info.InInfoId,
                InInfoCode = info.InInfoCode,
                InInfoDate = info.InInfoDate,
                InInfoNote = info.InInfoNote,
                InInfoReceiptNo = info.InInfoReceiptNo,
                InInforIsActive = info.InInforIsActive,
                SupplierId = info.SupplierId
            };
            using (_d = new DataRepository<InInfo>())
            {
                if (info.InInfoId > 0)
                    _d.Update(a);
                else _d.Add(a);

                _d.SaveChanges();
            }

            return a.InInfoId;
        }
        public static bool Delete(InInfo info)
        {
            using (_d = new DataRepository<InInfo>())
            {
                _d.Delete(info);
                _d.SaveChanges();

            }
            return true;
        }
        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<InInfo>())
            {
                _d.Delete(d => d.InInfoId == iId);
                _d.SaveChanges();
            }
            return true;
        }

        public static List<InInfo> GetAll()
        {
            using (_d = new DataRepository<InInfo>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().OrderByDescending(o => o.InInfoDate).ToList();
            }
        }

        public static List<InInfo> GetAll(bool bActive)
        {
            _d.LazyLoadingEnabled = false;
            return
                _d.Find(f => f.InInforIsActive == bActive)
                .OrderByDescending(o => o.InInfoDate).ToList();
        }
    }
}
