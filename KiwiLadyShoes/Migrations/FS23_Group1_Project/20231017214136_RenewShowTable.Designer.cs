﻿// <auto-generated />
using System;
using KiwiLadyShoes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiwiLadyShoes.Migrations.FS23_Group1_Project
{
    [DbContext(typeof(FS23_Group1_ProjectContext))]
    [Migration("20231017214136_RenewShowTable")]
    partial class RenewShowTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BrandID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("BrandId");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PaymentToken")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("date");

                    b.Property<int>("ShippingId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,1)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SaleId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ShippingId");

                    b.HasIndex("ShoeId");

                    b.HasIndex("UserId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Shipping", b =>
                {
                    b.Property<int>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShippingId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("ShippingPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ShippingId");

                    b.ToTable("Shipping", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Shoe", b =>
                {
                    b.Property<int>("ShoeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoeId"), 1L, 1);

                    b.Property<int>("DescriptionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Size")
                        .HasColumnType("decimal(10,1)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ShoeId");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Shoe", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.ShoeDescription", b =>
                {
                    b.Property<int>("ShoeDescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoeDescriptionId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("ShoeDescriptionId");

                    b.HasIndex("BrandId");

                    b.HasIndex("TypeId");

                    b.ToTable("ShoeDescription", (string)null);
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("TypeId");

                    b.ToTable("Type", (string)null);
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiwiLadyShoes.Models.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetRoleClaim", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserClaim", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserLogin", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUserToken", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Sale", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.Payment", "Payment")
                        .WithMany("Sales")
                        .HasForeignKey("PaymentId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__PaymentId__7EF6D905");

                    b.HasOne("KiwiLadyShoes.Models.Shipping", "Shipping")
                        .WithMany("Sales")
                        .HasForeignKey("ShippingId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__ShippingId__7FEAFD3E");

                    b.HasOne("KiwiLadyShoes.Models.Shoe", "Shoe")
                        .WithMany("Sales")
                        .HasForeignKey("ShoeId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__ShoeId__7D0E9093");

                    b.HasOne("KiwiLadyShoes.Models.AspNetUser", "User")
                        .WithMany("Sales")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__UserId__7E02B4CC");

                    b.Navigation("Payment");

                    b.Navigation("Shipping");

                    b.Navigation("Shoe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Shoe", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.ShoeDescription", "Description")
                        .WithMany("Shoes")
                        .HasForeignKey("DescriptionId")
                        .IsRequired()
                        .HasConstraintName("FK__Shoe__Descriptio__6C190EBB");

                    b.Navigation("Description");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.ShoeDescription", b =>
                {
                    b.HasOne("KiwiLadyShoes.Models.Brand", "Brand")
                        .WithMany("ShoeDescriptions")
                        .HasForeignKey("BrandId")
                        .IsRequired()
                        .HasConstraintName("FK__ShoeDescr__Brand__619B8048");

                    b.HasOne("KiwiLadyShoes.Models.Type", "Type")
                        .WithMany("ShoeDescriptions")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK__ShoeDescr__TypeI__60A75C0F");

                    b.Navigation("Brand");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Brand", b =>
                {
                    b.Navigation("ShoeDescriptions");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Payment", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Shipping", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Shoe", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.ShoeDescription", b =>
                {
                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("KiwiLadyShoes.Models.Type", b =>
                {
                    b.Navigation("ShoeDescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
