using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IPharmacistsRepository
    {
        //Get
        public Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView();
        //Post
        public Task<ActionResult<MedicineView>> PostMedicineView(MedicineView medicineView);
        //Post for bill table
        public Task<ActionResult<BillTable>> PostBillTable(BillTable billTable);

        //ViewModel for view prescription
        public Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription();
        //ViewModel for Medicine Bill
        public Task<ActionResult<IEnumerable<BillGenerationViewModel>>> GetViewModelMedicineBills();
        //Get all Medicine prescription
        public Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription();

    }
}
