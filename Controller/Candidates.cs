using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;
using Newtonsoft.Json.Linq;

namespace Controller
{

    public static class Candidates
    {

        public static IEnumerable<Candidate> GetCandidates(string technology, int years)
        {
            var m = Technologies.GetByName(technology);
            if (m == null)
            {
                throw new ArgumentException($"Technology {technology} not found!");
            }
            return GetCandidates(m.Id, years);
        }

        public static IEnumerable<Candidate> GetCandidates(int technologyId, int years)
        {
            using (var uw = new UnitOfWork())
            {
                var candidates = uw.CandidateRepository.Get(c => c.Experiences.Any(exp => exp.Technology.Id == technologyId && exp.Years >= years));
                if (candidates == null)
                {
                    throw new ArgumentException($"Candidate data not found!");
                }
                return candidates;
            }
        }

        public static void AddTechnologies(UnitOfWork uw, Candidate candidate, JToken jTokenCandidate)
        {
            var content = jTokenCandidate["technologies"];
            var techArray = content.Children();
            foreach (var tech in techArray)
            {
                var techName = tech["name"].ToString();
                var t = uw.TechnologyRepository.Get(technology => technology.Name == techName).FirstOrDefault();
                if (t != null)
                {
                    var experience = new Experience()
                    {
                        Technology = t, 
                        Candidate = candidate,
                        Years = tech["experianceYears"].Value<int>() // property is misspelled in source JSon
                    };
                    uw.ExperienceRepository.Add(experience);
                }
            }
        }

    }
}