using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public class MedicineRepo : IMedicineRepo
    {
        private readonly CLINIC_DBContext _context;

        public MedicineRepo(CLINIC_DBContext context)
        {
            _context = context;
        }
        //Update Medicine
        public async Task<ActionResult<Medicine>> EditMedicine(Medicine med)
        {
            if (med.MedicineId == 0)
            {
                return null;
            }
            med.CreatedDate = DateTime.Now;
            _context.Entry(med).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return med;
        }
        

        //Get all Medicines from DB
        public async Task<ActionResult<IEnumerable<Medicine>>> GetMedicine()
        {
            if (_context != null)
            {
                return await _context.Medicine.ToListAsync();
                
            }
            return null;
            
        }
        //Search By ID
        public async Task<ActionResult<Medicine>> GetMedicinebyId(int id)
        {
            if (_context != null)
            {
                var meds = await _context.Medicine.FirstOrDefaultAsync(e => e.MedicineId == id);
                return meds;
            }

            return null;
        }


        //Insert Medicines
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine med)
        {
            if (_context != null)
            {
                await _context.Medicine.AddAsync(med);
                await _context.SaveChangesAsync();

                return med;
            }
            return null;
        }
        

    }
}
