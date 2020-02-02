using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Recruiter
    {
        public Recruiter()
        {
            CandidatesSeen  = new List<Candidate>();  
        }


        [Key]
        public int RecruiterId { get; set; }
        public Name Name { get; set; }
        public int? PromotedFromCandidate_Id { get; set; }
        [ForeignKey(nameof(PromotedFromCandidate_Id))]
        public virtual Candidate PromotedFromCandidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public virtual IList<Candidate> CandidatesSeen { get; set; }
    }

    public class RecruiterDto
    {
        public RecruiterDto(Recruiter r)
        {
            CandidatesSeen = new List<CandidateDto>();
            RecruiterId = r.RecruiterId;
            Name = r.Name;
            PromotedFromCandidate = new CandidateDto(r.PromotedFromCandidate);
            PasswordSaltedHash = r.PasswordSaltedHash;
            Email = r.Email;
            foreach (var candidate in r.CandidatesSeen)
            {
                CandidatesSeen.Add(new CandidateDto(candidate));
            }
        }
        public int RecruiterId { get; set; }
        public Name Name { get; set; }
        public CandidateDto PromotedFromCandidate { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        public IList<CandidateDto> CandidatesSeen { get; set; }
    }
}