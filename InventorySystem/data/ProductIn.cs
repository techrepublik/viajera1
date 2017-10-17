namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductIn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductIn()
        {
            ProductOuts = new HashSet<ProductOut>();
        }

        public int ProductInId { get; set; }

        [StringLength(50)]
        public string ProductInReceiptNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductInDate { get; set; }

        public double? ProductInQnty { get; set; }

        public double? ProductInPrice { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductInExpiryDate { get; set; }

        public bool? ProductInIsActive { get; set; }

        public int? ProductId { get; set; }

        public int? InInfoId { get; set; }

        public int? UnitId { get; set; }

        public int? SupplierId { get; set; }

        public virtual InInfo InInfo { get; set; }

        public virtual Product Product { get; set; }

        public virtual Unit Unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOut> ProductOuts { get; set; }
    }
}
