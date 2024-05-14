using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Resources.DTOs
{
    public enum eKindDTO { man=1, woman=2 }
    public enum eHMO_DTO { Macabi = 1, Klalit = 2, Meuchedet = 3, leumit = 4 }
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        public eKindDTO Kind { get; set; }
        public eHMO_DTO HMO { get; set; }
    }
}
