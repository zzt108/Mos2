using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Candidate
    {

        public Candidate()
        {
            Experiences = new List<Experience>();
            SeenBy = new List<Seen>();
        }
        public Candidate(JToken candidate)
        {
            Name = new Name()
            {
                First = candidate["name"]["first"].ToString(),
                Last = candidate["name"]["last"].ToString()
            };
            ExternalId = candidate["_id"].ToString();

        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Id { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Name Name { get; set; }
        public string ExternalId { get; set; }
        public bool IsSelected { get; set; }

        public virtual IList<Experience> Experiences { get; set; }
        public virtual IList<Seen> SeenBy { get; set; }
    }
}