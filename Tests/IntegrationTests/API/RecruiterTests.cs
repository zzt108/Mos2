﻿using Api.NancyFX;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Nancy;
using Nancy.Testing;

namespace IntegrationTest.API
{
    [TestClass]
    public class RecruiterTests
    {
        [TestMethod]
        public void CanLoginRecruiter()
        {
            // Given
            var browser = new Browser(with => { with.Module<RecruiterModule>(); });

            // When
            var result = browser.Get("/recruiter/login/zzt@outlook.hu/empty", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Body.DeserializeJson<Name>().First.Should().Be("Zsolt");
            response.Body.DeserializeJson<Name>().Last.Should().Be("Toth");

        }

    }
}
