using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Nancy;
using Nancy.Testing;
using WinService.NancyFX;

namespace IntegrationTest
{
    [TestClass]
    public class NancyFxTests
    {
        private const string InaccessibleFile = @"c:\taxdata.csv";

        [TestMethod]
        public void CanAccessNancy()
        {
            // Given
            var browser = new Browser(with => with.Module<MainModule>());

            // When
            var result = browser.Get("/", with =>
            {
                with.HttpRequest();
            });

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.Result.StatusCode);
        }

    }
}
