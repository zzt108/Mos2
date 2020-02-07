using System.Collections.Generic;

namespace Model
{
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