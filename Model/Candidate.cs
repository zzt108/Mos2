using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Candidate
    {

        public Candidate()
        {
            Experiences = new List<Experience>();
            SeenBy = new List<Recruiter>();
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
        public virtual IList<Recruiter> SeenBy { get; set; }
    }

    public class CandidateDto
    {

        public CandidateDto(Candidate c)
        {
            if (c == null)
            {
                return;
            }

            Experiences = new List<ExperienceDto>();
            Name = new Name();

            Id = c.Id;
            Name.First = c.Name.First;
            Name.Last = c.Name.Last;
            ExternalId = c.ExternalId;
            IsSelected = c.IsSelected;

            foreach (var experience in c.Experiences)
            {
                experience.Candidate = null;
                Experiences.Add(new ExperienceDto(experience));
            }
        }
        public int Id { get; set; }
        public Name Name { get; set; }
        public string ExternalId { get; set; }
        public bool IsSelected { get; set; }

        public IList<ExperienceDto> Experiences { get; set; }
    }
}