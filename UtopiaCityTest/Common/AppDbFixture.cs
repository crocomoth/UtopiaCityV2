using Microsoft.EntityFrameworkCore;
using System;
using UtopiaCity.Data;

namespace UtopiaCityTest.Common
{
    public class AppDbFixture : IDisposable
    {
        public AppDbContext AppDbContext { get; private set; }

        public AppDbFixture()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: RandomUtil.GenerateRandomString(15) + "UtopiaCityTest").Options;

            AppDbContext = new AppDbContext(options);
        }

        public void Dispose()
        {
            AppDbContext.Dispose();
        }
    }
}
