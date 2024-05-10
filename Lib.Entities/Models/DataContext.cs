using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lib.Entities.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.Id, "account_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Dataid).HasColumnName("dataid");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Resetexpiretime).HasColumnName("resetexpiretime");

                entity.Property(e => e.Resetpasswordtoken)
                    .HasColumnType("character varying")
                    .HasColumnName("resetpasswordtoken");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Username)
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("client");

                entity.HasIndex(e => e.Id, "client_id_idx");

                entity.Property(e => e.Avatar)
                    .HasColumnType("character varying")
                    .HasColumnName("avatar");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Code)
                    .HasColumnType("character varying")
                    .HasColumnName("code");

                entity.Property(e => e.Createdate).HasColumnName("createdate");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("character varying")
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.Id, "orders_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Code)
                    .HasColumnType("character varying")
                    .HasColumnName("code");

                entity.Property(e => e.Productid).HasColumnName("productid");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.HasIndex(e => e.Id, "product_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Attachments)
                    .HasColumnType("character varying")
                    .HasColumnName("attachments");

                entity.Property(e => e.Body)
                    .HasColumnType("character varying")
                    .HasColumnName("body");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Title)
                    .HasColumnType("character varying")
                    .HasColumnName("title");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "users_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Avatar)
                    .HasColumnType("character varying")
                    .HasColumnName("avatar");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.Code)
                    .HasColumnType("character varying")
                    .HasColumnName("code");

                entity.Property(e => e.Createdate).HasColumnName("createdate");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasColumnType("character varying")
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
