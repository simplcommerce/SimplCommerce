using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private const string CategoryEntityTypeId = "Category";

        private readonly IRepository<Category> _categoryRepository;
        private readonly IEntityService _entityService;

        public CategoryService(IRepository<Category> categoryRepository, IEntityService entityService)
        {
            _categoryRepository = categoryRepository;
            _entityService = entityService;
        }

        public async Task<IList<CategoryListItem>> GetAll()
        {
            var categories = await _categoryRepository.Query().Where(x => !x.IsDeleted).ToListAsync();
            var categoriesList = new List<CategoryListItem>();
            foreach (var category in categories)
            {
                var categoryListItem = new CategoryListItem
                {
                    Id = category.Id,
                    IsPublished = category.IsPublished,
                    IncludeInMenu = category.IncludeInMenu,
                    Name = category.Name,
                    DisplayOrder = category.DisplayOrder,
                    ParentId = category.ParentId
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

        public async Task<Category> Create(CategoryForm model, string thumbnailImageName)
        {
            using (var transaction = _categoryRepository.BeginTransaction())
            {
                Category parent = null;
                var category = Map(model, new Category());

                if (!string.IsNullOrEmpty(thumbnailImageName))
                {
                    category.ThumbnailImage = new Media { FileName = thumbnailImageName };
                }

                if (model.ParentId.HasValue)
                {
                    parent = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == model.ParentId.Value);

                    if (parent != null)
                    {
                        parent.AddChild(category);
                    }
                }

                category.Slug = _entityService.ToSafeSlug(category.Slug, category.Id, CategoryEntityTypeId);

                _categoryRepository.Add(category);

                await _categoryRepository.SaveChangesAsync();

                _entityService.Add(category.Name, category.Slug, category.Id, CategoryEntityTypeId);

                if (parent != null)
                {
                    parent.ApplyPathAsForRoot();
                }
                else
                {
                    category.ApplyPathAsForRoot();
                }

                await _categoryRepository.SaveChangesAsync();

                transaction.Commit();

                return category;
            }
        }

        public async Task Update(long id, CategoryForm model, string thumbnailImageName)
        {
            var downStreamBranchItems = await (from pathSrc in _categoryRepository.Query().Where(x => x.Id == id)
                                               from categories in _categoryRepository.Query().Where(c => c.Path.StartsWith(pathSrc.Path))
                                               select categories)
                                        .ToArrayAsync();

            var category = downStreamBranchItems.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new NotFoundException();
            }

            Map(model, category);

            if (!string.IsNullOrWhiteSpace(thumbnailImageName))
            {
                if (category.ThumbnailImage != null)
                {
                    category.ThumbnailImage.FileName = thumbnailImageName;
                }
                else
                {
                    category.ThumbnailImage = new Media { FileName = thumbnailImageName };
                }
            }

            if (model.ParentId.HasValue)
            {
                var upStreamBranchItems = await (from pathSrc in _categoryRepository.Query().Where(x => x.Id == model.ParentId.Value)
                                                 from categories in _categoryRepository.Query().Where(c => pathSrc.Path.StartsWith(c.Path))
                                                 select categories)
                                            .ToArrayAsync();

                if (HaveCircularNesting(category, upStreamBranchItems))
                {
                    throw new ValidationException("ParentId", "Parent category cannot be itself children");
                }

                var parent = upStreamBranchItems.First(x => x.Id == model.ParentId.Value);

                parent.AddChild(category);
                parent.ApplyPathAsForRoot();
            }

            category.Slug = _entityService.ToSafeSlug(category.Slug, category.Id, CategoryEntityTypeId);

            _entityService.Update(category.Name, category.Slug, category.Id, CategoryEntityTypeId);

            await _categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            await _entityService.Remove(category.Id, CategoryEntityTypeId);
            category.IsDeleted = true;
            _categoryRepository.SaveChanges();
        }

        private bool HaveCircularNesting(Category child, IEnumerable<Category> branch)
        {
            foreach (var parentItem in branch)
            {
                if (parentItem.Id == child.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private Category Map(CategoryForm src, Category dest)
        {
            dest.Name = src.Name;
            dest.Slug = src.Slug;
            dest.MetaTitle = src.MetaTitle;
            dest.MetaKeywords = src.MetaKeywords;
            dest.MetaDescription = src.MetaDescription;
            dest.DisplayOrder = src.DisplayOrder;
            dest.Description = src.Description;
            dest.IncludeInMenu = src.IncludeInMenu;
            dest.IsPublished = src.IsPublished;

            return dest;
        }
    }
}
