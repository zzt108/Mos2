using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Recruiter
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        [ForeignKey("Id")]
        public Candidate Candidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public IList<Seen> CandidatesSeen { get; set; }
    }
}