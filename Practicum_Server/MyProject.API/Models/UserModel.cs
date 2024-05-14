using MyProject.Resources.DTOs;
using System;

namespace MyProject.WebAPI.Models
{   
    public class UserModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TZ { get; set; }
        public DateTime DateOfBirth { get; set; }
        public eKindDTO Kind { get; set; }
        public eHMO_DTO HMO { get; set; }
    }
}
