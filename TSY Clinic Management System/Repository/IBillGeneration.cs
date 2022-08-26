using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IBillGeneration
    {
        //Get
        public Task<ActionResult<IEnumerable<BillTable>>> GetBillTable();
        
        //Update
        public Task<ActionResult<BillTable>> PutBillTable(BillTable billTable);
        //Post
        public Task<ActionResult<BillTable>> PostBillTable(BillTable billTable);
    }
}
