using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class BillTable
    {
        public int BillNumber { get; set; }
        public int? BillingId { get; set; }
        public int? PatientId { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
