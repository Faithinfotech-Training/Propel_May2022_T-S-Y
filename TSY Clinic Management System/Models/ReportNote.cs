using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class ReportNote
    {
        public int NoteId { get; set; }
        public int? PrescriptionId { get; set; }
        public DateTime? AppliedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string NoteDescription { get; set; }
        public string Remarks { get; set; }

        public virtual Prescription Prescription { get; set; }
    }
}
