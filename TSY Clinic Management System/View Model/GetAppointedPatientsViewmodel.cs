using System;

namespace TSY_Clinic_Management_System.View_Model
{
    public class GetAppointedPatientsViewmodel
    {
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public int? TokenNo { get; set; }
        public string PatientName { get; set; }
        public string Mobile { get; set; }
    }
}
