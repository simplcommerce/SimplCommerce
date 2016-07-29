using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimplCommerce.WebHost.Migrations
{
    public partial class addCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog_Brand",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 5000, nullable: true),
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
                    table.PrimaryKey("PK_Catalog_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Category_Catalog_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Catalog_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductAttributeGroup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductAttributeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductOption",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductTemplate", x => x.Id);
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
                name: "Catalog_ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Catalog_ProductAttributeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandId = table.Column<long>(nullable: true),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    HasOptions = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsVisibleIndividually = table.Column<bool>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: true),
                    MetaKeywords = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    OldPrice = table.Column<decimal>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PublishedOn = table.Column<DateTime>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    ThumbnailImageId = table.Column<long>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Product_Catalog_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Catalog_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Product_Core_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Product_Core_Media_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Product_Core_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Core_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductTemplateProductAttribute",
                columns: table => new
                {
                    ProductTemplateId = table.Column<long>(nullable: false),
                    ProductAttributeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductTemplateProductAttribute", x => new { x.ProductTemplateId, x.ProductAttributeId });
                    table.ForeignKey(
                        name: "FK_Catalog_ProductTemplateProductAttribute_Catalog_ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "Catalog_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductTemplateProductAttribute_Catalog_ProductTemplate_ProductTemplateId",
                        column: x => x.ProductTemplateId,
                        principalTable: "Catalog_ProductTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductAttributeValue",
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
                    table.PrimaryKey("PK_Catalog_ProductAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Catalog_ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductCategory",
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
                    table.PrimaryKey("PK_Catalog_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductCategory_Catalog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catalog_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductCategory_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductLink",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkType = table.Column<int>(nullable: false),
                    LinkedProductId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId",
                        column: x => x.LinkedProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductLink_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductMedia",
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
                    table.PrimaryKey("PK_Catalog_ProductMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductMedia_Core_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Core_Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductMedia_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductOptionCombination",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<long>(nullable: false),
                    ProducdtId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog_ProductOptionCombination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Catalog_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Catalog_ProductOptionValue",
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
                    table.PrimaryKey("PK_Catalog_ProductOptionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Catalog_ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Catalog_Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Category_ParentId",
                table: "Catalog_Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_BrandId",
                table: "Catalog_Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_CreatedById",
                table: "Catalog_Product",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_ThumbnailImageId",
                table: "Catalog_Product",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_Product_UpdatedById",
                table: "Catalog_Product",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductAttribute_GroupId",
                table: "Catalog_ProductAttribute",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductAttributeValue_AttributeId",
                table: "Catalog_ProductAttributeValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductAttributeValue_ProductId",
                table: "Catalog_ProductAttributeValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductCategory_CategoryId",
                table: "Catalog_ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductCategory_ProductId",
                table: "Catalog_ProductCategory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductLink_LinkedProductId",
                table: "Catalog_ProductLink",
                column: "LinkedProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductLink_ProductId",
                table: "Catalog_ProductLink",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductMedia_MediaId",
                table: "Catalog_ProductMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductMedia_ProductId",
                table: "Catalog_ProductMedia",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductOptionCombination_OptionId",
                table: "Catalog_ProductOptionCombination",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductOptionCombination_ProductId",
                table: "Catalog_ProductOptionCombination",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductOptionValue_OptionId",
                table: "Catalog_ProductOptionValue",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductOptionValue_ProductId",
                table: "Catalog_ProductOptionValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductTemplateProductAttribute_ProductAttributeId",
                table: "Catalog_ProductTemplateProductAttribute",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_ProductTemplateProductAttribute_ProductTemplateId",
                table: "Catalog_ProductTemplateProductAttribute",
                column: "ProductTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog_ProductAttributeValue");

            migrationBuilder.DropTable(
                name: "Catalog_ProductCategory");

            migrationBuilder.DropTable(
                name: "Catalog_ProductLink");

            migrationBuilder.DropTable(
                name: "Catalog_ProductMedia");

            migrationBuilder.DropTable(
                name: "Catalog_ProductOptionCombination");

            migrationBuilder.DropTable(
                name: "Catalog_ProductOptionValue");

            migrationBuilder.DropTable(
                name: "Catalog_ProductTemplateProductAttribute");

            migrationBuilder.DropTable(
                name: "Core_UrlSlug");

            migrationBuilder.DropTable(
                name: "Catalog_Category");

            migrationBuilder.DropTable(
                name: "Catalog_ProductOption");

            migrationBuilder.DropTable(
                name: "Catalog_Product");

            migrationBuilder.DropTable(
                name: "Catalog_ProductAttribute");

            migrationBuilder.DropTable(
                name: "Catalog_ProductTemplate");

            migrationBuilder.DropTable(
                name: "Catalog_Brand");

            migrationBuilder.DropTable(
                name: "Core_Media");

            migrationBuilder.DropTable(
                name: "Catalog_ProductAttributeGroup");
        }
    }
}
