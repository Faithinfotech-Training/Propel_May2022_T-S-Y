using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Testprescription
    {
        public Testprescription()
        {
            TestView = new HashSet<TestView>();
        }

        public int TestprescriptionId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? PrescriptionId { get; set; }
        public int? TestId { get; set; }

        public virtual Prescription Prescription { get; set; }
        public virtual Labtest Test { get; set; }
        public virtual ICollection<TestView> TestView { get; set; }
    }
}
