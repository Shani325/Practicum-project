using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Resources.DTOs
{
    public class ChildDTO
    {
        [Key,Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Parent1")]
        public int? IdParent1 { get; set; }
        public UserDTO Parent1 { get; set; }
        [ForeignKey("Parent2")]
        public int? IdParent2 { get; set; }
        public UserDTO Parent2 { get; set; }
    }
}
