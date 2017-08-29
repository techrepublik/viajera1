namespace InventorySystem.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductOut
    {
        public int ProductOutId { get; set; }

        public double? ProductOutQnty { get; set; }

        public double? ProductOutPrice { get; set; }

        public bool? ProductOutIsActive { get; set; }

        public int? ProductInId { get; set; }

        public int? OutInfoId { get; set; }

        public virtual OutInfo OutInfo { get; set; }

        public virtual ProductIn ProductIn { get; set; }
    }
}
