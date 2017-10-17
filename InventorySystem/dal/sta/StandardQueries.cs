using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.Win.UltraWinToolbars;
using InventorySystem.dal.obj;
using InventorySystem.data;

namespace InventorySystem.dal.sta
{
    class StandardQueries
    {
        public static List<ProductOutData> GetAllProductOutData(int iOutId)
        {
            using (var d = new InventoryModel())
            {
                var q = from q1 in d.Products
                    join q1a in d.Units on q1.UnitId equals q1a.UnitId
                    join q2 in d.ProductIns on q1.ProductId equals q2.ProductId
                    join q3 in d.ProductOuts on q2.ProductInId equals q3.ProductInId
                    join q4 in d.OutInfos on q3.OutInfoId equals q4.OutInfoId
                    where (q4.OutInfoIsActive == true) && (q3.OutInfoId == iOutId)
                    select new ProductOutData
                    {
                        ProductInId = q2.ProductInId,
                        ProductName = q1.ProductName,
                        UnitName = q1a.UnitName,
                        ProductOutQnty = q3.ProductOutQnty,
                        ProductOutPrice = q3.ProductOutPrice,
                        ProductOutId = q3.ProductOutId,
                        ProductOutIsActive = q3.ProductOutIsActive,
                        OutDateTime = q4.OutInfoDate
                    };
                return q.OrderByDescending(o => o.OutDateTime).ToList();
            }
        }
    }
}
