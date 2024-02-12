﻿// <auto-generated />
using System;
using KiwiLadyShoes.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KiwiLadyShoes.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20231013035935_AddRoles")]
    partial class AddRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KiwiLadyShoes.Areas.Identity.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3f95308-0d7e-4125-80ac-94b75420a0e6",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5365),
                            ConcurrencyStamp = "ceebcfdb-4539-401a-935f-9fa2bac6359e",
                            Email = "administrator@example.com",
                            EmailConfirmed = true,
                            FirstName = "Admin",
                            LastName = "admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                            NormalizedUserName = "ADMINISTRATOR@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENSFJIBJGi2PmFCImRcrtKQRRxJ3jbSIS2f/VKKrajP74SIGttwoqQTPZIGcw4czdw==",
                            PhoneNumber = "0210888888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b5f95908-bbb9-4c0a-ac84-bd4a3cd1e5f8",
                            TwoFactorEnabled = false,
                            UserName = "administrator@example.com"
                        },
                        new
                        {
                            Id = "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5411),
                            ConcurrencyStamp = "4be77d31-6981-48a3-81bb-e021f266c716",
                            Email = "manager@example.com",
                            EmailConfirmed = true,
                            FirstName = "manager",
                            LastName = "manager",
                            LockoutEnabled = false,
                            NormalizedEmail = "MANAGER@EXAMPLE.COM",
                            NormalizedUserName = "MANAGER@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEN+TLucPAaWi8IFY7QBXzB9k31Liu+teQPo+SfhogJa8gM+S4cNJ48AYyaLZYLXRag==",
                            PhoneNumber = "0210888888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5250b0d9-eab2-4f53-ae18-5c938a928b74",
                            TwoFactorEnabled = false,
                            UserName = "manager@example.com"
                        },
                        new
                        {
                            Id = "825ddba5-4393-44de-849c-b655151fda95",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5422),
                            ConcurrencyStamp = "106a06da-8511-4401-b93c-e7dafb3891ff",
                            Email = "salesperson@example.com",
                            EmailConfirmed = true,
                            FirstName = "salesperson",
                            LastName = "salesperson",
                            LockoutEnabled = false,
                            NormalizedEmail = "SALESPERSON@EXAMPLE.COM",
                            NormalizedUserName = "SALESPERSON@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEA+lJrjkQP6ibD8RMlRNKXNbF/L8JqV1aqofdwziNO9boG/qBKT2o+i3C/eoiOWEmQ==",
                            PhoneNumber = "0210888888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "16281fca-2b6e-47e3-b4fe-377357bc47a6",
                            TwoFactorEnabled = false,
                            UserName = "salesperson@example.com"
                        },
                        new
                        {
                            Id = "59dc85ee-dc82-4815-b667-91fe4a5764d8",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2023, 10, 13, 16, 59, 34, 926, DateTimeKind.Local).AddTicks(5435),
                            ConcurrencyStamp = "654b7d95-fd83-4183-bc22-3bd45d63fe11",
                            Email = "visitor@example.com",
                            EmailConfirmed = true,
                            FirstName = "visitor",
                            LastName = "visitor",
                            LockoutEnabled = false,
                            NormalizedEmail = "VISITOR@EXAMPLE.COM",
                            NormalizedUserName = "VISITOR@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDIvwcZFQECgqMqRiErpfvZKhlqJnk5kpZzojrquLw8oyJ0gYSKQTidh9TEvcIS7hA==",
                            PhoneNumber = "0210888888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "345b520a-21b7-4257-8fe4-9ebc00358542",
                            TwoFactorEnabled = false,
                            UserName = "visitor@example.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3d673303-1204-487b-8428-c1aa60346921",
                            ConcurrencyStamp = "a1dd3e5b-f8f1-45a8-8105-06883818a288",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c",
                            ConcurrencyStamp = "dc0a117f-5dc8-4f65-b13e-28517a987bd9",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = "2965d307-de8e-4917-96b2-5aa40dce3f83",
                            ConcurrencyStamp = "f47a3a67-b270-4651-b638-ab023b260648",
                            Name = "Salesperson",
                            NormalizedName = "SALESPERSON"
                        },
                        new
                        {
                            Id = "cc691c8c-d7ab-43b4-af45-b001e1a7af8c",
                            ConcurrencyStamp = "2d638904-7d5f-4dde-9df3-b06bb882e2a6",
                            Name = "Visitor",
                            NormalizedName = "VISITOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "c3f95308-0d7e-4125-80ac-94b75420a0e6",
                            RoleId = "3d673303-1204-487b-8428-c1aa60346921"
                        },
                        new
                        {
                            UserId = "6e492dff-11cd-45f1-87a9-9b1d04b7f4b7",
                            RoleId = "5787e5ac-47eb-4ffc-83df-3ead7a33ed3c"
                        },
                        new
                        {
                            UserId = "825ddba5-4393-44de-849c-b655151fda95",
                            RoleId = "2965d307-de8e-4917-96b2-5aa40dce3f83"
                        },
                        new
                        {
                            UserId = "59dc85ee-dc82-4815-b667-91fe4a5764d8",
                            RoleId = "cc691c8c-d7ab-43b4-af45-b001e1a7af8c"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("KiwiLadyShoes.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("KiwiLadyShoes.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KiwiLadyShoes.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("KiwiLadyShoes.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}