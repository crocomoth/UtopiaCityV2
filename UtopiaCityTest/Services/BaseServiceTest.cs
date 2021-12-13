using System;
using UtopiaCity.Data;
using UtopiaCityTest.Common;
using Xunit;

namespace UtopiaCityTest.Services
{
    public abstract class BaseServiceTest : IClassFixture<AppDbFixture>, IDisposable
    {
        protected AppDbFixture appDbFixture;

        protected AppDbContext AppDbContext => appDbFixture.AppDbContext;

        public BaseServiceTest(AppDbFixture fixture)
        {
            appDbFixture = fixture;

            Setup();
        }

        protected virtual void Setup()
        {
        }

        protected virtual void CleanUp()
        {
        }

        public void Dispose()
        {
            CleanUp();

            appDbFixture.Dispose();
        }
    }
}
