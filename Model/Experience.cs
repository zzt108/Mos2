namespace Model
{
    public class Experience
    {
        public int Id { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Technology Technology { get; set; }
        public int Years { get; set; }
    }
}