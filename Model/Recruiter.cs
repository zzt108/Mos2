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
        public int? Candidate_Id { get; set; }
        [ForeignKey("Candidate_Id")]
        public Candidate Candidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public virtual IList<Seen> CandidatesSeen { get; set; }
    }
}