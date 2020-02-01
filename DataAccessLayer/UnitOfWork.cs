using System;
using System.Data.Entity.Validation;
using Model;

namespace DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        public readonly DataContext Context = new DataContext();
        private GenericRepository<Candidate> _candidateRepository;
        private GenericRepository<Experience> _experienceRepository;
        private GenericRepository<Technology> _technologyRepository;
        private GenericRepository<Recruiter> _recruiterRepository;

        private bool _disposed;

        public GenericRepository<Candidate> CandidateRepository => _candidateRepository ?? (_candidateRepository = new GenericRepository<Candidate>(Context));
        public GenericRepository<Experience> ExperienceRepository => _experienceRepository ?? (_experienceRepository = new GenericRepository<Experience>(Context));
        public GenericRepository<Technology> TechnologyRepository => _technologyRepository ?? (_technologyRepository = new GenericRepository<Technology>(Context));
        public GenericRepository<Recruiter> RecruiterRepository => _recruiterRepository ?? (_recruiterRepository = new GenericRepository<Recruiter>(Context));

        public bool LazyLoadingEnabled
        {
            get => Context.Configuration.LazyLoadingEnabled;
            set => Context.Configuration.LazyLoadingEnabled = value;
        }

        public void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                // Log validation errors to console
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}