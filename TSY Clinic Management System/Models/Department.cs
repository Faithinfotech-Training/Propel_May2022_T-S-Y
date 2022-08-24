using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Department
    {
        public Department()
        {
            Appointment = new HashSet<Appointment>();
            Doctor = new HashSet<Doctor>();
            Specialization = new HashSet<Specialization>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Specialization> Specialization { get; set; }
    }
}
