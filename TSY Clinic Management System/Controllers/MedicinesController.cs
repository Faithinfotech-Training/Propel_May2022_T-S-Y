using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.Repository;

namespace TSY_Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineRepo _repo;

        public MedicinesController(IMedicineRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicine()
        {
            return await _repo.GetMedicine();
        }


        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicine>> GetMedicinebyId(int id)
        {
            var medicine = await _repo.GetMedicinebyId(id);

            if (medicine == null)
            {
                return NotFound();
            }

            return medicine;
        }
        
        // PUT: api/Medicines
        [HttpPut]
        public async Task<ActionResult<Medicine>> EditMedicine(Medicine med)
        {
            if (ModelState.IsValid)
            {
                var EditMed = await _repo.EditMedicine(med);
                if(EditMed == null)
                {
                    return NotFound();
                }
                return EditMed;
                //return Ok(EditEmp);
            }
            return med;
        }
        //Insert the medicines
        [HttpPost]
        [Route("AddMed")]

        public async Task<ActionResult<Medicine>> PostMedicine([FromBody] Medicine med)
        {
            
            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named med
                var Meds = await _repo.PostMedicine(med);

                if (Meds != null)
                {
                    return Ok(Meds);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }

        
    }
}
