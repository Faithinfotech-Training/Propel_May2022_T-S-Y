using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IMedViewRepo
    {
        //Get Medicine View
        public Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView();
        //Update the Medicine View
        public Task<ActionResult<MedicineView>> PutMedicineView(MedicineView medicineView);
        //Insert the Medicine View
        public Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView);
        

    }
}
