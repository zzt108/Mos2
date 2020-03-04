using Api.NancyFX;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy;
using Nancy.Testing;

namespace IntegrationTest.API
{
    [TestClass]
    public class NancyFxTests
    {
        [TestMethod]
        public void CanAccessNancy()
        {
            // Given
            var browser = new Browser(with => with.Module<MainModule>());

            // When
            var result = browser.Get("/", with => { with.HttpRequest(); });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
        }
    }
}
