using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
using Model;

namespace Controller
{
    public static class Recruiters
    {
        public static Recruiter GetByEmail(string email)
        {

            using (var uw = new UnitOfWork())
            {
                return uw.RecruiterRepository.Get(r =>
                        r.Email.ToLower() == email.ToLower())
                    .FirstOrDefault();
            }
        }

        public static void Add(Recruiter recruiter)
        {
            using (var uw = new UnitOfWork())
            {
                if (null == GetByEmail(recruiter.Email))
                {
                    uw.RecruiterRepository.Add(recruiter);
                    uw.SaveChanges();
                }
            }
        }

        public static IList<Recruiter> GetAll()
        {
            using (var uw = new UnitOfWork())
            {
                return uw.RecruiterRepository.Get(r => true).ToList();
            }

        }

    }
}