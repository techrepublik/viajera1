namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PODetail
    {
        public int PODetailId { get; set; }

        public int? PurchaseOrderId { get; set; }

        public int? ProductId { get; set; }

        public int? UnitId { get; set; }

        public double? PODetailQnty { get; set; }

        public virtual Product Product { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
