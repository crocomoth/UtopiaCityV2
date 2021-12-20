using Microsoft.AspNetCore.Builder;
using System.Linq;
using UtopiaCity.Common.Middleware;
using Xunit;

namespace UtopiaCityTest.Integration.Middleware
{
    public class RequestCultureMiddlewareTest : BaseIntegrationTest
    {
        public RequestCultureMiddlewareTest() : base()
        {
        }

        protected override void RegisterMiddleware()
        {
            base.RegisterMiddleware();

            TestStartup.RegisterMiddleware = (IApplicationBuilder app) =>
            {
                app.UseMiddleware<RequestCultureMiddleware>();
            };
        }

        [Fact]
        public async void CultureIsNotReturned_WhenItIsNotSetInQuery()
        {
            // act
            var response = await _testServer.CreateClient().GetAsync("Dummy/Index");

            // assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);
            Assert.False(response.Headers.TryGetValues("culture", out _));
        }

        [Fact]
        public async void CultureIsReturned_WhenItIsSetInQuery()
        {
            // arrange
            var culture = "en-us";

            // act
            var response = await _testServer.CreateClient().GetAsync($"Dummy/Index?culture={culture}");

            // assert
            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);
            Assert.True(response.Headers.TryGetValues("culture", out var responseCulture));
            Assert.Equal(culture, responseCulture.First(), ignoreCase: true);
        }

        public override void Dispose()
        {
            base.Dispose();

            TestStartup.RegisterMiddleware = null;
        }
    }
}
