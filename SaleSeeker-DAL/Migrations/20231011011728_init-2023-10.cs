using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleSeeker_DAL.Migrations
{
    public partial class init202310 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCheckedOut = table.Column<bool>(type: "bit", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalBalance = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PreferredPaymentMethod = table.Column<int>(type: "int", nullable: false),
                    AvailableCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    SoldQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08704695-35bb-42f3-b5dc-ce220c0824ef", "a4e49fc6-dc42-41b5-8e30-21da0a2f36f2", "Role", true, "Buyer", null },
                    { "0e297b8a-4806-4302-b59b-b84f8d9ec668", "385fccbe-024a-4d7e-9659-421bd8607236", "Role", true, "Seller", null },
                    { "74141dd4-94db-46ce-b6f4-7663e5cfc6a1", "32e5d2c8-6ab2-46d8-88e4-e7e26042abf1", "Role", true, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedDateTime", "Discriminator", "Email", "EmailConfirmed", "IsActive", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salt", "SecurityStamp", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "23d1e052-6455-4366-adc3-9528bc5852e6", 0, "5 Mills Road, Cape Town, South Africa", "189280aa-0ecf-4fb2-a695-b36c893fa786", new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2808), "User", "mrbtmkhabela+0@gmail.com", false, true, false, null, "Brian-Seller", null, null, "123", "0810000002", false, "", "ded41dec-12fa-47ce-a7c3-37a03bfe9464", "Mkhabela", false, null },
                    { "5a251c9a-3c64-467b-b0c8-ced998e93b1b", 0, "7 Sout Road, Cape Town, South Africa", "66816644-d051-4844-8f81-17defa16ca3f", new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2841), "User", "mrbtmkhabela+2@gmail.com", false, true, false, null, "Brian-Buyer-2", null, null, "125", "0810000010", false, "", "d8ac71d0-a1cf-4bb4-889e-8ac03f4e8b4f", "Mkhabela-Buyer-2", false, null },
                    { "7c205bc3-dac2-489a-873b-b5ff3479ef78", 0, "6 Sout Road, Cape Town, South Africa", "5aaa6357-e277-4f6e-b729-fa8564f678a3", new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(2830), "User", "mrbtmkhabela+1@gmail.com", false, true, false, null, "Brian-Buyer-1", null, null, "123", "0810000001", false, "", "ca35557b-e975-437c-98c7-ce156c702ef3", "Mkhabela-Buyer-1", false, null },
                    { "ca41fc55-2245-45ef-9344-3b410177e5c8", 0, "4 Sout Road, Cape Town, South Africa", "d7496e25-640f-4123-a253-aaa028b20f84", new DateTime(2023, 10, 11, 3, 17, 27, 113, DateTimeKind.Local).AddTicks(1137), "User", "mrbtmkhabela@gmail.com", false, true, false, null, "Brian", null, null, "123", "0810000003", false, "", "5474fdfd-e3a7-4bc5-95b6-62243d0a9f10", "Mkhabela", false, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "audio" },
                    { 2, "cellphones" },
                    { 3, "computers" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "RoleName", "UserId" },
                values: new object[,]
                {
                    { 1, "74141dd4-94db-46ce-b6f4-7663e5cfc6a1", "Admin", "ca41fc55-2245-45ef-9344-3b410177e5c8" },
                    { 2, "0e297b8a-4806-4302-b59b-b84f8d9ec668", "Seller", "23d1e052-6455-4366-adc3-9528bc5852e6" },
                    { 3, "08704695-35bb-42f3-b5dc-ce220c0824ef", "Buyer", "7c205bc3-dac2-489a-873b-b5ff3479ef78" },
                    { 4, "08704695-35bb-42f3-b5dc-ce220c0824ef", "Buyer", "5a251c9a-3c64-467b-b0c8-ced998e93b1b" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDatetime", "Description", "Images", "IsActive", "Name", "PricePerUnit", "Quantity", "UpdatedDatetime", "Variant" },
                values: new object[] { 1, "Apple", 1, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(1121), "Originally offered only on the AirPods Pro & Max, the 3rd generation of Apple AirPods with Charging Case now feature spatial audio technology with dynamic head tracking, and Dolby Atmos compatibilit", "https://media.techeblog.com/images/apple-airpods-3.jpg", true, "Apple AirPods", 4300.30m, 100, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3298), "(3rd generation)" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDatetime", "Description", "Images", "IsActive", "Name", "PricePerUnit", "Quantity", "UpdatedDatetime", "Variant" },
                values: new object[] { 2, "Apple", 2, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3918), "iPhone 15 Plus at its best with exceptional materials, super high-resolution photos, and Dynamic Is island", "https://m.xcite.com/media/catalog/product//i/p/iphone_14_pro_-_black_1_4.jpg", true, "Apple iPhone 15 Plus 128GB", 24200.50m, 50, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3920), "White" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedDatetime", "Description", "Images", "IsActive", "Name", "PricePerUnit", "Quantity", "UpdatedDatetime", "Variant" },
                values: new object[] { 3, "Apple", 3, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3923), "macOS is the most advanced desktop operating system in the world. macOS Ventura makes the things you do most on Mac even better, so you can work smarter, play harder, and go further.", "https://alphastore.com.kw/wp-content/uploads/2020/11/13-inch-MacBook-Pro-M1-chip-8-C-CPU-8GB-8-C-GPU-256GB-SSD_1-scaled.jpg", true, "Apple Macbook PRO with M2 chip 12 core CPU 19 core GPU, 1TB SSD - Space Grey", 55500.00m, 20, new DateTime(2023, 10, 11, 3, 17, 27, 115, DateTimeKind.Local).AddTicks(3924), "14inch" });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "AvailableQuantity", "CreatedDatetime", "IsActive", "ProductId", "SoldQuantity", "UpdatedDatetime" },
                values: new object[] { 1, 10, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(4656), true, 1, 100, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(5146) });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "AvailableQuantity", "CreatedDatetime", "IsActive", "ProductId", "SoldQuantity", "UpdatedDatetime" },
                values: new object[] { 2, 100, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6927), true, 2, 100, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6928) });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "AvailableQuantity", "CreatedDatetime", "IsActive", "ProductId", "SoldQuantity", "UpdatedDatetime" },
                values: new object[] { 3, 10, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6931), true, 3, 100, new DateTime(2023, 10, 11, 3, 17, 27, 116, DateTimeKind.Local).AddTicks(6932) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CartId",
                table: "Items",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProductId",
                table: "Items",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
