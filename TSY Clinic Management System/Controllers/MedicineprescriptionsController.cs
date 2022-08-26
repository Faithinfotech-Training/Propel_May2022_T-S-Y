using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.Repository;
using TSY_Clinic_Management_System.View_Model;

namespace TSY_Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineprescriptionsController : ControllerBase
    {
        private readonly IMedicinePrescriptionRepo _repo;

        public MedicineprescriptionsController(IMedicinePrescriptionRepo repo)
        {
            _repo = repo;
        }

        //Get all Medicine Prescription
        [HttpGet]
        [Route("GetPres")]
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription()
        {

            return await _repo.GetAllMedicineprescription();
        }

        //Get med presciption by Id
        [HttpGet("{presId}")]
        public async Task<ActionResult<Medicineprescription>> GetMedicinePrescriptionbyId(int presId)
        {
            var medicineprescript = await _repo.GetMedicinePrescriptionbyId(presId);

            if (medicineprescript == null)
            {
                return NotFound();
            }

            return medicineprescript;
        }

        //Update the Medicine prescription
        [HttpPut]
        public async Task<ActionResult<Medicineprescription>> PutMedicineprescription(Medicineprescription medicineprescription)
        {
            if (ModelState.IsValid)
            {
                var EditMedPres = await _repo.PutMedicineprescription(medicineprescription);
                if (EditMedPres == null)
                {
                    return NotFound();
                }
                return EditMedPres;
                //return Ok(EditEmp);
            }
            return medicineprescription;
        }
      
        //Insert the medicines
        [HttpPost]
        [Route("addmedpres")]

        public async Task<ActionResult<Medicineprescription>> PostMedicineprescription([FromBody] Medicineprescription medicineprescription)
        {

            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named medicineprescription
                var Pres = await _repo.PostMedicineprescription(medicineprescription);

                if (Pres != null)
                {
                    return Ok(Pres);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }
        //View model for prescription
        [HttpGet]
        [Route("vmprescription")]
        public async Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription()
        {

            return await _repo.GetViewModelMedicinePrescription();
        }

        //View model for Bills
        [HttpGet]
        [Route("medbills")]

        public async Task<ActionResult<BillGenerationViewModel>> GetViewModelMedicineBills()
        {
            return await _repo.GetViewModelMedicineBills();
        }

    }
}
