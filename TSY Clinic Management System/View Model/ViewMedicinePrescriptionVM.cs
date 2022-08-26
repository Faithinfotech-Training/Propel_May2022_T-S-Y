using System;

namespace TSY_Clinic_Management_System.View_Model
{
    public class ViewMedicinePrescriptionVM
    {
        public int PatientId { get; set; }   //patient
        public string PatientName { get; set; }   //patient
        public string GenderName { get; set; }   //gender 
        public string DoctorName { get; set; }  //staff
        public string Diagnosis { get; set; }  //prescription
        public int MedicineprescriptionId { get; set; }    //MedicinePrescription
        public string MedicineName { get; set; }   //Medicine
        public int? Quantity { get; set; }    //medicine
        public string MedicineTiming1 { get; set; }    //MedicineTiming
        public string Course { get; set; }     //MedicinePrescription
        public DateTime? CreatedDate { get; set; }   //MedicinePrescription
        



    }
}
