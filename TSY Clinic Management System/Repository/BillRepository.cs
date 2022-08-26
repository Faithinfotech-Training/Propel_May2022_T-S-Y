using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public class BillRepository : IBillGeneration
    {
        private readonly CLINIC_DBContext _context;

        public BillRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        //Get Bill
        public async Task<ActionResult<IEnumerable<BillTable>>> GetBillTable()
        {
            if (_context != null)
            {
                return await _context.BillTable.ToListAsync();

            }
            return null;

        }
        //Post
        public async Task<ActionResult<BillTable>> PostBillTable(BillTable billTable)
        {
            if (_context != null)
            {
                await _context.BillTable.AddAsync(billTable);
                await _context.SaveChangesAsync();

                return billTable;
            }
            return null;
        }

        //Put
        public async Task<ActionResult<BillTable>> PutBillTable(BillTable billTable)
        {
            if (billTable.BillNumber == 0)
            {
                return null;
            }
            billTable.CreatedDate = DateTime.Now;
            _context.Entry(billTable).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return billTable;
        }
    }
}
