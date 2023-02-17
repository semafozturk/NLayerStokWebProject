﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nlayer.Core.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryId"), 1L, 1);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            categoryId = 1,
                            categoryName = "Motor Parçası"
                        },
                        new
                        {
                            categoryId = 2,
                            categoryName = "Araba Parçası"
                        });
                });

            modelBuilder.Entity("Nlayer.Core.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productId"), 1L, 1);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("purchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("salePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("productId");

                    b.HasIndex("categoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            productId = 1,
                            categoryId = 1,
                            productName = "YZFR5 Monster Kafa Karenajı",
                            purchasePrice = 520m,
                            salePrice = 750m,
                            stock = 4
                        },
                        new
                        {
                            productId = 2,
                            categoryId = 1,
                            productName = "FZ8 Fazer Debriyaj Balatası",
                            purchasePrice = 270m,
                            salePrice = 330m,
                            stock = 8
                        },
                        new
                        {
                            productId = 3,
                            categoryId = 2,
                            productName = "BMW E4 Klima Radyatörü",
                            purchasePrice = 550m,
                            salePrice = 650m,
                            stock = 5
                        },
                        new
                        {
                            productId = 4,
                            categoryId = 2,
                            productName = "FIAT Linea Motor Takozu",
                            purchasePrice = 290m,
                            salePrice = 370m,
                            stock = 10
                        },
                        new
                        {
                            productId = 5,
                            categoryId = 2,
                            productName = "Range Rover Triger Kayışı",
                            purchasePrice = 160m,
                            salePrice = 240m,
                            stock = 14
                        });
                });

            modelBuilder.Entity("Nlayer.Core.Purchase", b =>
                {
                    b.Property<int>("purchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("purchaseId"), 1L, 1);

                    b.Property<string>("comment")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<DateTime>("purchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("purchasesQuantity")
                        .HasColumnType("int");

                    b.HasKey("purchaseId");

                    b.HasIndex("productId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            purchaseId = 1,
                            comment = "AXC Araba parçaları ile haftalık alım anlaşması yaptık. Konuştuğum kişi : Mehmet abi.",
                            productId = 3,
                            purchaseDate = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            purchasesQuantity = 3
                        });
                });

            modelBuilder.Entity("Nlayer.Core.Sale", b =>
                {
                    b.Property<int>("saleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("saleId"), 1L, 1);

                    b.Property<string>("comment")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<DateTime>("saleDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("salesQuantity")
                        .HasColumnType("int");

                    b.HasKey("saleId");

                    b.HasIndex("productId");

                    b.ToTable("Sales");

                    b.HasData(
                        new
                        {
                            saleId = 1,
                            comment = "Ahmet abiye satış yapıldı.vsvsvs",
                            productId = 1,
                            saleDate = new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            salesQuantity = 2
                        },
                        new
                        {
                            saleId = 2,
                            productId = 4,
                            saleDate = new DateTime(2022, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            salesQuantity = 1
                        },
                        new
                        {
                            saleId = 3,
                            productId = 5,
                            saleDate = new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            salesQuantity = 3
                        });
                });

            modelBuilder.Entity("Nlayer.Core.Product", b =>
                {
                    b.HasOne("Nlayer.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Nlayer.Core.Purchase", b =>
                {
                    b.HasOne("Nlayer.Core.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nlayer.Core.Sale", b =>
                {
                    b.HasOne("Nlayer.Core.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nlayer.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Nlayer.Core.Product", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
