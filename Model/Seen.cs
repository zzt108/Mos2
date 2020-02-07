namespace Model
{
    public class Seen
    {
        public int Id { get; set; }
        public Recruiter Recruiter { get; set; }
        public Candidate Candidate { get; set; }
    }
}