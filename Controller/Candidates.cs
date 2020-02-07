using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Controller
{
    public static class Candidates
    {
        public static IEnumerable<Candidate> GetAcceptedCandidates(UnitOfWork uw)
        {
            return uw.CandidateRepository.Get(candidate => candidate.IsSelected);
        }


        public static IEnumerable<Candidate> GetCandidates(UnitOfWork uw, string technology, int years)
        {
            var m = Technologies.GetByName(technology);
            if (m == null)
            {
                throw new ArgumentException($"Technology {technology} not found!");
            }
            return GetCandidates(uw, m.Id, years);
        }

        public static IEnumerable<Candidate> GetCandidates(UnitOfWork uw, int technologyId, int years)
        {
            var candidates = uw.CandidateRepository.Get(c => c.Experiences.Any(exp => exp.Technology.Id == technologyId && exp.Years >= years));
            if (candidates == null)
            {
                throw new ArgumentException($"Candidate data not found!");
            }
            return candidates;
        }


        public static void Accept(UnitOfWork uw, int recruiterId, int candidateId, bool accept)
        {
            var candidate = uw.CandidateRepository.GetById(candidateId);
            var recruiter = uw.RecruiterRepository.GetById(recruiterId);
            candidate.IsSelected = accept;
            uw.SeenRepository.Add(new Seen()
            {
                Candidate = candidate,
                Recruiter = recruiter
            });
            uw.SaveChanges();
        }

        public static Recruiter Promote(UnitOfWork uw, int candidateId, string email, string password)
        {
            var candidate = uw.CandidateRepository.GetById(candidateId);
            var recruiter = new Recruiter()
            {
                Name = candidate.Name,
                Email = email,
                PasswordSaltedHash = password,
                PromotedFromCandidate = candidate

            };
            uw.RecruiterRepository.Add(recruiter);
            uw.SaveChanges();
            return recruiter;
        }
    }
}