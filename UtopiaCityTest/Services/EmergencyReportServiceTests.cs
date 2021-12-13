using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Moq;
using System;
using UtopiaCity.Common;
using UtopiaCity.Data;
using UtopiaCity.Data.Providers;
using UtopiaCity.Models.Emergency;
using UtopiaCity.Services.Emergency;
using UtopiaCityTest.Common;
using Xunit;

namespace UtopiaCityTest.Services
{
    public class EmergencyReportServiceTests : BaseServiceTest
    {
        public EmergencyReportServiceTests(AppDbFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async void GetEmergencyReports_ReturnsItems_IfTheyExistInDb()
        {
            // arrange
            var report1 = new EmergencyReport
            {
                Data = "Report 1",
                ReportTime = DateTime.Now
            };

            var report2 = new EmergencyReport
            {
                Data = "Report 2",
                ReportTime = DateTime.Now
            };

            var report3 = new EmergencyReport
            {
                Data = "Report 3",
                ReportTime = DateTime.Now
            };

            AppDbContext.EmergencyReport.AddRange(report1, report2, report3);
            AppDbContext.SaveChanges();

            var configOptionsMock = new Mock<IOptions<AppConfig>>();
            var memoryCacheMock = new Mock<IMemoryCache>();
            var dataProviderMock = new Mock<GenericDataProvider<EmergencyReport>>(AppDbContext, memoryCacheMock.Object, configOptionsMock.Object);

            var service = new EmergencyReportService(AppDbContext, dataProviderMock.Object);

            // act
            var result = await service.GetAllReportsAsync();

            // assert
            Assert.Equal(3, result.Count);
            Assert.Collection(result,
                item => item.Data.Equals("Report 1"),
                item => item.Data.Equals("Report 2"),
                item => item.Data.Equals("Report 3"));
        }
    }
}
