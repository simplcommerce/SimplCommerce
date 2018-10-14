using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Areas.Cms.Controllers;
using SimplCommerce.Module.Cms.Models;
using Xunit;

namespace SimplCommerce.Module.Cms.Tests.Controllers
{
    public class PageControllerTests
    {
        [Fact]
        public void PageDetail_ShouldReturns_PageWithName()
        {
            Mock<IRepository<Page>> pageRepository = MakePageRepository();
            var pageController = new PageController(pageRepository.Object);

            var result = pageController.PageDetail(It.IsAny<long>()) as ViewResult;

            Assert.Equal("Page", (result?.ViewData.Model as Page)?.Name);
        }

        [Fact]
        public void PageDetail_ShouldReturns_CorrectModelType()
        {
            var mock = new Mock<IRepository<Page>>();
            mock.Setup(x => x.Query()).Returns(new List<Page>() { new Page() { Name = "Page" } }.AsQueryable());
            var pageController = new PageController(mock.Object);

            var result = pageController.PageDetail(It.IsAny<long>()) as ViewResult;
            
            Assert.IsType<Page>(result?.ViewData.Model);
        }

        private Mock<IRepository<Page>> MakePageRepository()
        {
            var pageRepository = new Mock<IRepository<Page>>();
            pageRepository.Setup(x => x.Query()).Returns(new List<Page>() { new Page() { Name = "Page" } }.AsQueryable());
            return pageRepository;
        }
    }
}
