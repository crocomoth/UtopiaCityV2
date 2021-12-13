using System;

namespace UtopiaCityTest.Controllers
{
    public abstract class BaseControllerTest : IDisposable
    {
        public BaseControllerTest()
        {
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
        }
    }
}
