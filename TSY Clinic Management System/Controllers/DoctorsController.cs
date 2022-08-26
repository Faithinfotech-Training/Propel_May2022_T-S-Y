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

        // GET: api/Doctors/Dashboard
        [HttpGet("Dashboard")]
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

        [HttpGet("labview")]
        public async Task<ActionResult<IEnumerable<DoctorsLabReportViewModel>>> GetLabViewModel()
        {
            return await _repository.GetLabViewModel();
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
        [HttpPost("Medicineprescriptions")]
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
    }
}
