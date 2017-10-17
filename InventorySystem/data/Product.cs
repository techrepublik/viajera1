namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PODetails = new HashSet<PODetail>();
            ProductIns = new HashSet<ProductIn>();
        }

        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int? ProductLevel { get; set; }

        public bool? ProductIsActive { get; set; }

        public int? SupplierId { get; set; }

        public int? UnitId { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PODetail> PODetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductIn> ProductIns { get; set; }
    }
}
