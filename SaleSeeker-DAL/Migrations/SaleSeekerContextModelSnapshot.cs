﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleSeeker_DAL;

#nullable disable

namespace SaleSeeker_DAL.Migrations
{
    [DbContext(typeof(SaleSeekerContext))]
    partial class SaleSeekerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Balance")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCheckedOut")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "audio"
                        },
                        new
                        {
                            Id = 2,
                            Name = "cellphones"
                        },
                        new
                        {
                            Id = 3,
                            Name = "computers"
                        });
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalBalance")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("UpdatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Variant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Apple",
                            CategoryId = 1,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(1121),
                            Description = "Originally offered only on the AirPods Pro & Max, the 3rd generation of Apple AirPods with Charging Case now feature spatial audio technology with dynamic head tracking, and Dolby Atmos compatibilit",
                            Images = "https://media.techeblog.com/images/apple-airpods-3.jpg",
                            IsActive = true,
                            Name = "Apple AirPods",
                            PricePerUnit = 4300.30m,
                            Quantity = 100,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3298),
                            Variant = "(3rd generation)"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            CategoryId = 2,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3918),
                            Description = "iPhone 15 Plus at its best with exceptional materials, super high-resolution photos, and Dynamic Is island",
                            Images = "https://m.xcite.com/media/catalog/product//i/p/iphone_14_pro_-_black_1_4.jpg",
                            IsActive = true,
                            Name = "Apple iPhone 15 Plus 128GB",
                            PricePerUnit = 24200.50m,
                            Quantity = 50,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3920),
                            Variant = "White"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "Apple",
                            CategoryId = 3,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3923),
                            Description = "macOS is the most advanced desktop operating system in the world. macOS Ventura makes the things you do most on Mac even better, so you can work smarter, play harder, and go further.",
                            Images = "https://alphastore.com.kw/wp-content/uploads/2020/11/13-inch-MacBook-Pro-M1-chip-8-C-CPU-8GB-8-C-GPU-256GB-SSD_1-scaled.jpg",
                            IsActive = true,
                            Name = "Apple Macbook PRO with M2 chip 12 core CPU 19 core GPU, 1TB SSD - Space Grey",
                            PricePerUnit = 55500.00m,
                            Quantity = 20,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3924),
                            Variant = "14inch"
                        });
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SoldQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableQuantity = 10,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(4656),
                            IsActive = true,
                            ProductId = 1,
                            SoldQuantity = 100,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(5146)
                        },
                        new
                        {
                            Id = 2,
                            AvailableQuantity = 100,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6927),
                            IsActive = true,
                            ProductId = 2,
                            SoldQuantity = 100,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6928)
                        },
                        new
                        {
                            Id = 3,
                            AvailableQuantity = 10,
                            CreatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6931),
                            IsActive = true,
                            ProductId = 3,
                            SoldQuantity = 100,
                            UpdatedDatetime = new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6932)
                        });
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = "74141dd4-94db-46ce-b6f4-7663e5cfc6a1",
                            RoleName = "Admin",
                            UserId = "ca41fc55-2245-45ef-9344-3b410177e5c8"
                        },
                        new
                        {
                            Id = 2,
                            RoleId = "0e297b8a-4806-4302-b59b-b84f8d9ec668",
                            RoleName = "Seller",
                            UserId = "23d1e052-6455-4366-adc3-9528bc5852e6"
                        },
                        new
                        {
                            Id = 3,
                            RoleId = "08704695-35bb-42f3-b5dc-ce220c0824ef",
                            RoleName = "Buyer",
                            UserId = "7c205bc3-dac2-489a-873b-b5ff3479ef78"
                        },
                        new
                        {
                            Id = 4,
                            RoleId = "08704695-35bb-42f3-b5dc-ce220c0824ef",
                            RoleName = "Buyer",
                            UserId = "5a251c9a-3c64-467b-b0c8-ced998e93b1b"
                        });
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AvailableCredit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDatetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreferredPaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Role", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Role");

                    b.HasData(
                        new
                        {
                            Id = "74141dd4-94db-46ce-b6f4-7663e5cfc6a1",
                            ConcurrencyStamp = "32e5d2c8-6ab2-46d8-88e4-e7e26042abf1",
                            Name = "Admin",
                            IsActive = true
                        },
                        new
                        {
                            Id = "0e297b8a-4806-4302-b59b-b84f8d9ec668",
                            ConcurrencyStamp = "385fccbe-024a-4d7e-9659-421bd8607236",
                            Name = "Seller",
                            IsActive = true
                        },
                        new
                        {
                            Id = "08704695-35bb-42f3-b5dc-ce220c0824ef",
                            ConcurrencyStamp = "a4e49fc6-dc42-41b5-8e30-21da0a2f36f2",
                            Name = "Buyer",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "ca41fc55-2245-45ef-9344-3b410177e5c8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d7496e25-640f-4123-a253-aaa028b20f84",
                            Email = "mrbtmkhabela@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "123",
                            PhoneNumber = "0810000003",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5474fdfd-e3a7-4bc5-95b6-62243d0a9f10",
                            TwoFactorEnabled = false,
                            Address = "4 Sout Road, Cape Town, South Africa",
                            CreatedDateTime = new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(1137),
                            IsActive = true,
                            Name = "Brian",
                            Salt = "",
                            SurName = "Mkhabela"
                        },
                        new
                        {
                            Id = "23d1e052-6455-4366-adc3-9528bc5852e6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "189280aa-0ecf-4fb2-a695-b36c893fa786",
                            Email = "mrbtmkhabela+0@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "123",
                            PhoneNumber = "0810000002",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ded41dec-12fa-47ce-a7c3-37a03bfe9464",
                            TwoFactorEnabled = false,
                            Address = "5 Mills Road, Cape Town, South Africa",
                            CreatedDateTime = new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2808),
                            IsActive = true,
                            Name = "Brian-Seller",
                            Salt = "",
                            SurName = "Mkhabela"
                        },
                        new
                        {
                            Id = "7c205bc3-dac2-489a-873b-b5ff3479ef78",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5aaa6357-e277-4f6e-b729-fa8564f678a3",
                            Email = "mrbtmkhabela+1@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "123",
                            PhoneNumber = "0810000001",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ca35557b-e975-437c-98c7-ce156c702ef3",
                            TwoFactorEnabled = false,
                            Address = "6 Sout Road, Cape Town, South Africa",
                            CreatedDateTime = new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2830),
                            IsActive = true,
                            Name = "Brian-Buyer-1",
                            Salt = "",
                            SurName = "Mkhabela-Buyer-1"
                        },
                        new
                        {
                            Id = "5a251c9a-3c64-467b-b0c8-ced998e93b1b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "66816644-d051-4844-8f81-17defa16ca3f",
                            Email = "mrbtmkhabela+2@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "125",
                            PhoneNumber = "0810000010",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d8ac71d0-a1cf-4bb4-889e-8ac03f4e8b4f",
                            TwoFactorEnabled = false,
                            Address = "7 Sout Road, Cape Town, South Africa",
                            CreatedDateTime = new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2841),
                            IsActive = true,
                            Name = "Brian-Buyer-2",
                            Salt = "",
                            SurName = "Mkhabela-Buyer-2"
                        });
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Cart", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Item", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("SaleSeeker_DAL.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("SaleSeeker_DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("SaleSeeker_DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Cart");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Order", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Product", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Stock", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Wallet", b =>
                {
                    b.HasOne("SaleSeeker_DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SaleSeeker_DAL.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}