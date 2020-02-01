using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

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


    }
}