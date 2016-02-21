using System.Collections.Generic;
using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Web.Areas.Admin.ViewModels;

namespace HvCommerce.Web.Areas.Admin.Helpers
{
    public static class CategoryMapper
    {
        public static IList<CategoryListItem> ToCategoryListItem(IList<Category> categories)
        {
            var categoriesList = new List<CategoryListItem>();
            foreach (var category in categories)
            {
                var categoryListItem = new CategoryListItem
                {
                    Id = category.Id,
                    IsPublished = category.IsPublished,
                    Name = category.Name
                };

                var parentCategory = category.Parent;
                while (parentCategory != null)
                {
                    categoryListItem.Name = $"{parentCategory.Name} >> {categoryListItem.Name}";
                    parentCategory = parentCategory.Parent;
                }

                categoriesList.Add(categoryListItem);
            }

            return categoriesList.OrderBy(x => x.Name).ToList();
        }
    }
}