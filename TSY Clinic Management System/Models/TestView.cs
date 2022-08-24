using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class TestView
    {
        public int TestViewId { get; set; }
        public DateTime? AppliedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? HighRange { get; set; }
        public decimal? LowRange { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? NormalRange { get; set; }
        public bool? Status { get; set; }
        public int? TestAmount { get; set; }
        public int? TestprescriptionId { get; set; }
        public string Unit { get; set; }

        public virtual Testprescription Testprescription { get; set; }
    }
}
