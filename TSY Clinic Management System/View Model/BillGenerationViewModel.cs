using System;

namespace TSY_Clinic_Management_System.View_Model
{
    public class BillGenerationViewModel
    {

        public DateTime? CreatedDate { get; set; }    //Medicineprescription
        public string PatientName { get; set; }   //patient
        public string StaffName { get; set; }    //staff
        public int? DoctorId { get; set; }     //Doctor
        public string MedicineName { get; set; }   //Medicine
        //public string RoleName { get; set; }  //
        public int? Quantity { get; set; }   //Medicine
        public string Unit { get; set; }  //Medicine
        public int? UnitPrice { get; set; }     //Medicine
        public int? MedicineTimingId { get; set; }  //MedicineTiming
        public string Course { get; set; }    //Prescription 
        public decimal BillAmount { get; set; }   //Bill Table
    }
}
