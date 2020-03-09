using System.Diagnostics.CodeAnalysis;

namespace Model
{
    /// <summary>
    /// Class used in reflection, properties must be public
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class ExperienceDto
    {
        public ExperienceDto(Experience e)
        {
            Id = e.Id;
            Years = e.Years;
            Candidate = new CandidateDto(e.Candidate);
            Technology = new TechnologyDto(e.Technology);
        }

        public int Id { get; set; }
        public CandidateDto Candidate { get; set; }
        public TechnologyDto Technology { get; set; }
        public int Years { get; set; }
    }
}