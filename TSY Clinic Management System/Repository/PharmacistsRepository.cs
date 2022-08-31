using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;
using System.Linq;


namespace TSY_Clinic_Management_System.Repository
{
    public class PharmacistsRepository : IPharmacistsRepository
    {
        private readonly CLINIC_DBContext _context;

        public PharmacistsRepository(CLINIC_DBContext context)
        {
            _context = context;
        }
        //Get all Doctor's Medicine Prescription
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription()
        {
            if (_context != null)
            {
                return await _context.Medicineprescription.Include(e => e.MedicineTiming).ToListAsync();
                
            }
            return null;
        }

        //Get
        public async Task<ActionResult<IEnumerable<MedicineView>>> GetMedicineView()
        {
            if (_context != null)
            {
                return await _context.MedicineView.Include(e => e.Medicineprescription).ToListAsync();  //step 4 taken from controller class and paste here
            }
            return null;
        }
        //ViewModel for Bill Generation
        public async Task<ActionResult<IEnumerable<BillGenerationViewModel>>> GetViewModelMedicineBills()
        {
            if (_context != null)
            {
                return await (from Ap in _context.Appointment

                              from p in _context.Patient

                              from s in _context.Staff

                              from M in _context.BillTable

                              from d in _context.Doctor
                              from m in _context.Medicine

                              from mp in _context.Medicineprescription

                              where s.RoleId == 3 && p.PatientId == M.PatientId && p.PatientId == Ap.PatientId && M.PatientId == Ap.PatientId &&

                              Ap.DoctorId == d.DoctorId && m.MedicineId == mp.MedicineId

                              select new BillGenerationViewModel

                              {

                                  PatientName = p.PatientName,

                                  StaffName = s.StaffName,
                                  BillAmount = M.BillAmount,

                                  MedicineName = m.MedicineName,
                                  Course = mp.Course,
                                  MedicineTimingId = mp.MedicineTimingId,
                                  CreatedDate = mp.CreatedDate,

                                  Quantity = m.Quantity,
                                  Unit = m.Unit,
                                  UnitPrice = m.UnitPrice


                              //}).FirstOrDefaultAsync();
                }).ToListAsync();
            }
            return null;
        }

        //ViewModel for Prescription
        public async Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription()
        {
            if (_context != null)
            {
                //Linq
                return await (from p in _context.Patient
                              from s in _context.Staff
                              from d in _context.Doctor
                              from pr in _context.Prescription
                              from mp in _context.Medicineprescription
                              from m in _context.Medicine
                              from g in _context.Gender
                              from mt in _context.MedicineTiming
                              where mp.PatientId == p.PatientId
                              where p.GenderId == g.GenderId
                              where mp.DoctorId == d.DoctorId
                              where d.StaffId == s.StaffId
                              where mp.PrescriptionId == pr.PrescriptionId
                              where mp.MedicineId == m.MedicineId
                              where mp.MedicineTimingId == mt.MedicineTimingId

                              select new ViewMedicinePrescriptionVM
                              {
                                  PatientId = Convert.ToInt32(mp.PatientId),
                                  PatientName = p.PatientName,
                                  GenderName = g.GenderName,
                                  DoctorName = s.StaffName,
                                  Diagnosis = pr.Diagnosis,
                                  MedicineprescriptionId = mp.MedicineprescriptionId,
                                  MedicineName = m.MedicineName,
                                  Quantity = m.Quantity,
                                  MedicineTiming1 = mt.MedicineTiming1,
                                  Course = mp.Course,
                                  CreatedDate = mp.CreatedDate
                              }).ToListAsync();
            }
            return null;
        }

        //Post BillTable
        public async Task<ActionResult<BillTable>> PostBillTable(BillTable billTable)
        {
            if (_context != null)
            {
                billTable.BillDate = DateTime.Today;
                await _context.BillTable.AddAsync(billTable);
                await _context.SaveChangesAsync();

                return billTable;
            }
            return null;
        }

        //Post
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
        

    }
}
