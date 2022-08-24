using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Medicineprescription
    {
        public Medicineprescription()
        {
            MedicineView = new HashSet<MedicineView>();
        }

        public int MedicineprescriptionId { get; set; }
        public int? MedicineId { get; set; }
        public int? PrescriptionId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? MedicineTimingId { get; set; }
        public string Course { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual MedicineTiming MedicineTiming { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual ICollection<MedicineView> MedicineView { get; set; }
    }
}
