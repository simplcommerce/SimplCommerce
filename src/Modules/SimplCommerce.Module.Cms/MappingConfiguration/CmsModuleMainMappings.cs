using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Cms.MappingConfiguration
{   
    public class CmsModuleMainMappings : Profile
    {
        public CmsModuleMainMappings()
        {
            CreateMap<Page, PageForm>().ReverseMap();

            CreateMap<WidgetInstance, CarouselWidgetForm>()
                .ForMember(w=>w.Items,
                    f => f.MapFrom(src => JsonConvert.DeserializeObject<IList<CarouselWidgetItemForm>>(src.Data)));
            CreateMap<CarouselWidgetForm, WidgetInstance>()
                .ForMember(w => w.Data,
                    f => f.MapFrom(src => JsonConvert.SerializeObject(src.Items)));

            CreateMap<WidgetInstance, HtmlWidgetForm>().ReverseMap();
        }
    }
}
