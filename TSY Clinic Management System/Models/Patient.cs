using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Medicineprescription = new HashSet<Medicineprescription>();
        }

        public int PatientId { get; set; }
        public int? StaffId { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public int? BloodGroupId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public int? GenderId { get; set; }
        public string Mobile { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Medicineprescription> Medicineprescription { get; set; }
    }
}
