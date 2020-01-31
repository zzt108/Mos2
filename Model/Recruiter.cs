using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Recruiter
    {
        [Key]
        public int RecruiterId { get; set; }
        public Name Name { get; set; }
        [Required]
        public Candidate Candidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public IList<Seen> CandidatesSeen { get; set; }
    }
}