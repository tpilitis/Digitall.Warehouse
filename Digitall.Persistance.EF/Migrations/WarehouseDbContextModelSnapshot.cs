﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Digitall.Persistance.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Digitall.Persistance.EF.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    partial class WarehouseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.ComplexProperty<Dictionary<string, object>>("Price", "Digitall.Warehouse.Domain.Entities.Products.Product.Price#Price", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("CurrencyCode")
                                .IsRequired()
                                .HasMaxLength(3)
                                .HasColumnType("nvarchar(3)");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(16,2)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("Title");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductSwatch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Swatches");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SwatchId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.HasIndex("SwatchId");

                    b.ToTable("Variants");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Product", b =>
                {
                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductCategory", b =>
                {
                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductVariant", b =>
                {
                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.Product", null)
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.ProductSize", "Size")
                        .WithMany("Variants")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Digitall.Warehouse.Domain.Entities.Products.ProductSwatch", "Swatch")
                        .WithMany("Variants")
                        .HasForeignKey("SwatchId");

                    b.Navigation("Size");

                    b.Navigation("Swatch");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductSize", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("Digitall.Warehouse.Domain.Entities.Products.ProductSwatch", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
