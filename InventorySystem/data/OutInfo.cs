namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutInfos")]
    public partial class OutInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OutInfo()
        {
            ProductOuts = new HashSet<ProductOut>();
        }

        public int OutInfoId { get; set; }

        [StringLength(50)]
        public string OutInfoCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OutInfoDate { get; set; }

        public string OutInfoNote { get; set; }

        public int? AreaId { get; set; }

        public bool? OutInfoIsActive { get; set; }

        public virtual Area Area { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductOut> ProductOuts { get; set; }
    }
}
