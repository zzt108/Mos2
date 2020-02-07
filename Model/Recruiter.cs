using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Recruiter
    {
        public Recruiter()
        {
            CandidatesSeen  = new List<Seen>();  
        }


        [Key]
        public int RecruiterId { get; set; }
        public Name Name { get; set; }
        public int? PromotedFromCandidate_Id { get; set; }
        [ForeignKey(nameof(PromotedFromCandidate_Id))]
        public virtual Candidate PromotedFromCandidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public virtual IList<Seen> CandidatesSeen { get; set; }
    }
}