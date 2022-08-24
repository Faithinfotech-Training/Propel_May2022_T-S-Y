using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Prescription = new HashSet<Prescription>();
        }

        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int DepartmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public bool? Status { get; set; }
        public int? TokenNo { get; set; }

        public virtual Department Department { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
