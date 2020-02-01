using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Technology
    {
        public Technology()
        {
            Experiences = new List<Experience>();
        }

        public Technology(JToken tech)
        {
            Name = tech["name"].ToString();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual IList<Experience> Experiences{ get; set; }
    }

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