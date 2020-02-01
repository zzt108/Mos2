using System;
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
        public void CanGetCandidatesByTech()
        {
            using (var uw = new UnitOfWork())
            {
                var tech = uw.TechnologyRepository.GetById(1);
                var years = 1;
                var candidates = Candidates.GetCandidates(uw, tech.Id, years);
                foreach (var candidate in candidates)
                {
                    candidate.Experiences.Should()
                        .Contain(exp => exp.Technology.Id == 1 && exp.Years >= years);
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
                    var tech = uw.TechnologyRepository.GetById(1);
                    var candidate = uw.CandidateRepository.GetById(1);
                    foreach (var candidateExperience in candidate.Experiences)
                    {
                        Console.WriteLine($"'{candidateExperience.Technology.Name}'");
                    }
                    var experienceCount1 = candidate.Experiences.Count;
                    experience = new Experience()
                    {
                        Candidate = candidate,
                        Technology = tech,
                        Years = 13
                    };
                    uw.ExperienceRepository.Add(experience);
                    uw.SaveChanges();
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
