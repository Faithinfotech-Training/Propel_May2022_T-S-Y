using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Labtest
    {
        public Labtest()
        {
            Testprescription = new HashSet<Testprescription>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int? UnitPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Testprescription> Testprescription { get; set; }
    }
}
