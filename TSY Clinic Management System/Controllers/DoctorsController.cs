using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.Repository;
using TSY_Clinic_Management_System.View_Model;

namespace TSY_Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsRepo _repository;

        #region Constructor Injection
        //Default Constructor
        public DoctorsController(IDoctorsRepo repository)
        {
            _repository = repository;
        }
        #endregion


        #region Get Appointment List for docotor

        // GET: api/Doctors/Dashboard/{staffid}
        [HttpGet("Dashboard/{staffid}")]
        public async Task<ActionResult<IEnumerable<GetAppointedPatientsViewmodel>>> GetAppointedPatients(int staffid)
        {

            return await _repository.GetAppointedPatients(staffid);
        }

        #endregion


        #region Doctor Diagnose notes

        // GET: api/Doctors/DiagnoseNotes
        [HttpGet("DiagnoseNotes")]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescription()
        {
            //return await _context.Prescription.ToListAsync();
            return await _repository.GetpatientPrescription();
        }



        // GET: api/Doctors/DiagnoseNotes
        [HttpPost("DiagnoseNotes")]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescription)
        {
            //Prescription obj = new Prescription();
            //    obj = _repository.Prescription.Add(prescription);
            //await _repository.SaveChangesAsync();

            //return CreatedAtAction("GetPrescription", new { id = prescription.PrescriptionId }, prescription);
            if (ModelState.IsValid)
            {

                var pres = await _repository.PostdiaPrescription(prescription);
                // return Ok(newEmployeeId);
                if (pres != null)
                {
                    return pres;
                }
                else
                {

                }
                return NotFound();
            }
            return BadRequest();

        }


        #endregion


        #region lab view

        [HttpGet("Labreport/{patientid}")]
        public async Task<ActionResult<IEnumerable<DoctorsLabReportViewModel>>> GetLabViewModel(int patitentId)
        {
            return await _repository.GetLabViewModel(patitentId);
        }

        #endregion


        #region Medicineprescriptions

        
        // GET: api/Medicineprescriptions
        [HttpGet("Medicineprescriptions")]
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetMedicineprescription()
        {
            return await _repository.GettheMedicineprescription();
        }

        
        // POST: api/Medicineprescriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AddMedicineprescriptions")]
        public async Task<ActionResult<Medicineprescription>> PostMedicineprescription(Medicineprescription medicineprescription)
        {
            if (ModelState.IsValid)
            {

                var pres = await _repository.PosttheMedicineprescription(medicineprescription);
                // return Ok(newEmployeeId);
                if (pres != null)
                {
                    return pres;
                }
                else
                {

                }
                return NotFound();
            }
            return BadRequest();
        }
        #endregion


        #region Lab test prescription

        // GET: api/Medicineprescriptions
        [HttpGet("preslab")]
        public async Task<ActionResult<IEnumerable<Testprescription>>> Getthelabprescription()
        {
            return await _repository.Getthelabprescription();
        }

        // POST: api/Medicineprescriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("preslab")]
        public async Task<ActionResult<Testprescription>> Postthelabprescription(Testprescription Testprescription)
        {
            if (ModelState.IsValid)
            {

                var pres = await _repository.Postthelabprescription(Testprescription);
                // return Ok(newEmployeeId);
                if (pres != null)
                {
                    return pres;
                }
                else
                {

                }
                return NotFound();
            }
            return BadRequest();
        }



        #endregion


        #region Diagnose history view 

        [HttpGet("DiaHis/{id}")]
        public async Task<ActionResult<IEnumerable<DoctorDiagnoseHistoryVM>>> GetDiagnosehistory(int id)
        {

            return await _repository.GetDiagnosehistoryViewModel(id);

        }

        #endregion


        #region Medicine prescription history view

        [HttpGet("MedHis/{patid}")]
        public async Task<ActionResult<IEnumerable<DoctorMedicineHistoryVMcs>>> GetMedicineHistoryViewModel(int patid)
        {
            return await _repository.GetMedicineHistoryViewModel(patid);
        }

        #endregion


        #region lab test prescription history view

        [HttpGet("labHis/{patid}")]
        public async Task<ActionResult<IEnumerable<DoctorLabTestPresHistoryVM>>> GetLabtestprescribedViewModel(int patid)
        {
            return await _repository.GetLabtestprescribedViewModel(patid);
        }

        #endregion
    }
}
