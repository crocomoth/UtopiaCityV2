using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using UtopiaCity.Common;
using UtopiaCity.Controllers.Emergency;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;
using Xunit;

namespace UtopiaCityTest.Controllers
{
    public class EmergencyReportControllerTests : BaseControllerTest
    {
        private EmergencyReportController controller;
        private Mock<EmergencyReportService> serviceMock;
        private Mock<IOptions<AppConfig>> configOptionsMock;

        protected override void Setup()
        {
            base.Setup();

            configOptionsMock = new Mock<IOptions<AppConfig>>();
            var memoryCacheMock = new Mock<IMemoryCache>();
            var applicationDbContextMock = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            var dataProviderMock = new Mock<GenericDataProvider<EmergencyReport>>(applicationDbContextMock.Object, memoryCacheMock.Object, configOptionsMock.Object);
            serviceMock = new Mock<EmergencyReportService>(applicationDbContextMock.Object, dataProviderMock.Object);
            controller = new EmergencyReportController(serviceMock.Object, configOptionsMock.Object);
        }

        [Fact]
        public void Index_ReturnsEmptyView_WhenThereIsNoModel()
        {
            // arrange
            serviceMock.Setup(x => x.GetAllReportsAsync()).ReturnsAsync(() => new List<EmergencyReport>());

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "ListEmergencyReportView");
        }

        [Fact]
        public void Index_ReturnsViewWithModel_WhenThereIsModel()
        {
            // arrange
            var model = new EmergencyReport
            {
                Id = "1",
                Data = "Report",
                ReportTime = DateTime.Now
            };

            serviceMock.Setup(x => x.GetAllReportsAsync()).ReturnsAsync(() => new List<EmergencyReport> { model });

            // act
            var result = controller.Index().GetAwaiter().GetResult();

            // assert
            var viewResult = result as ViewResult;
            Assert.True(viewResult != null);
            Assert.True(viewResult.ViewName == "ListEmergencyReportView");

            var viewModel = viewResult.Model as List<EmergencyReport>;
            Assert.True(viewModel != null);
            Assert.Single(viewModel);
            Assert.Equal(model, viewModel[0]);
        }
    }
}
