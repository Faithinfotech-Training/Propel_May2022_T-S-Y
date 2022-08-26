namespace TSY_Clinic_Management_System.View_Model
{
    public class DoctorsLabReportViewModel
    {
        public string PatientName { get; set; }
        public string TestName { get; set; }
        public decimal? HighRange { get; set; }
        public decimal? LowRange { get; set; }

        //public DateTime? ModifiedDate { get; set; }
        public decimal? NormalRange { get; set; }
    }
}
