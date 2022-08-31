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
    public class PharmacistsController : ControllerBase
    {
        private readonly IPharmacistsRepository _repository;

        public PharmacistsController(IPharmacistsRepository repository)
        {
            _repository = repository;
        }


        // GET: api/Pharmacists
        [HttpGet]
        [Route("MedicineView")]
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            
            return await _repository.GetMedicineView();
        }
        //Post for Billing
        [HttpPost] //method-2
        [Route("Billing")]

        public async Task<ActionResult<BillTable>> PostBillTable([FromBody] BillTable billTable)
        {

            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named employee
                var bills = await _repository.PostBillTable(billTable);

                if (bills != null)
                {
                    return Ok(bills);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }

        // POST: api/Pharmacists       
        [HttpPost]
        [Route("addMedicineView")]

        public async Task<ActionResult<MedicineView>> PostMedicineView([FromBody] MedicineView medicineView)
        {

            if (ModelState.IsValid)
            {
                
                var meds = await _repository.PostMedicineView(medicineView);

                if (meds != null)
                {
                    return Ok(meds);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }

        //ViewModel for Bill generation
        [HttpGet]
        [Route("Bills")]

        public async Task<ActionResult<IEnumerable<BillGenerationViewModel>>> GetViewModelMedicineBills()
        {
            return await _repository.GetViewModelMedicineBills();
        }

        //Get all Doc Medicine prescription
        [HttpGet]
        [Route("Prescription")]
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription()
        {

            return await _repository.GetAllMedicineprescription();
        }      

        //ViewModel for prescription
        [HttpGet]
        [Route("ViewPatientPrescription")]
        public async Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription()
        {

            return await _repository.GetViewModelMedicinePrescription();
        }
        
    }
}
