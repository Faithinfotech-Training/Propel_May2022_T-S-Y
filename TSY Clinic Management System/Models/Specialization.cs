using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int SpecializationId { get; set; }
        public int DepartmentId { get; set; }
        public string SpecializationName { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
    }
}
