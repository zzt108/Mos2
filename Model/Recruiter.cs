using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Model
{

    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class Recruiter
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        public Recruiter()
        {
            CandidatesSeen  = new List<Seen>();  
        }


        [Key]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // Key must be set-able for EF Model generation
        public int RecruiterId { get; set; }
        public Name Name { get; set; }
        public string PasswordSaltedHash{ get; set; } // not implemented yet
        public string Email{ get; set; }
        // Naming determined by EF db generation conventions
        // ReSharper disable once InconsistentNaming
        public int? PromotedFromCandidate_Id { get; set; }
        //Must be virtual for Entity Framework Lazy Loading and change tracking
        [ForeignKey(nameof(PromotedFromCandidate_Id))]
        public virtual Candidate PromotedFromCandidate { get; set; }
        public virtual IList<Seen> CandidatesSeen { get; set; }
    }
}