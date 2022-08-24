using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Medicine
    {
        public Medicine()
        {
            Medicineprescription = new HashSet<Medicineprescription>();
        }

        public int MedicineId { get; set; }
        public string CompanyName { get; set; }
        public string GenericName { get; set; }
        public string MedicineName { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public int? UnitPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Medicineprescription> Medicineprescription { get; set; }
    }
}
