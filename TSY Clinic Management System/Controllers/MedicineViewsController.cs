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
    public class MedicineViewsController : ControllerBase
    {
        private readonly IMedViewRepo _repo;

        public MedicineViewsController(IMedViewRepo repo)
        {
            _repo = repo;
        }

        // GET: api/MedicineViews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            return await _repo.GetMedicineView();
        }

        //PUT: UPDATE MEDICINE VIEW
        [HttpPut]
        public async Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView)
        {
            if (ModelState.IsValid)
            {
                var EditMedView = await _repo.PutMedicineView(medicineView);
                if (EditMedView == null)
                {
                    return NotFound();
                }
                return EditMedView;
                //return Ok(EditEmp);
            }
            return medicineView;
        }

        // POST: api/MedicineViews
        [HttpPost]
        [Route("MedView")]

        public async Task<ActionResult<MedicineView>> PostMedicineView([FromBody] MedicineView medicineView)
        {

            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named medicineView
                var MedViews = await _repo.PostMedicineView(medicineView);

                if (MedViews != null)
                {
                    return Ok(MedViews);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();

        }
        

        //private bool MedicineViewExists(int id)
        //{
        //    return _context.MedicineView.Any(e => e.MedicineViewId == id);
        //}
    }
}
