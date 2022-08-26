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
    public class BillTablesController : ControllerBase
    {
        private readonly IBillGeneration _repo;

        public BillTablesController(IBillGeneration repo)
        {
            _repo = repo;
        }

        
        // GET: api/BillTables/Bills
        [HttpGet]
        [Route("Bills")]
        public async Task<ActionResult<IEnumerable<BillTable>>> GetBillTable()
        {

            return await _repo.GetBillTable();
        }
        //Put
        [HttpPut]
        public async Task<ActionResult<BillTable>> PutBillTable(BillTable billTable)
        {
            if (ModelState.IsValid)
            {
                var billtB = await _repo.PutBillTable(billTable);
                if (billtB == null)
                {
                    return NotFound();
                }
                return billtB;
                //return Ok(EditEmp);
            }
            return billTable;
        }
        //Post
        [HttpPost]
        [Route("addBill")]

        public async Task<ActionResult<BillTable>> PostBillTable([FromBody] BillTable billTable)
        {

            if (ModelState.IsValid)
            {
                //insert a new record and return as an object named medicineprescription
                var addbill = await _repo.PostBillTable(billTable);

                if (addbill != null)
                {
                    return Ok(addbill);
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
