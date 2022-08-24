using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class MedicineTiming
    {
        public MedicineTiming()
        {
            Medicineprescription = new HashSet<Medicineprescription>();
        }

        public int MedicineTimingId { get; set; }
        public string MedicineTiming1 { get; set; }

        public virtual ICollection<Medicineprescription> Medicineprescription { get; set; }
    }
}
