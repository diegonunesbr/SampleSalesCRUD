﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalesApp.Infrastructure.DataContext;

#nullable disable

namespace SalesApp.Infrastructure.Migrations
{
    [DbContext(typeof(SalesAppDataContext))]
    partial class SalesAppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalesApp.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("cartId")
                        .HasColumnType("integer");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("cartId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("description")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("image")
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.ComplexProperty<Dictionary<string, object>>("rating", "SalesApp.Domain.Entities.Product.rating#Rating", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("count")
                                .HasColumnType("integer");

                            b1.Property<decimal>("rate")
                                .HasColumnType("numeric");
                        });

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("branch")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<decimal>("totalDiscountAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("totalProductAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("totalSaleAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.SaleItem", b =>
                {
                    b.Property<int>("saleId")
                        .HasColumnType("integer");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<decimal>("discount")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<decimal>("price")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("total")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("saleId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("role")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.ComplexProperty<Dictionary<string, object>>("address", "SalesApp.Domain.Entities.User.address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("city")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("number")
                                .HasColumnType("integer");

                            b1.Property<string>("street")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("zipcode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.ComplexProperty<Dictionary<string, object>>("geolocation", "SalesApp.Domain.Entities.User.address#Address.geolocation#GeoLocation", b2 =>
                                {
                                    b2.IsRequired();

                                    b2.Property<string>("lat")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("long")
                                        .IsRequired()
                                        .HasColumnType("text");
                                });
                        });

                    b.ComplexProperty<Dictionary<string, object>>("name", "SalesApp.Domain.Entities.User.name#Name", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("firstname")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("lastname")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Cart", b =>
                {
                    b.HasOne("SalesApp.Domain.Entities.User", "user")
                        .WithMany("carts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("SalesApp.Domain.Entities.Cart", "cart")
                        .WithMany("products")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesApp.Domain.Entities.Product", "product")
                        .WithMany("carts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("product");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Sale", b =>
                {
                    b.HasOne("SalesApp.Domain.Entities.User", "user")
                        .WithMany("sales")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.SaleItem", b =>
                {
                    b.HasOne("SalesApp.Domain.Entities.Product", "product")
                        .WithMany("sales")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesApp.Domain.Entities.Sale", "sale")
                        .WithMany("products")
                        .HasForeignKey("saleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("sale");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Cart", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Product", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("sales");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.Sale", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("SalesApp.Domain.Entities.User", b =>
                {
                    b.Navigation("carts");

                    b.Navigation("sales");
                });
#pragma warning restore 612, 618
        }
    }
}
