using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repositories.Entities
{
    public enum eKind { man=1,woman=2}
    public enum eHMO { Macabi=1,Klalit=2,Meuchedet=3,leumit=4}

    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        public eKind Kind { get; set; }
        public eHMO HMO { get; set; }

        public User(int id, string firstName, string lastName, string tZ,
            DateTime dateOfBirth, eKind kind, eHMO hMO)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TZ = tZ;
            DateOfBirth = dateOfBirth;
            Kind = kind;
            HMO = hMO;
        }
    }
}
