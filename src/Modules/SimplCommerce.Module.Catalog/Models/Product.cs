using System;
using System.Collections.Generic;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Catalog.Models
{
    public class Product : Content
    {
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTimeOffset? SpecialPriceStart { get; set; }

        public DateTimeOffset? SpecialPriceEnd { get; set; }

        public bool HasOptions { get; set; }

        public bool IsVisibleIndividually { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public string Sku { get; set; }

        public string NormalizedName { get; set; }

        public int DisplayOrder { get; set; }

        public Media ThumbnailImage { get; set; }

        public IList<ProductMedia> Medias { get; protected set; } = new List<ProductMedia>();

        public IList<ProductLink> ProductLinks { get; protected set; } = new List<ProductLink>();

        public IList<ProductLink> LinkedProductLinks { get; protected set; } = new List<ProductLink>();

        public IList<ProductAttributeValue> AttributeValues { get; protected set; } = new List<ProductAttributeValue>();

        public IList<ProductOptionValue> OptionValues { get; protected set; } = new List<ProductOptionValue>();

        public IList<ProductCategory> Categories { get; protected set; } = new List<ProductCategory>();

        public int ReviewsCount { get; set; }

        public double? RatingAverage { get; set; }

        public long? BrandId { get; set; }

        public Brand Brand { get; set; }

        public void AddCategory(ProductCategory category)
        {
            category.Product = this;
            Categories.Add(category);
        }

        public void AddMedia(ProductMedia media)
        {
            media.Product = this;
            Medias.Add(media);
        }

        public void RemoveMedia(ProductMedia media)
        {
            media.Product = null;
            Medias.Remove(media);
        }

        public void AddAttributeValue(ProductAttributeValue attributeValue)
        {
            attributeValue.Product = this;
            AttributeValues.Add(attributeValue);
        }

        public void AddOptionValue(ProductOptionValue optionValue)
        {
            optionValue.Product = this;
            OptionValues.Add(optionValue);
        }

        public void AddProductLinks(ProductLink productLink)
        {
            productLink.Product = this;
            ProductLinks.Add(productLink);
        }

        public virtual IList<ProductOptionCombination> OptionCombinations { get; protected set; } = new List<ProductOptionCombination>();

        public void AddOptionCombination(ProductOptionCombination combination)
        {
            combination.Product = this;
            OptionCombinations.Add(combination);
        }

        public Product Clone()
        {
            var product = new Product();
            product.Name = Name;
            product.MetaTitle = MetaTitle;
            product.MetaKeywords = MetaKeywords;
            product.MetaDescription = MetaDescription;
            product.ShortDescription = ShortDescription;
            product.Description = Description;
            product.Specification = Specification;
            product.IsPublished = true;
            product.PublishedOn = DateTimeOffset.Now;
            product.Price = Price;
            product.OldPrice = OldPrice;
            product.IsAllowToOrder = IsAllowToOrder;
            product.IsCallForPricing = IsCallForPricing;
            product.StockQuantity = StockQuantity;
            product.BrandId = BrandId;

            foreach (var attribute in AttributeValues)
            {
                product.AddAttributeValue(new ProductAttributeValue
                {
                    AttributeId = attribute.AttributeId,
                    Value = attribute.Value
                });
            }

            foreach (var category in Categories)
            {
                product.AddCategory(new ProductCategory
                {
                    CategoryId = category.CategoryId
                });
            }

            return product;
        }
    }
}
