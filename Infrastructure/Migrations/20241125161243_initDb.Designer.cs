﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125161243_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AccountEntity", b =>
                {
                    b.Property<string>("acc_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("is_banned")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("acc_id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CategoryEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("category_id");

                    b.Property<string>("category_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("last_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("category_id");

                    b.HasIndex("created_by");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductDetailEntity", b =>
                {
                    b.Property<string>("product_detail_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<double>("price_import")
                        .HasColumnType("float");

                    b.Property<double>("price_sale")
                        .HasColumnType("float");

                    b.Property<string>("product_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("product_detail_id");

                    b.HasIndex("product_id");

                    b.ToTable("ProductDetail", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProductEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("product_id");

                    b.Property<string>("category_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("created_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("last_updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("product_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("updated_by")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("product_id");

                    b.HasIndex("category_id");

                    b.HasIndex("created_by");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("acc_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("birth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("full_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nick_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("user_id");

                    b.HasIndex("acc_id")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CategoryEntity", b =>
                {
                    b.HasOne("Domain.Entities.AccountEntity", "Account")
                        .WithMany("ListCategory")
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entities.ProductDetailEntity", b =>
                {
                    b.HasOne("Domain.Entities.ProductEntity", "Product")
                        .WithMany("ListProductDetail")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("Domain.Entities.CategoryEntity", "Category")
                        .WithMany("ListProduct")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.AccountEntity", "Account")
                        .WithMany("ListProduct")
                        .HasForeignKey("created_by")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Domain.Entities.AccountEntity", "Account")
                        .WithOne("User")
                        .HasForeignKey("Domain.Entities.UserEntity", "acc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Entities.AccountEntity", b =>
                {
                    b.Navigation("ListCategory");

                    b.Navigation("ListProduct");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.CategoryEntity", b =>
                {
                    b.Navigation("ListProduct");
                });

            modelBuilder.Entity("Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("ListProductDetail");
                });
#pragma warning restore 612, 618
        }
    }
}