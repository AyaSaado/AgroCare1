using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Models
{
    public  class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }

        public  DbSet<Action> Actions { get; set; } = null!;
        public  DbSet<AgriculturalItem> AgriculturalItems { get; set; } = null!;
        public  DbSet<Buyer> Buyers { get; set; } = null!;
        public  DbSet<Engineer> Engineers { get; set; } = null!;
        public  DbSet<EngineerType> EngineerTypes { get; set; } = null!;
        public  DbSet<Farmer> Farmers { get; set; } = null!;
        public  DbSet<Item> Items { get; set; } = null!;
        public  DbSet<Land> Lands { get; set; } = null!;
        public  DbSet<LandType> LandTypes { get; set; } = null!;
        public  DbSet<Order> Orders { get; set; } = null!;
        public  DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public  DbSet<Plan> Plans { get; set; } = null!;
        public  DbSet<Purchase> Purchases { get; set; } = null!;
        public  DbSet<PurchaseDetail> PurchaseDetails { get; set; } = null!;
        public  DbSet<SoilType> SoilTypes { get; set; } = null!;
        public  DbSet<Step> Steps { get; set; } = null!;
        public  DbSet<StepDetail> StepDetails { get; set; } = null!;
        public  DbSet<Store> Stores { get; set; } = null!;
        public  DbSet<StoreType> StoreTypes { get; set; } = null!;

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<AgriculturalItem>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Engineer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.EngineerType)
                    .WithMany(p => p.Engineers)
                    .HasForeignKey(d => d.EngineerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Engineer_Engineer_Type");

                entity.HasOne(d => d.HeadEngineer)
                    .WithMany(p => p.InverseHeadEngineer)
                    .HasForeignKey(d => d.HeadEngineerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Engineer_Engineer");
            });

            modelBuilder.Entity<EngineerType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Land>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Farmer)
                    .WithMany(p => p.Lands)
                    .HasForeignKey(d => d.FarmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Land_Farmer");

                entity.HasOne(d => d.SoilType)
                    .WithMany(p => p.Lands)
                    .HasForeignKey(d => d.SoilTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Land_Soil_Type");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Lands)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Land_Land_Type");
            });

            modelBuilder.Entity<LandType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AdminEngineer)
                    .WithMany(p => p.OrderAdminEngineers)
                    .HasForeignKey(d => d.AdminEngineerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Engineer");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Buyer");

                entity.HasOne(d => d.ExecutiveTeam)
                    .WithMany(p => p.OrderExecutiveTeams)
                    .HasForeignKey(d => d.ExecutiveTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Engineer1");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Item");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Order");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Land)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.LandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Distribution_Land");

                entity.HasOne(d => d.OrderDetails)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.OrderDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Distribution_Order_Details");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Order_Distribution");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Store");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Purchase_Details_Purchase");
            });

            modelBuilder.Entity<SoilType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Action");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Plan");
            });

            modelBuilder.Entity<StepDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AgriculturalItem)
                    .WithMany(p => p.StepDetails)
                    .HasForeignKey(d => d.AgriculturalItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Details_Agricultural_Item");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.StepDetails)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Step_Details_Step");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Store_Type");
            });

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });


            // OnModelCreatingPartial(modelBuilder);
        }

        internal Task UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        //void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
