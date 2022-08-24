using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class MedicineView
    {
        public int MedicineViewId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? MedicineAmount { get; set; }
        public string MedicineName { get; set; }
        public int? MedicineprescriptionId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }

        public virtual Medicineprescription Medicineprescription { get; set; }
    }
}
