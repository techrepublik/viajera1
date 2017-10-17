using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventorySystem.data;

namespace InventorySystem.dal.obj
{
    [NotMapped]
    class ProductInventoryData : Product
    {
        public int ProductInId { get; set; }
        public string UnitName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string AreaName { get; set; }
        public int? ReceiptNo { get; set; }
        public DateTime? InInfoDate { get; set; }
        public double? Price { get; set; }
        public double? Qnty { get; set; }
        public double? OutQnty { get; set; }
        public double TotalInQnty => Convert.ToDouble(Qnty) - Convert.ToDouble(OutQnty);
    }
}
