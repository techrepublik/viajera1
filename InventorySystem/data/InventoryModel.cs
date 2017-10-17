namespace InventorySystem.data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InventoryModel : DbContext
    {
        public InventoryModel()
            : base("name=InventoryModel1")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<InInfo> InInfos { get; set; }
        public virtual DbSet<OutInfo> OutInfos { get; set; }
        public virtual DbSet<PODetail> PODetails { get; set; }
        public virtual DbSet<ProductIn> ProductIns { get; set; }
        public virtual DbSet<ProductOut> ProductOuts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.AreaName)
                .IsUnicode(false);

            modelBuilder.Entity<Area>()
                .HasMany(e => e.OutInfos)
                .WithOptional(e => e.Area)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryDescription)
                .IsUnicode(false);

            modelBuilder.Entity<InInfo>()
                .Property(e => e.InInfoCode)
                .IsUnicode(false);

            modelBuilder.Entity<InInfo>()
                .Property(e => e.InInfoNote)
                .IsUnicode(false);

            modelBuilder.Entity<InInfo>()
                .HasMany(e => e.ProductIns)
                .WithOptional(e => e.InInfo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<OutInfo>()
                .Property(e => e.OutInfoCode)
                .IsUnicode(false);

            modelBuilder.Entity<OutInfo>()
                .Property(e => e.OutInfoNote)
                .IsUnicode(false);

            modelBuilder.Entity<ProductIn>()
                .Property(e => e.ProductInReceiptNo)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCode)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PODetails)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductIns)
                .WithOptional(e => e.Product)
                .WillCascadeOnDelete();

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.PurchaseOrderNote)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PODetails)
                .WithOptional(e => e.PurchaseOrder)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierContactPerson)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.InInfos)
                .WithOptional(e => e.Supplier)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Unit>()
                .Property(e => e.UnitName)
                .IsUnicode(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.ProductIns)
                .WithOptional(e => e.Unit)
                .WillCascadeOnDelete();
        }
    }
}
