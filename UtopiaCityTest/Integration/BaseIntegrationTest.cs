using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;

namespace UtopiaCityTest.Integration
{
    public abstract class BaseIntegrationTest : IDisposable
    {
        protected TestServer _testServer;

        public BaseIntegrationTest()
        {
            RegisterServices();
            RegisterMiddleware();

            _testServer = CreateTestServer();
        }

        protected virtual void RegisterServices()
        {
        }

        protected virtual void RegisterMiddleware()
        {
        }

        protected TestServer CreateTestServer()
        {
            var webBuilder = new WebHostBuilder();
            webBuilder.UseStartup<TestStartup>();
            return new TestServer(webBuilder);
        }

        public virtual void Dispose()
        {
        }
    }
}
