using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointment = new HashSet<Appointment>();
            Medicineprescription = new HashSet<Medicineprescription>();
        }

        public int DoctorId { get; set; }
        public int? ConsultationFees { get; set; }
        public int? DepartmentId { get; set; }
        public int SpecializationId { get; set; }
        public int StaffId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Specialization Specialization { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Medicineprescription> Medicineprescription { get; set; }
    }
}
