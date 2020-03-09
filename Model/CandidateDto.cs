using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace Model
{
    /// <summary>
    /// Class used in reflection, properties must be public
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class CandidateDto
    {

        public CandidateDto(Candidate c)
        {
            if (c == null)
            {
                return;
            }

            Experiences = new List<ExperienceDto>();
            Name = c.Name;

            Id = c.Id;
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