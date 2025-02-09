using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Mappers
{
    public class CatalogAutoMapperProfile : Profile
    {
        public CatalogAutoMapperProfile()
        {
            CreateMap<Category, CategoryForm>()
            .ForMember(dest => dest.ThumbnailImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.ThumbnailImage, opt => opt.Ignore());
        }
    }
}
