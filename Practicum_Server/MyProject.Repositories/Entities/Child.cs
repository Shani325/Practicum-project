using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public class Child
    {

        [Key,Required ]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Parent1")]
        public int? IdParent1 { get; set; }
        public User Parent1 { get; set; }
        [ForeignKey("Parent2")]
        public int? IdParent2 { get; set; }
        public User Parent2 { get; set; }

        public Child()
        {

        }

        public Child(int id, string name, string tZ, DateTime dateOfBirth,
            int? idParent1, int? idParent2)
        {
            Id = id;
            Name = name;
            TZ = tZ;
            DateOfBirth = dateOfBirth;
            IdParent1 = idParent1;
            IdParent2 = idParent2;
        }
    }
}
