using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyProject.WebAPI.Models
{
    public class ChildModel
    {
        public string Name { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("User")]
        public int? IdParent1 { get; set; }
        [ForeignKey("User")]
        public int? IdParent2 { get; set; }
    }
}
