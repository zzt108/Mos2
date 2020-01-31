namespace Model
{
    public class Seen
    {
        public int Id { get; set; }
        public virtual Recruiter Recruiter { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}