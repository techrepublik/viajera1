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
    class ProductOutData : ProductOut
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public DateTime? OutDateTime { get; set; }
    }
}
