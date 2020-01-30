using System.Data.Entity;
using Model;

namespace DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=ModelContext")
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<Recruiter> Recruiters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}