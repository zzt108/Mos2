using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Candidate
    {
        
        public Candidate()
        {
            Experiences = new List<Experience>();
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

        public virtual IList<Experience> Experiences { get; set; }
    }
}