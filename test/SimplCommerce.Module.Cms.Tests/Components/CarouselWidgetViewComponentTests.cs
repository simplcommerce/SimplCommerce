using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using Newtonsoft.Json;
using SimplCommerce.Module.Cms.Components;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;
using Xunit;

namespace SimplCommerce.Module.Cms.Tests.Components
{
    public class CarouselWidgetViewComponentTests
    {
        [Fact]
        public void CarouselWidgetViewComponent_ShouldReturns_NotNullView()
        {
            var mediaService = new Mock<IMediaService>();
            var widgetInstanceViewModel = WidgetInstanceViewModel();
            mediaService.Setup(x => x.GetMediaUrl(It.IsAny<string>())).Returns(It.IsAny<string>());
            var component = new CarouselWidgetViewComponent(mediaService.Object);

            var view = component.Invoke(widgetInstanceViewModel) as ViewViewComponentResult;

            Assert.NotNull(view);
        }

        [Fact]
        public void CarouselWidgetViewComponent_ForAllImages_GetMediaUrlWasCalled()
        {
            const int numberOfImagesOnWidgetInstanceViewModel = 1;
            var mockMediaService = new Mock<IMediaService>();
            var widgetInstanceViewModel = WidgetInstanceViewModel();
            mockMediaService.Setup(x => x.GetMediaUrl(It.IsAny<string>())).Returns(It.IsAny<string>());
            var component = new CarouselWidgetViewComponent(mockMediaService.Object);

            component.Invoke(widgetInstanceViewModel);

            mockMediaService.Verify(x=>x.GetMediaUrl(It.IsAny<string>()), Times.Exactly(numberOfImagesOnWidgetInstanceViewModel));
        }

        [Fact]
        public void CarouselWidgetViewComponent_PreparingViewModel_SuccesfulyDeserializedOneCarouselWidgetViewComponentVmInstance()
        {
            var mockMediaService = new Mock<IMediaService>();
            var widgetInstanceViewModel = WidgetInstanceViewModel();
            mockMediaService.Setup(x => x.GetMediaUrl(It.IsAny<string>())).Returns(It.IsAny<string>());
            var component = new CarouselWidgetViewComponent(mockMediaService.Object);

            var result = component.Invoke(widgetInstanceViewModel) as ViewViewComponentResult;
            var returnedModel = (result?.ViewData.Model as CarouselWidgetViewComponentVm);

            Assert.Equal(1, returnedModel?.Items.Count);
        }

        [Fact]
        public void CarouselWidgetViewComponent_ShouldReturns_CorrectModelType()
        {
            var mockMediaService = new Mock<IMediaService>();
            var widgetInstanceViewModel = WidgetInstanceViewModel();
            mockMediaService.Setup(x => x.GetMediaUrl(It.IsAny<string>())).Returns(It.IsAny<string>());
            var component = new CarouselWidgetViewComponent(mockMediaService.Object);

            var result = component.Invoke(widgetInstanceViewModel) as ViewViewComponentResult;
            
            Assert.IsType<CarouselWidgetViewComponentVm>(result?.ViewData.Model);
        }

        private WidgetInstanceViewModel WidgetInstanceViewModel()
        {
            return new WidgetInstanceViewModel()
            {
                Data = MakeCarouselWidgetViewModelsJson()
            };
        }

        private string MakeCarouselWidgetViewModelsJson()
        {
            var carouselWidgetViewModels = new List<CarouselWidgetViewComponentItemVm>()
            {   
                new CarouselWidgetViewComponentItemVm
                {
                    Caption = "Carousel Item",
                    TargetUrl = "localhost/",
                    Image = "item.jpg"
                },
            };

            return JsonConvert.SerializeObject(carouselWidgetViewModels);
        }
    }
}
