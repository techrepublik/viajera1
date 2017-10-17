namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InInfos")]
    public partial class InInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InInfo()
        {
            ProductIns = new HashSet<ProductIn>();
        }

        public int InInfoId { get; set; }

        [StringLength(50)]
        public string InInfoCode { get; set; }

        public int? InInfoReceiptNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InInfoDate { get; set; }

        public string InInfoNote { get; set; }

        public bool? InInforIsActive { get; set; }

        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductIn> ProductIns { get; set; }
    }
}
