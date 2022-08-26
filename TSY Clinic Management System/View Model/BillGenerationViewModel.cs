using System;

namespace TSY_Clinic_Management_System.View_Model
{
    public class BillGenerationViewModel
    {

        public DateTime? CreatedDate { get; set; }
        public string PatientName { get; set; }
        public string StaffName { get; set; }
        public int? DoctorId { get; set; }
        public string MedicineName { get; set; }

        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public int? UnitPrice { get; set; }

        public int? MedicineTimingId { get; set; }
        public string Course { get; set; }
        public decimal BillAmount { get; set; }
    }
}
