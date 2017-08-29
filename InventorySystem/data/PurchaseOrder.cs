namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        public int PurchaseOrderId { get; set; }

        public int? PurchaseOrderNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseOrderDate { get; set; }

        public string PurchaseOrderNote { get; set; }

        public bool? PurchaseOrderIsActive { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
