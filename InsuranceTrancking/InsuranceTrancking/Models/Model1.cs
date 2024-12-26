using Microsoft.Ajax.Utilities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace InsuranceTrancking.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<accident_reports> accident_reports { get; set; }
        public virtual DbSet<customers> customers { get; set; }
        public virtual DbSet<driving_license> driving_license { get; set; }
        public virtual DbSet<insurance_companies> insurance_companies { get; set; }
        public virtual DbSet<insurance_policies> insurance_policies { get; set; }
        public virtual DbSet<payments> payments { get; set; }
        public virtual DbSet<repair_shops> repair_shops { get; set; }
        public virtual DbSet<vehicles> vehicles { get; set; }

        public virtual DbSet<adminPanels> adminPanels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accident_reports>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<customers>()
                .Property(e => e.Address)
                .IsUnicode(false);
            modelBuilder.Entity<customers>()
                .Property(e => e.IsAdmin)
                .HasColumnType("BIT") 
                .IsRequired();
            modelBuilder.Entity<adminPanels>()
               .Property(e => e.Adminname)
               .IsUnicode(false);
            modelBuilder.Entity<adminPanels>()
               .Property(e => e.mail)
               .IsUnicode(false);
            modelBuilder.Entity<adminPanels>()
               .Property(e => e.adminpassword)
               .IsUnicode(false);


            modelBuilder.Entity<driving_license>()
                .Property(e => e.LicenseNumber)
                .IsUnicode(false);

            modelBuilder.Entity<insurance_companies>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<insurance_companies>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<insurance_companies>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<insurance_companies>()
                .HasMany(e => e.insurance_policies)
                .WithOptional(e => e.insurance_companies)
                .HasForeignKey(e => e.InsuranceCompanyID);

            modelBuilder.Entity<insurance_policies>()
                .Property(e => e.PolicyNumber)
                .IsUnicode(false);

            modelBuilder.Entity<insurance_policies>()
                .Property(e => e.CoverageType)
                .IsUnicode(false);

            modelBuilder.Entity<payments>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<repair_shops>()
                .Property(e => e.ShopName)
                .IsUnicode(false);

            modelBuilder.Entity<repair_shops>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<repair_shops>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<repair_shops>()
                .Property(e => e.ContractStatus)
                .IsUnicode(false);

            modelBuilder.Entity<repair_shops>()
                .HasMany(e => e.accident_reports)
                .WithOptional(e => e.repair_shops)
                .HasForeignKey(e => e.RepairShopID);
            //modelBuilder.Entity<vehicles>()
            //    .Property(e => e.VehicleID)
            //    .IsUnicode(true);

            modelBuilder.Entity<vehicles>()
                .Property(e => e.Plate)
                .IsUnicode(true);
            modelBuilder.Entity<vehicles>()
                .Property(e => e.Brand)
                .IsUnicode(false);

            modelBuilder.Entity<vehicles>()
                .Property(e => e.Model)
                .IsUnicode(false);
        }

        public static implicit operator Var(Model1 v)
        {
            throw new NotImplementedException();
        }
    }
}
