using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Areas.Cms.Controllers;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Core.Services;
using Xunit;

namespace SimplCommerce.Module.Cms.Tests.Controllers
{
    public class PageControllerTests
    {
        [Fact]
        public void PageDetail_ShouldReturns_CorrectModelType()
        {
            var mock = new Mock<IRepository<Page>>();
            mock.Setup(x => x.Query()).Returns(new List<Page>() { new Page() { Name = "Page" } }.AsQueryable());
            var pageController = new PageController(mock.Object, new Mock<IContentLocalizationService>().Object);

            var result = pageController.PageDetail(It.IsAny<long>()) as ViewResult;
            
            Assert.IsType<PageVm>(result?.ViewData.Model);
        }
    }
}
