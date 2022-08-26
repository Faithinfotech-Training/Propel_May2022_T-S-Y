using System;

namespace TSY_Clinic_Management_System.View_Model
{
    public class GetAppointedPatientsViewmodel
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public bool? Status { get; set; }
        public int? TokenNo { get; set; }
    }
}
