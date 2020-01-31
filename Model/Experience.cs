namespace Model
{
    public class Experience
    {
        public int Id { get; set; }
        public Candidate Candidate { get; set; }
        public Technology Technology { get; set; }
        public int Years { get; set; }
    }
}