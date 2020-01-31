using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Candidate
    {
        private IList<Experience> _experiences;

        public Candidate()
        {
            
        }

        public Candidate(JToken cand)
        {
            Name = new Name()
            {
                First = cand["name"]["first"].ToString(),
                Last = cand["name"]["last"].ToString()
            };

        }

        public int Id { get; set; }
        public Name Name { get; set; }
        public bool IsSelected { get; set; }

        public int? RecruiterId { get; set; }
        [ForeignKey("RecruiterId")]
        public Recruiter Recruiter { get; set; }

        public IList<Experience> Experiences
        {
            get => _experiences ?? new List<Experience>();
            set => _experiences = value;
        }
    }
}