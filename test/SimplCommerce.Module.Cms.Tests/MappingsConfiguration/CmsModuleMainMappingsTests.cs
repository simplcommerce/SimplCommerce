using AutoMapper;
using SimplCommerce.Module.Cms.MappingsConfiguration;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;
using Xunit;

namespace SimplCommerce.Module.Cms.Tests.MappingsConfiguration
{
    public class CmsModuleMainMappingsTests
    {
        [Fact]
        public void Map_ShouldMap_FromPageToPageFormInstance()
        {
            var mapper = GetMapper();
            var page = new Page()
            {
                Name = "Page"
            };

            var pageForm = mapper.Map<Page, PageForm>(page);

            Assert.NotNull(pageForm);
        }

        [Fact]
        public void Map_ShouldMap_FromPageFormToPageInstance()
        {
            var mapper = GetMapper();
            var pageForm = new PageForm()
            {
                Name = "Page"
            };

            var page = mapper.Map<PageForm, Page>(pageForm);

            Assert.NotNull(page);
        }

        [Fact]
        public void Map_ShouldMap_FromWidgetInstanceToCarouselWidgetForm()
        {
            var mapper = GetMapper();
            var widgetInstance = new WidgetInstance()
            {
                Name = "Test instance"
            };

            var carouselWidgetForm = mapper.Map<WidgetInstance, CarouselWidgetForm>(widgetInstance);

            Assert.NotNull(carouselWidgetForm);
        }   

        [Fact]
        public void Map_ShouldMap_FromCarouselWidgetFormToWidgetInstance()
        {
            var mapper = GetMapper();
            var carouselWidgetForm = new CarouselWidgetForm()
            {
                Name = "Test instance"
            };

            var widgetInstance = mapper.Map<CarouselWidgetForm, WidgetInstance>(carouselWidgetForm);

            Assert.NotNull(widgetInstance);
        }

        [Fact]
        public void Map_ShouldMap_FromWidgetInstanceToHtmlWidgetForm()
        {
            var mapper = GetMapper();
            var widgetInstance = new WidgetInstance()
            {   
                Name = "Test instance"
            };

            var htmlWidgetForm = mapper.Map<WidgetInstance, HtmlWidgetForm>(widgetInstance);
                
            Assert.NotNull(htmlWidgetForm);
        }

        [Fact]
        public void Map_ShouldMap_FromHtmlWidgetFormToWidgetInstance()
        {
            var mapper = GetMapper();
            var htmlWidgetForm = new HtmlWidgetForm()
            {
                Name = "Test instance"
            };

            var widgetInstance = mapper.Map<HtmlWidgetForm, WidgetInstance>(htmlWidgetForm);    

            Assert.NotNull(widgetInstance);
        }

        private IMapper GetMapper()
        {
            Mapper.Initialize(m => m.AddProfile(new CmsModuleMainMappings()));
            MapperConfiguration configurationProvider = new MapperConfiguration(x => x.AddProfile(new CmsModuleMainMappings()));
            IMapper mapper = new Mapper(configurationProvider);
            return mapper;
        }
    }
}
