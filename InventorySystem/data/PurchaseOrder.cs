namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PODetails = new HashSet<PODetail>();
        }

        public int PurchaseOrderId { get; set; }

        public int? PurchaseOrderNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseOrderDate { get; set; }

        public string PurchaseOrderNote { get; set; }

        public bool? PurchaseOrderIsActive { get; set; }

        public int? ProductId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PODetail> PODetails { get; set; }
    }
}
