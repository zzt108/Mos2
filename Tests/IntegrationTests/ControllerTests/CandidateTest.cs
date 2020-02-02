﻿using System;
using System.Linq;
using Controller;
using DataAccessLayer;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace IntegrationTest.ControllerTests
{
    [TestClass]
    public class CandidateTest
    {
        [TestMethod]
        public void CanAcceptCandidate()
        {
            using (var uw = new UnitOfWork())
            {
                //Given
                var candidateId = 1;
                var recruiterId = 1;
                var accept = true;
                var cand = uw.CandidateRepository.GetById(candidateId);
                var seen = cand.SeenBy.Count;

                //When
                Candidates.Accept(uw, recruiterId, candidateId ,accept);
                uw.SaveChanges();

                //Then
                cand = uw.CandidateRepository.GetById(candidateId);
                var recr = uw.RecruiterRepository.GetById(recruiterId);

                cand.IsSelected.Should().Be(accept);
                cand.SeenBy.Count.Should().Be(seen +1);
                recr.CandidatesSeen.Count.Should().Be(seen +1);
                //cand.SeenBy.Should().Contain(recr);
                //recr.CandidatesSeen.Should().Contain(cand);

                //Clean up
                cand.SeenBy.Remove(recr);
                uw.SaveChanges();

                var recr2 = uw.RecruiterRepository.GetById(recruiterId);
                recr2.CandidatesSeen.Count.Should().Be(seen);
                recr.CandidatesSeen.Count.Should().Be(seen);
                //recr2.CandidatesSeen.Should().NotContain(cand);

            }
        }

        [TestMethod]
        public void CanGetCandidatesByTechId()
        {
            using (var uw = new UnitOfWork())
            {
                //Given
                var tech = uw.TechnologyRepository.GetById(1);
                var years = 1;

                //When
                var candidates = Candidates.GetCandidates(uw, tech.Id, years);

                //Then
                foreach (var candidate in candidates)
                {
                    candidate.Experiences.Should()
                        .Contain(exp => exp.Technology.Id == 1 && exp.Years >= years);
                }
            }
        }

        [TestMethod]
        public void CanGetCandidatesByTechName()
        {
            using (var uw = new UnitOfWork())
            {
                // Given
                var techName = "Kanban Tool";
                var years = 1;

                //When
                var candidates = Candidates.GetCandidates(uw, techName, years);

                //Then
                foreach (var candidate in candidates)
                {
                    candidate.Experiences.Should()
                        .Contain(exp => exp.Technology.Name == techName && exp.Years >= years);
                }
            }
        }

        [TestMethod]
        public void CanAddExperience()
        {
            using (var uw = new UnitOfWork())
            {
                Experience experience = null;
                try
                {
                    //Given
                    var tech = uw.TechnologyRepository.GetById(1);
                    var candidate = uw.CandidateRepository.GetById(1);
                    foreach (var candidateExperience in candidate.Experiences)
                    {
                        Console.WriteLine($"'{candidateExperience.Technology.Name}'");
                    }
                    var experienceCount1 = candidate.Experiences.Count;

                    //When
                    experience = new Experience()
                    {
                        Candidate = candidate,
                        Technology = tech,
                        Years = 13
                    };
                    uw.ExperienceRepository.Add(experience);
                    uw.SaveChanges();

                    //Then
                    var candidate2 = uw.CandidateRepository.Get(c => c.Id == 1).First();
                    experienceCount1.Should().Be(candidate2.Experiences.Count - 1);
                }
                finally
                {
                    if (null != experience)
                    {
                        uw.ExperienceRepository.Delete(experience);
                        uw.SaveChanges();

                    }
                }

            }
        }

    }

}
