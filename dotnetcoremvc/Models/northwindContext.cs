using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnetcoremvc.Models
{
    public partial class northwindContext : DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customercustomerdemo> Customercustomerdemo { get; set; }
        public virtual DbSet<Customerdemographics> Customerdemographics { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Employeeterritories> Employeeterritories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }
        public virtual DbSet<Usstates> Usstates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=localhost;Database=northwind;Username=northwind_user;Password=thewindisblowing;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.Categoryid);

                entity.ToTable("categories");

                entity.Property(e => e.Categoryid)
                    .HasColumnName("categoryid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoryname)
                    .IsRequired()
                    .HasColumnName("categoryname");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Picture).HasColumnName("picture");
            });

            modelBuilder.Entity<Customercustomerdemo>(entity =>
            {
                entity.HasKey(e => new { e.Customerid, e.Customertypeid });

                entity.ToTable("customercustomerdemo");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasColumnType("char");

                entity.Property(e => e.Customertypeid)
                    .HasColumnName("customertypeid")
                    .HasColumnType("char");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Customercustomerdemo)
                    .HasForeignKey(d => d.Customerid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customercustomerdemo_customers");

                entity.HasOne(d => d.Customertype)
                    .WithMany(p => p.Customercustomerdemo)
                    .HasForeignKey(d => d.Customertypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customercustomerdemo_customerdemographics");
            });

            modelBuilder.Entity<Customerdemographics>(entity =>
            {
                entity.HasKey(e => e.Customertypeid);

                entity.ToTable("customerdemographics");

                entity.Property(e => e.Customertypeid)
                    .HasColumnName("customertypeid")
                    .HasColumnType("char")
                    .ValueGeneratedNever();

                entity.Property(e => e.Customerdesc).HasColumnName("customerdesc");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.Customerid);

                entity.ToTable("customers");

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasColumnType("char")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname");

                entity.Property(e => e.Contactname).HasColumnName("contactname");

                entity.Property(e => e.Contacttitle).HasColumnName("contacttitle");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Postalcode).HasColumnName("postalcode");

                entity.Property(e => e.Region).HasColumnName("region");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.Employeeid);

                entity.ToTable("employees");

                entity.Property(e => e.Employeeid)
                    .HasColumnName("employeeid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Extension).HasColumnName("extension");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname");

                entity.Property(e => e.Hiredate)
                    .HasColumnName("hiredate")
                    .HasColumnType("date");

                entity.Property(e => e.Homephone).HasColumnName("homephone");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Photopath).HasColumnName("photopath");

                entity.Property(e => e.Postalcode).HasColumnName("postalcode");

                entity.Property(e => e.Region).HasColumnName("region");

                entity.Property(e => e.Reportsto).HasColumnName("reportsto");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.Property(e => e.Titleofcourtesy).HasColumnName("titleofcourtesy");

                entity.HasOne(d => d.ReportstoNavigation)
                    .WithMany(p => p.InverseReportstoNavigation)
                    .HasForeignKey(d => d.Reportsto)
                    .HasConstraintName("fk_employees_employees");
            });

            modelBuilder.Entity<Employeeterritories>(entity =>
            {
                entity.HasKey(e => new { e.Employeeid, e.Territoryid });

                entity.ToTable("employeeterritories");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Territoryid).HasColumnName("territoryid");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Employeeterritories)
                    .HasForeignKey(d => d.Employeeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeeterritories_employees");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.Employeeterritories)
                    .HasForeignKey(d => d.Territoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employeeterritories_territories");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid });

                entity.ToTable("order_details");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Orderid);

                entity.ToTable("orders");

                entity.Property(e => e.Orderid)
                    .HasColumnName("orderid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Customerid)
                    .HasColumnName("customerid")
                    .HasColumnType("char");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Freight).HasColumnName("freight");

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date");

                entity.Property(e => e.Requireddate)
                    .HasColumnName("requireddate")
                    .HasColumnType("date");

                entity.Property(e => e.Shipaddress).HasColumnName("shipaddress");

                entity.Property(e => e.Shipcity).HasColumnName("shipcity");

                entity.Property(e => e.Shipcountry).HasColumnName("shipcountry");

                entity.Property(e => e.Shipname).HasColumnName("shipname");

                entity.Property(e => e.Shippeddate)
                    .HasColumnName("shippeddate")
                    .HasColumnType("date");

                entity.Property(e => e.Shippostalcode).HasColumnName("shippostalcode");

                entity.Property(e => e.Shipregion).HasColumnName("shipregion");

                entity.Property(e => e.Shipvia).HasColumnName("shipvia");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Customerid)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Employeeid)
                    .HasConstraintName("fk_orders_employees");

                entity.HasOne(d => d.ShipviaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Shipvia)
                    .HasConstraintName("fk_orders_shippers");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.ToTable("products");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnName("productname");

                entity.Property(e => e.Quantityperunit).HasColumnName("quantityperunit");

                entity.Property(e => e.Reorderlevel).HasColumnName("reorderlevel");

                entity.Property(e => e.Supplierid).HasColumnName("supplierid");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.Property(e => e.Unitsinstock).HasColumnName("unitsinstock");

                entity.Property(e => e.Unitsonorder).HasColumnName("unitsonorder");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("fk_products_categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Supplierid)
                    .HasConstraintName("fk_products_suppliers");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.Regionid)
                    .HasColumnName("regionid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Regiondescription)
                    .HasColumnName("regiondescription")
                    .HasColumnType("char");
            });

            modelBuilder.Entity<Shippers>(entity =>
            {
                entity.HasKey(e => e.Shipperid);

                entity.ToTable("shippers");

                entity.Property(e => e.Shipperid)
                    .HasColumnName("shipperid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.Supplierid);

                entity.ToTable("suppliers");

                entity.Property(e => e.Supplierid)
                    .HasColumnName("supplierid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname");

                entity.Property(e => e.Contactname).HasColumnName("contactname");

                entity.Property(e => e.Contacttitle).HasColumnName("contacttitle");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.Homepage).HasColumnName("homepage");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Postalcode).HasColumnName("postalcode");

                entity.Property(e => e.Region).HasColumnName("region");
            });

            modelBuilder.Entity<Territories>(entity =>
            {
                entity.HasKey(e => e.Territoryid);

                entity.ToTable("territories");

                entity.Property(e => e.Territoryid)
                    .HasColumnName("territoryid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Regionid).HasColumnName("regionid");

                entity.Property(e => e.Territorydescription)
                    .HasColumnName("territorydescription")
                    .HasColumnType("char");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.Regionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_territories_region");
            });

            modelBuilder.Entity<Usstates>(entity =>
            {
                entity.HasKey(e => e.Stateid);

                entity.ToTable("usstates");

                entity.Property(e => e.Stateid)
                    .HasColumnName("stateid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Stateabbr).HasColumnName("stateabbr");

                entity.Property(e => e.Statename).HasColumnName("statename");

                entity.Property(e => e.Stateregion).HasColumnName("stateregion");
            });
        }
    }
}
