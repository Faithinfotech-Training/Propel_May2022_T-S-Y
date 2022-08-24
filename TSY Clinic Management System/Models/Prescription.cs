using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Prescription
    {
        public Prescription()
        {
            Medicineprescription = new HashSet<Medicineprescription>();
            ReportNote = new HashSet<ReportNote>();
            Testprescription = new HashSet<Testprescription>();
        }

        public int PrescriptionId { get; set; }
        public int? AppointmentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual ICollection<Medicineprescription> Medicineprescription { get; set; }
        public virtual ICollection<ReportNote> ReportNote { get; set; }
        public virtual ICollection<Testprescription> Testprescription { get; set; }
    }
}
