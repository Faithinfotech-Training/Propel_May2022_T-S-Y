using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public class MedicineViewRepo : IMedViewRepo
    {
        private readonly CLINIC_DBContext _context;

        public MedicineViewRepo(CLINIC_DBContext context)
        {
            _context = context;
        }
        //Get medicine view
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            if (_context != null)
            {
                return await _context.MedicineView.ToListAsync();

            }
            return null;
        }
        //Insert Medicine View
        
        public async Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView)
        {
            if (_context != null)
            {
                await _context.MedicineView.AddAsync(medicineView);
                await _context.SaveChangesAsync();

                return medicineView;
            }
            return null;
        }

        //Update Medicine View
        public async Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView)
        {
            if (medicineView.MedicineViewId == 0)
            {
                return null;
            }
            medicineView.CreatedDate = DateTime.Now;
            _context.Entry(medicineView).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return medicineView;
        }
        

    }

}
