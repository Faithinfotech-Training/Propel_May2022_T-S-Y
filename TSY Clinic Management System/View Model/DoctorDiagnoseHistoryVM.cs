using System;

namespace CMSByTeamJava.ViewModel
{
    public class DoctorDiagnoseHistoryVM
    {
        public string PatientName { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string Diagnosis { get; set; }
    }
}
