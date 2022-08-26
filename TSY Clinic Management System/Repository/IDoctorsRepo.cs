using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IDoctorsRepo
    {
        public Task<ActionResult<IEnumerable<GetAppointedPatientsViewmodel>>> GetAppointedPatients(int staffid);


        #region Diagnose Controller
        
        //get all diagnose
        public Task<ActionResult<IEnumerable<Prescription>>> GetpatientPrescription();
       
        
        //post of diagnose
        public Task<ActionResult<Prescription>> PostdiaPrescription(Prescription prescription);

        #endregion

        #region Medicine prescribed

        public Task<ActionResult<IEnumerable<Medicineprescription>>> GettheMedicineprescription();
        public Task<ActionResult<Medicineprescription>> PosttheMedicineprescription(Medicineprescription medicineprescription);

        #endregion

        #region lab test view

        public Task<ActionResult<IEnumerable<DoctorsLabReportViewModel>>> GetLabViewModel();

        #endregion
    }
}
