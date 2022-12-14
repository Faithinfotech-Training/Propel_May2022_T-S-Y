using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Patient = new HashSet<Patient>();
            Staff = new HashSet<Staff>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
