using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.Win.UltraWinToolbars;
using InventorySystem.dal.obj;
using InventorySystem.data;

namespace InventorySystem.dal.sta
{
    class InventoryQueries
    {
        public static List<ProductInventoryData> GetInventoryDatas()
        {
            using (var d = new InventoryModel())
            {
                var q = from q1 in d.Products
                    join q1a in d.Categories on q1.CategoryId equals q1a.CategoryId
                    join q2 in d.ProductIns on q1.ProductId equals q2.ProductId
                    join q3 in d.InInfos on q2.InInfoId equals q3.InInfoId
                    join q4 in d.Suppliers on q3.SupplierId equals q4.SupplierId
                    join q5 in d.Units on q2.UnitId equals q5.UnitId
                    join q6 in d.ProductOuts on q2.ProductInId equals q6.ProductInId into  q62
                    from q6a in q62.DefaultIfEmpty()
                    join q7 in d.OutInfos on q6a.OutInfoId equals q7.OutInfoId into q72
                    from q7a in q72.DefaultIfEmpty()
                        join q8 in d.Areas on q7a.AreaId equals q8.AreaId into q82
                        from q8a in q82.DefaultIfEmpty()
                        where (q3.InInforIsActive == true)
                        group q1 by new
                        {
                            ProductId = q1.ProductId,
                            ProductInId = q2.ProductInId,
                            SupplierName = q4.SupplierName,
                            CategoryName = q1a.CategoryName,
                            UnitName = q5.UnitName,
                            AreaName = q8a.AreaName,
                            ReceiptNo = q3.InInfoReceiptNo,
                            InInfoDate = q3.InInfoDate,
                            ProductCode = q1.ProductCode,
                            ProductDescription = q1.ProductDescription,
                            ProductName = q1.ProductName,
                            ProductIsActive = q1.ProductIsActive,
                            ProductLevel = q1.ProductLevel,
                            Price = q2.ProductInPrice,
                            Qnty = q2.ProductInQnty,
                            OutQnty = q6a.ProductOutQnty
                        }
                        into q1a
                    select new ProductInventoryData
                    {
                        ProductId = q1a.Key.ProductId,
                        ProductInId = q1a.Key.ProductInId,
                        SupplierName = q1a.Key.SupplierName,
                        CategoryName = q1a.Key.CategoryName,
                        UnitName = q1a.Key.UnitName,
                        AreaName = q1a.Key.AreaName,
                        ReceiptNo = q1a.Key.ReceiptNo,
                        InInfoDate = q1a.Key.InInfoDate,
                        ProductCode = q1a.Key.ProductCode,
                        ProductDescription = q1a.Key.ProductDescription,
                        ProductName = q1a.Key.ProductName,
                        ProductIsActive = q1a.Key.ProductIsActive,
                        ProductLevel = q1a.Key.ProductLevel,
                        Price = q1a.Key.Price,
                        Qnty = q1a.Key.Qnty,
                        OutQnty = q1a.Key.OutQnty
                    };

                return q.OrderByDescending(o => o.InInfoDate).ToList();
            }
        }
        public static List<ProductInventoryData> GetInventoryDatas(int iCatId)
        {
            using (var d = new InventoryModel())
            {
                var q = from q1 in d.Products
                        join q1a in d.Categories on q1.CategoryId equals q1a.CategoryId
                        join q2 in d.ProductIns on q1.ProductId equals q2.ProductId
                        join q3 in d.InInfos on q2.InInfoId equals q3.InInfoId
                        join q4 in d.Suppliers on q3.SupplierId equals q4.SupplierId
                        join q5 in d.Units on q2.UnitId equals q5.UnitId
                        join q6 in d.ProductOuts on q2.ProductInId equals q6.ProductInId into q62
                        from q6a in q62.DefaultIfEmpty()
                        join q7 in d.OutInfos on q6a.OutInfoId equals q7.OutInfoId into q72
                        from q7a in q72.DefaultIfEmpty()
                        join q8 in d.Areas on q7a.AreaId equals q8.AreaId into q82
                        from q8a in q82.DefaultIfEmpty()
                        where (q3.InInforIsActive == true) && (q1a.CategoryId == iCatId)
                        select new ProductInventoryData
                        {
                            ProductId = q1.ProductId,
                            ProductInId = q2.ProductInId,
                            SupplierName = q4.SupplierName,
                            CategoryName = q1a.CategoryName,
                            UnitName = q5.UnitName,
                            AreaName = q8a.AreaName,
                            ReceiptNo = q3.InInfoReceiptNo,
                            InInfoDate = q3.InInfoDate,
                            ProductCode = q1.ProductCode,
                            ProductDescription = q1.ProductDescription,
                            ProductName = q1.ProductName,
                            ProductIsActive = q1.ProductIsActive,
                            ProductLevel = q1.ProductLevel,
                            Price = q2.ProductInPrice,
                            Qnty = q2.ProductInQnty,
                            OutQnty = q62.Sum(s => s.ProductOutQnty)
                        };

                return q.OrderByDescending(o => o.InInfoDate).Distinct().ToList();
            }
        }
    }
}
