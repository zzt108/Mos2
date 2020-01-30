using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Experience
    {
        public int Id { get; set; }
        //[ForeignKey("Candidate_Id")]
        public Candidate Candidate { get; set; }
        //[ForeignKey("Profession_Id")]
        public Technology Technology { get; set; }
        public int Years { get; set; }
    }
}