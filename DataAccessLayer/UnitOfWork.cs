using System;
using Model;

namespace DataAccessLayer
{
    public sealed class UnitOfWork : IDisposable
    {
        private readonly DataContext _context = new DataContext();
        private GenericRepository<Candidate> _candidateRepository;
        private GenericRepository<Experience> _experienceRepository;
        private GenericRepository<Technology> _technologyRepository;
        private GenericRepository<Recruiter> _recruiterRepository;
        private GenericRepository<Seen> _seenRepository;

        private bool _disposed;

        public GenericRepository<Candidate> CandidateRepository => _candidateRepository ?? (_candidateRepository = new GenericRepository<Candidate>(_context));
        public GenericRepository<Experience> ExperienceRepository => _experienceRepository ?? (_experienceRepository = new GenericRepository<Experience>(_context));
        public GenericRepository<Technology> TechnologyRepository => _technologyRepository ?? (_technologyRepository = new GenericRepository<Technology>(_context));
        public GenericRepository<Recruiter> RecruiterRepository => _recruiterRepository ?? (_recruiterRepository = new GenericRepository<Recruiter>(_context));
        public GenericRepository<Seen> SeenRepository => _seenRepository ?? (_seenRepository = new GenericRepository<Seen>(_context));

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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