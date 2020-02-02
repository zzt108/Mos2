using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Nancy;
using Nancy.Testing;
using WinService.NancyFX;

namespace IntegrationTest.API
{
    [TestClass]
    public class CandidateTests
    {
        [TestMethod]
        public void CanPromoteCandidate()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            var result = browser.Post("/candidate/promote/2/zzt@ifs.com/empty", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [TestMethod]
        public void CanAcceptCandidate()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            var result = browser.Put("/candidate/accept/1/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [TestMethod]
        public void CanRejectCandidate()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            var result = browser.Put("/candidate/reject/1/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);


        }

        [TestMethod]
        public void CanGetCandidatesWithExperience()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            var result = browser.Get("/candidate/bitwarden/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //var deserializeJson = response.Body.AsString();
            var deserializeJson = response.Body.DeserializeJson<IList<Candidate>>();
            deserializeJson.Count.Should().Be(7);


        }

        [TestMethod]
        public void CanGetCandidatesWithExperienceTwoWords()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            // Technology name should be Url Encoded
            var result = browser.Get("/candidate/Kanban%20Tool/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var deserializeJson = response.Body.DeserializeJson<IList<Candidate>>();
            deserializeJson.Count.Should().Be(3);


        }

        [TestMethod]
        public void CanNotLoginWithInvalidEmail()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<CandidateModule>();
            });

            // When
            var result = browser.Get("/candidate/xxxyyy/1", with =>
            {
                with.HttpRequest();
                with.Header("accept", "application/json");
            });
            var response = result.Result;
            // Then
            response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);

        }

    }
}