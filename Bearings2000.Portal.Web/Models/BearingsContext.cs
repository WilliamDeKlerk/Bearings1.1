using System;
using System.Collections.Generic;
using Bearings2000.Portal.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bearings2000.Portal.Web.Models
{
    public partial class BearingsContext : Bearings2000PortalWebContext
    {
   

        public BearingsContext(DbContextOptions<BearingsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditDetail> AuditDetails { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<EmailQueue> EmailQueues { get; set; } = null!;
        public virtual DbSet<Enquire> Enquires { get; set; } = null!;
        public virtual DbSet<EnquiryDetail> EnquiryDetails { get; set; } = null!;
        public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDump> ProductDumps { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;
        public virtual DbSet<SettingType> SettingTypes { get; set; } = null!;
        public virtual DbSet<Skin> Skins { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;
        public virtual DbSet<VEnquiryDetailList> VEnquiryDetailLists { get; set; } = null!;
        public virtual DbSet<VEnquiryList> VEnquiryLists { get; set; } = null!;
        public virtual DbSet<VOrderDetailList> VOrderDetailLists { get; set; } = null!;
        public virtual DbSet<VOrderList> VOrderLists { get; set; } = null!;
        public virtual DbSet<VProductList> VProductLists { get; set; } = null!;
        public virtual DbSet<VUsersList> VUsersLists { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=Bearings;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<AuditDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AuditDetail");

                entity.Property(e => e.AuditDetailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AuditDetailID");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeType).IsUnicode(false);

                entity.Property(e => e.ColumnName).IsUnicode(false);

                entity.Property(e => e.FromValue).IsUnicode(false);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.TableName).IsUnicode(false);

                entity.Property(e => e.ToValue).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmailQueue>(entity =>
            {
                entity.ToTable("EmailQueue");

                entity.Property(e => e.EmailQueueId).HasColumnName("EmailQueueID");

                entity.Property(e => e.Bcc).HasColumnName("BCC");

                entity.Property(e => e.Cc).HasColumnName("CC");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateProcessed).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Subject).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<Enquire>(entity =>
            {
                entity.HasKey(e => e.EquiryId);

                entity.Property(e => e.EquiryId).HasColumnName("EquiryID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EnquiryCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryStatusId).HasColumnName("EnquiryStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Enquires)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Enquires_Customers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Enquires)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Enquires_Users");
            });

            modelBuilder.Entity<EnquiryDetail>(entity =>
            {
                entity.Property(e => e.EnquiryDetailId).HasColumnName("EnquiryDetailID");

                entity.Property(e => e.EnquiryDetailStatusId).HasColumnName("EnquiryDetailStatusID");

                entity.Property(e => e.EnquiryId).HasColumnName("EnquiryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPriceApproved).HasColumnType("money");

                entity.Property(e => e.UnitPriceRequested).HasColumnType("money");

                entity.HasOne(d => d.Enquiry)
                    .WithMany(p => p.EnquiryDetails)
                    .HasForeignKey(d => d.EnquiryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnquiryDetails_Enquires");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.EnquiryDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_EnquiryDetails_Products");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("Manufacturer");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.Manufacturer1)
                    .HasMaxLength(200)
                    .HasColumnName("Manufacturer");

                entity.Property(e => e.ManufacturerImage).HasColumnType("image");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.MenuImageUrl)
                    .HasMaxLength(200)
                    .HasColumnName("MenuImageURL");

                entity.Property(e => e.MenuName).HasMaxLength(100);

                entity.Property(e => e.MenuParentId).HasColumnName("MenuParentID");

                entity.Property(e => e.MenuTarget).HasMaxLength(50);

                entity.Property(e => e.MenuText).HasMaxLength(100);

                entity.Property(e => e.MenuUrl)
                    .HasMaxLength(800)
                    .HasColumnName("MenuURL");

                entity.Property(e => e.SortSequence).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DocumentPath).HasMaxLength(800);

                entity.Property(e => e.OrderCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_Users");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderDetailStatusId).HasColumnName("OrderDetailStatusID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Enquires");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.DiscountPerc).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LastAvailableDateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.ProductCode).HasMaxLength(200);

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.QuotedPrice).HasColumnType("money");

                entity.HasOne(d => d.ProductManufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductManufacturerId)
                    .HasConstraintName("FK_Products_Manufacturer");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Products_ProductTypes");
            });

            modelBuilder.Entity<ProductDump>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductDump");

                entity.Property(e => e.AbcAnalysisReq).HasMaxLength(255);

                entity.Property(e => e.AbcClass).HasMaxLength(255);

                entity.Property(e => e.AbcCostingReq).HasMaxLength(255);

                entity.Property(e => e.AltMethodFlag).HasMaxLength(255);

                entity.Property(e => e.AltReductionFlag).HasMaxLength(255);

                entity.Property(e => e.AltSisoFlag).HasMaxLength(255);

                entity.Property(e => e.AlternateKey1).HasMaxLength(255);

                entity.Property(e => e.AlternateKey2).HasMaxLength(255);

                entity.Property(e => e.AlternateUom).HasMaxLength(255);

                entity.Property(e => e.Basis).HasMaxLength(255);

                entity.Property(e => e.BatchBill).HasMaxLength(255);

                entity.Property(e => e.BlanketPoExists).HasMaxLength(255);

                entity.Property(e => e.BulkIssueFlag).HasMaxLength(255);

                entity.Property(e => e.Buyer).HasMaxLength(255);

                entity.Property(e => e.BuyingRule).HasMaxLength(255);

                entity.Property(e => e.CallOffBpoExists).HasMaxLength(255);

                entity.Property(e => e.ClearingFlag).HasMaxLength(255);

                entity.Property(e => e.ConvMulDiv).HasMaxLength(255);

                entity.Property(e => e.CostUom).HasMaxLength(255);

                entity.Property(e => e.CountryOfOrigin).HasMaxLength(255);

                entity.Property(e => e.DateStkAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DistWarehouseToUse).HasMaxLength(255);

                entity.Property(e => e.DrawOfficeNum).HasMaxLength(255);

                entity.Property(e => e.EbqPan).HasMaxLength(255);

                entity.Property(e => e.EccFlag).HasMaxLength(255);

                entity.Property(e => e.EccUser).HasMaxLength(255);

                entity.Property(e => e.GrossReqRule).HasMaxLength(255);

                entity.Property(e => e.GstTaxCode).HasMaxLength(255);

                entity.Property(e => e.InclInStrValid).HasMaxLength(255);

                entity.Property(e => e.InspectionFlag).HasMaxLength(255);

                entity.Property(e => e.InterfaceFlag).HasMaxLength(255);

                entity.Property(e => e.IssMultLotsFlag).HasMaxLength(255);

                entity.Property(e => e.JobClassification).HasMaxLength(255);

                entity.Property(e => e.JobHoldAllocs).HasMaxLength(255);

                entity.Property(e => e.JobsOnHold).HasMaxLength(255);

                entity.Property(e => e.KitType).HasMaxLength(255);

                entity.Property(e => e.LctRequired).HasMaxLength(255);

                entity.Property(e => e.ListPriceCode).HasMaxLength(255);

                entity.Property(e => e.LongDesc).HasMaxLength(255);

                entity.Property(e => e.MaintOnHold).HasMaxLength(255);

                entity.Property(e => e.MakeToOrderFlag).HasMaxLength(255);

                entity.Property(e => e.ManMulDiv).HasMaxLength(255);

                entity.Property(e => e.ManualCostFlag).HasMaxLength(255);

                entity.Property(e => e.ManufactureUom).HasMaxLength(255);

                entity.Property(e => e.MpsFlag).HasMaxLength(255);

                entity.Property(e => e.MulDiv).HasMaxLength(255);

                entity.Property(e => e.OtherTaxCode).HasMaxLength(255);

                entity.Property(e => e.OtherUom).HasMaxLength(255);

                entity.Property(e => e.OutputMassFlag).HasMaxLength(255);

                entity.Property(e => e.PartCategory).HasMaxLength(255);

                entity.Property(e => e.PhantomIfComp).HasMaxLength(255);

                entity.Property(e => e.Planner).HasMaxLength(255);

                entity.Property(e => e.PrcInclGst).HasMaxLength(255);

                entity.Property(e => e.PriceCategory).HasMaxLength(255);

                entity.Property(e => e.PriceMethod).HasMaxLength(255);

                entity.Property(e => e.PriceType).HasMaxLength(255);

                entity.Property(e => e.ProductClass).HasMaxLength(255);

                entity.Property(e => e.ProductGroup).HasMaxLength(255);

                entity.Property(e => e.PurchOnHold).HasMaxLength(255);

                entity.Property(e => e.Release).HasMaxLength(255);

                entity.Property(e => e.ResourceCode).HasMaxLength(255);

                entity.Property(e => e.ReturnableItem).HasMaxLength(255);

                entity.Property(e => e.SalesOnHold).HasMaxLength(255);

                entity.Property(e => e.SerEntryAtSale).HasMaxLength(255);

                entity.Property(e => e.SerialMethod).HasMaxLength(255);

                entity.Property(e => e.SerialPrefix).HasMaxLength(255);

                entity.Property(e => e.SerialSuffix).HasMaxLength(255);

                entity.Property(e => e.StdLctRoute).HasMaxLength(255);

                entity.Property(e => e.StockAndAltUm).HasMaxLength(255);

                entity.Property(e => e.StockCode).HasMaxLength(255);

                entity.Property(e => e.StockMovementReq).HasMaxLength(255);

                entity.Property(e => e.StockOnHold).HasMaxLength(255);

                entity.Property(e => e.StockOnHoldReason).HasMaxLength(255);

                entity.Property(e => e.StockUom).HasMaxLength(255);

                entity.Property(e => e.StorageCondition).HasMaxLength(255);

                entity.Property(e => e.StorageHazard).HasMaxLength(255);

                entity.Property(e => e.StorageSecurity).HasMaxLength(255);

                entity.Property(e => e.StpSelection).HasMaxLength(255);

                entity.Property(e => e.SupercessionDate).HasColumnType("datetime");

                entity.Property(e => e.SupplUnitCode).HasMaxLength(255);

                entity.Property(e => e.SupplementaryUnit).HasMaxLength(255);

                entity.Property(e => e.Supplier).HasMaxLength(255);

                entity.Property(e => e.TariffCode).HasMaxLength(255);

                entity.Property(e => e.TaxCode).HasMaxLength(255);

                entity.Property(e => e.TraceableType).HasMaxLength(255);

                entity.Property(e => e.UserField1).HasMaxLength(255);

                entity.Property(e => e.UserField3).HasMaxLength(255);

                entity.Property(e => e.UserField4).HasMaxLength(255);

                entity.Property(e => e.UserField5).HasMaxLength(255);

                entity.Property(e => e.Version).HasMaxLength(255);

                entity.Property(e => e.WarehouseToUse).HasMaxLength(255);

                entity.Property(e => e.WipCtlGlCode).HasMaxLength(255);

                entity.Property(e => e.WithTaxExpenseType).HasMaxLength(255);
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.ProductType1)
                    .HasMaxLength(200)
                    .HasColumnName("ProductType");

                entity.Property(e => e.ProductTypeImage).HasColumnType("image");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.SettingId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SettingID");

                entity.Property(e => e.SettingTypeIntermediateId).HasColumnName("SettingTypeIntermediateID");

                entity.Property(e => e.SettingTypeMajorId).HasColumnName("SettingTypeMajorID");

                entity.Property(e => e.SettingTypeMinorId).HasColumnName("SettingTypeMinorID");

                entity.Property(e => e.SettingValue).IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<SettingType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.SettingTypeDescription).IsUnicode(false);

                entity.Property(e => e.SettingTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SettingTypeID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
            });

            modelBuilder.Entity<Skin>(entity =>
            {
                entity.ToTable("Skin");

                entity.Property(e => e.SkinId).HasColumnName("SkinID");

                entity.Property(e => e.ByLine).HasMaxLength(150);

                entity.Property(e => e.CompanyName).HasMaxLength(150);

                entity.Property(e => e.Cssname)
                    .HasMaxLength(200)
                    .HasColumnName("CSSName");

                entity.Property(e => e.DatabaseName).HasMaxLength(100);

                entity.Property(e => e.LogoUrl)
                    .HasMaxLength(400)
                    .HasColumnName("LogoURL");

                entity.Property(e => e.SkinName).HasMaxLength(150);

                entity.Property(e => e.ThemeName).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AccountNumberRegistration).HasMaxLength(50);

                entity.Property(e => e.CellNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastLogin).HasColumnType("datetime");

                entity.Property(e => e.DateProcessed).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UserPin).HasMaxLength(50);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Users_Customers");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserStatusId)
                    .HasConstraintName("FK_Users_UserStatus");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("UserStatus");

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserStatus1)
                    .HasMaxLength(200)
                    .HasColumnName("UserStatus");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(100)
                    .HasColumnName("UserType");
            });

            modelBuilder.Entity<VEnquiryDetailList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vEnquiryDetailList");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.EnquiryCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryDetailId).HasColumnName("EnquiryDetailID");

                entity.Property(e => e.EnquiryDetailStatusId).HasColumnName("EnquiryDetailStatusID");

                entity.Property(e => e.EnquiryProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryStatusId).HasColumnName("EnquiryStatusID");

                entity.Property(e => e.EquiryId).HasColumnName("EquiryID");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(201);

                entity.Property(e => e.LastAvailableDateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(200);

                entity.Property(e => e.ProductCode).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductType).HasMaxLength(200);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UnitPriceApproved).HasColumnType("money");

                entity.Property(e => e.UnitPriceRequested).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VEnquiryList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vEnquiryList");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.EnquiryCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.EnquiryStatusId).HasColumnName("EnquiryStatusID");

                entity.Property(e => e.EquiryId).HasColumnName("EquiryID");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(201);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VOrderDetailList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOrderDetailList");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.DocumentPath).HasMaxLength(800);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(201);

                entity.Property(e => e.LastAvailableDateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(200);

                entity.Property(e => e.OrderCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderDetailStatusId).HasColumnName("OrderDetailStatusID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.ProductCode).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductType).HasMaxLength(200);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VOrderList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vOrderList");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.DocumentPath).HasMaxLength(800);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(201);

                entity.Property(e => e.InvoiceName).HasMaxLength(10);

                entity.Property(e => e.OrderCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderProcessedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<VProductList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProductList");

                entity.Property(e => e.LastAvailableDateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(200);

                entity.Property(e => e.ProductCode).HasMaxLength(200);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductImage).HasColumnType("image");

                entity.Property(e => e.ProductManufacturerId).HasColumnName("ProductManufacturerID");

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ProductType).HasMaxLength(200);

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");
            });

            modelBuilder.Entity<VUsersList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vUsersList");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.AccountNumberRegistration).HasMaxLength(50);

                entity.Property(e => e.CellNumber).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateLastLogin).HasColumnType("datetime");

                entity.Property(e => e.DateProcessed).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(201);

                entity.Property(e => e.Password).HasMaxLength(200);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserPin).HasMaxLength(50);

                entity.Property(e => e.UserStatusId).HasColumnName("UserStatusID");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
