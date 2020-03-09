using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Model
{
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public class Technology
    {
        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
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
}