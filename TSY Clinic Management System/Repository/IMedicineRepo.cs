using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IMedicineRepo
    {
        //Get all Medicines
        public Task<ActionResult<IEnumerable<Medicine>>> GetMedicine();
        //Get Medicine by Id
        public Task<ActionResult<Medicine>> GetMedicinebyId(int id);
        //Update without using Id
        public Task<ActionResult<Medicine>> EditMedicine(Medicine med);
        //insert Medicine
        public Task<ActionResult<Medicine>> PostMedicine(Medicine med);
        


    }
}
