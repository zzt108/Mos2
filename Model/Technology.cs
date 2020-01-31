using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace Model
{
    public class Technology
    {
        public Technology()
        {
            
        }

        public Technology(JToken tech)
        {
            Name = tech["name"].ToString();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}