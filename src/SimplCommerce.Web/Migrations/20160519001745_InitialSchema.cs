using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.Web.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Core_UserToken",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Core_Brand",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Category_Core_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Core_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Media",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Caption = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductAttributeGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductAttributeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductOption",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_StringResource",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Culture = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_StringResource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_TempWard",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictId = table.Column<long>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    ProvinceName = table.Column<string>(nullable: true),
                    WardId = table.Column<long>(nullable: false),
                    WardName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_TempWard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_UrlSlug",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<long>(nullable: false),
                    EntityName = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UrlSlug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Core_StateOrProvince",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_StateOrProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_StateOrProvince_Core_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Core_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductAttribute_Core_ProductAttributeGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Core_ProductAttributeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_RoleClaim_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_District",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_District_Core_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "Core_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductTemplateProductAttribute",
                columns: table => new
                {
                    ProductTemplateId = table.Column<long>(nullable: false),
                    ProductAttributeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductTemplateProductAttribute", x => new { x.ProductTemplateId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_Core_ProductTemplateProductAttribute_Core_ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "Core_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductTemplateProductAttribute_Core_ProductTemplate_ProductTemplateId",
                        column: x => x.ProductTemplateId,
                        principalTable: "Core_ProductTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    DistrictId = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Address_Core_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Core_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Address_Core_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Core_District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "Core_StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserAddress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<long>(nullable: false),
                    AddressType = table.Column<int>(nullable: false),
                    LastUsedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserAddress_Core_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Core_Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CurrentShippingAddressId = table.Column<long>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_User_Core_UserAddress_CurrentShippingAddressId",
                        column: x => x.CurrentShippingAddressId,
                        principalTable: "Core_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_UserClaim_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_Core_UserLogin_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_UserRole",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Core_UserRole_Core_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Core_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_UserRole_Core_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_Page",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Page_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Page_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OldPrice = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PublishedOn = table.Column<DateTime>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    ThumbnailImageId = table.Column<long>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_Product_Core_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Core_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Product_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Product_Core_Media_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_Product_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillingAddressId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ShippingAddressId = table.Column<long>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_UserAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "Core_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Order_Core_UserAddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Core_UserAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductAttributeValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductAttributeValue_Core_ProductAttribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Core_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductAttributeValue_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<long>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsFeaturedProduct = table.Column<bool>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductCategory_Core_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Core_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductCategory_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductMedia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayOrder = table.Column<int>(nullable: false),
                    MediaId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductMedia_Core_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductMedia_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductOptionValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductOptionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductOptionValue_Core_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Core_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductOptionValue_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductVariation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    IsAllowOrder = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceOffset = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<long>(nullable: false),
                    ReasonNotAllowOrder = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductVariation_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Core_ProductOptionCombination",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    VariationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Core_ProductOptionCombination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Core_ProductOptionCombination_Core_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Core_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Core_ProductOptionCombination_Core_ProductVariation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "Core_ProductVariation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders_CartItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GuestId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    ProductVariationId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_CartItem_Core_ProductVariation_ProductVariationId",
                        column: x => x.ProductVariationId,
                        principalTable: "Core_ProductVariation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders_OrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductVariationId = table.Column<long>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItem_Orders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItem_Core_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Core_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderItem_Core_ProductVariation_ProductVariationId",
                        column: x => x.ProductVariationId,
                        principalTable: "Core_ProductVariation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Core_RoleClaim_RoleId",
                table: "Core_RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserClaim_UserId",
                table: "Core_UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserLogin_UserId",
                table: "Core_UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRole_RoleId",
                table: "Core_UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserRole_UserId",
                table: "Core_UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Address_CountryId",
                table: "Core_Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Address_DistrictId",
                table: "Core_Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Address_StateOrProvinceId",
                table: "Core_Address",
                column: "StateOrProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Category_ParentId",
                table: "Core_Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_District_StateOrProvinceId",
                table: "Core_District",
                column: "StateOrProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Page_CreatedById",
                table: "Core_Page",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Page_UpdatedById",
                table: "Core_Page",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Product_BrandId",
                table: "Core_Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Product_CreatedById",
                table: "Core_Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Product_ThumbnailImageId",
                table: "Core_Product",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_Product_UpdatedById",
                table: "Core_Product",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductAttribute_GroupId",
                table: "Core_ProductAttribute",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductAttributeValue_AttributeId",
                table: "Core_ProductAttributeValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductAttributeValue_ProductId",
                table: "Core_ProductAttributeValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductCategory_CategoryId",
                table: "Core_ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductCategory_ProductId",
                table: "Core_ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductMedia_MediaId",
                table: "Core_ProductMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductMedia_ProductId",
                table: "Core_ProductMedia",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionCombination_OptionId",
                table: "Core_ProductOptionCombination",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionCombination_VariationId",
                table: "Core_ProductOptionCombination",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionValue_OptionId",
                table: "Core_ProductOptionValue",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductOptionValue_ProductId",
                table: "Core_ProductOptionValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductTemplateProductAttribute_ProductAttributeId",
                table: "Core_ProductTemplateProductAttribute",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductTemplateProductAttribute_ProductTemplateId",
                table: "Core_ProductTemplateProductAttribute",
                column: "ProductTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_CreatedById",
                table: "Core_ProductVariation",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_ProductId",
                table: "Core_ProductVariation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_ProductVariation_UpdatedById",
                table: "Core_ProductVariation",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Core_Role",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_StateOrProvince_CountryId",
                table: "Core_StateOrProvince",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_User_CurrentShippingAddressId",
                table: "Core_User",
                column: "CurrentShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Core_User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Core_User",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserAddress_AddressId",
                table: "Core_UserAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Core_UserAddress_UserId",
                table: "Core_UserAddress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_CreatedById",
                table: "Orders_CartItem",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_ProductId",
                table: "Orders_CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartItem_ProductVariationId",
                table: "Orders_CartItem",
                column: "ProductVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_BillingAddressId",
                table: "Orders_Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_CreatedById",
                table: "Orders_Order",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Order_ShippingAddressId",
                table: "Orders_Order",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_OrderId",
                table: "Orders_OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_ProductId",
                table: "Orders_OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderItem_ProductVariationId",
                table: "Orders_OrderItem",
                column: "ProductVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress",
                column: "UserId",
                principalTable: "Core_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Core_UserAddress_Core_User_UserId",
                table: "Core_UserAddress");

            migrationBuilder.DropTable(
                name: "Core_RoleClaim");

            migrationBuilder.DropTable(
                name: "Core_UserClaim");

            migrationBuilder.DropTable(
                name: "Core_UserLogin");

            migrationBuilder.DropTable(
                name: "Core_UserRole");

            migrationBuilder.DropTable(
                name: "Core_UserToken");

            migrationBuilder.DropTable(
                name: "Core_Page");

            migrationBuilder.DropTable(
                name: "Core_ProductAttributeValue");

            migrationBuilder.DropTable(
                name: "Core_ProductCategory");

            migrationBuilder.DropTable(
                name: "Core_ProductMedia");

            migrationBuilder.DropTable(
                name: "Core_ProductOptionCombination");

            migrationBuilder.DropTable(
                name: "Core_ProductOptionValue");

            migrationBuilder.DropTable(
                name: "Core_ProductTemplateProductAttribute");

            migrationBuilder.DropTable(
                name: "Core_StringResource");

            migrationBuilder.DropTable(
                name: "Core_TempWard");

            migrationBuilder.DropTable(
                name: "Core_UrlSlug");

            migrationBuilder.DropTable(
                name: "Orders_CartItem");

            migrationBuilder.DropTable(
                name: "Orders_OrderItem");

            migrationBuilder.DropTable(
                name: "Core_Role");

            migrationBuilder.DropTable(
                name: "Core_Category");

            migrationBuilder.DropTable(
                name: "Core_ProductOption");

            migrationBuilder.DropTable(
                name: "Core_ProductAttribute");

            migrationBuilder.DropTable(
                name: "Core_ProductTemplate");

            migrationBuilder.DropTable(
                name: "Orders_Order");

            migrationBuilder.DropTable(
                name: "Core_ProductVariation");

            migrationBuilder.DropTable(
                name: "Core_ProductAttributeGroup");

            migrationBuilder.DropTable(
                name: "Core_Product");

            migrationBuilder.DropTable(
                name: "Core_Brand");

            migrationBuilder.DropTable(
                name: "Core_Media");

            migrationBuilder.DropTable(
                name: "Core_User");

            migrationBuilder.DropTable(
                name: "Core_UserAddress");

            migrationBuilder.DropTable(
                name: "Core_Address");

            migrationBuilder.DropTable(
                name: "Core_District");

            migrationBuilder.DropTable(
                name: "Core_StateOrProvince");

            migrationBuilder.DropTable(
                name: "Core_Country");
        }
    }
}
