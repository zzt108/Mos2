using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Candidate
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public bool IsSelected { get; set; }
        [ForeignKey("Recruiter_Id")]
        public Recruiter Recruiter { get; set; }
        public IList<Experience> Experiences { get; set; }
    }
}