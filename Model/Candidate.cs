using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Candidate
    {
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
        [Required]
        public Recruiter Recruiter { get; set; }

        public IList<Experience> Experiences
        {
            get => _experiences ?? new List<Experience>();
            set => _experiences = value;
        }
    }
}