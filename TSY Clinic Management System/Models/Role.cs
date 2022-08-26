using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Role
    {
        public Role()
        {
            Staff = new HashSet<Staff>();
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
