using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IMedicinePrescriptionRepo
    {
        
        //public Task<ActionResult<Medicineprescription>> UpdateMedicinePrescription(MedicinePrescription med);
        //Insert Medicine prescription
        public Task<ActionResult<Medicineprescription>> PostMedicineprescription(Medicineprescription medicineprescription);
        //Update the Medicine prescription
        public Task<ActionResult<Medicineprescription>> PutMedicineprescription(Medicineprescription medicineprescription);
        //Get all Medicineprescription
        public Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription();
        //Get all MedicinesPrescription by Id
        public Task<ActionResult<Medicineprescription>> GetMedicinePrescriptionbyId(int id);
        //ViewModel for view prescription
        public Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription();
        //ViewModel for Medicine Bill
        public Task<ActionResult<BillGenerationViewModel>> GetViewModelMedicineBills();

    }
}
