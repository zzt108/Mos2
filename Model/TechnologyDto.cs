namespace Model
{
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