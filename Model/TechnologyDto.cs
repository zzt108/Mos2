using System.Diagnostics.CodeAnalysis;

namespace Model
{
    /// <summary>
    /// Class used in reflection, properties must be public
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "CollectionNeverQueried.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public class TechnologyDto
    {

        public TechnologyDto(Technology t)
        {
            Id = t.Id;
            Name = t.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

    }
}