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
    public class MedicinePrescriptionRepo : IMedicinePrescriptionRepo
    {
        private readonly CLINIC_DBContext _context;

        public MedicinePrescriptionRepo(CLINIC_DBContext context)
        {
            _context = context;
        }
        //Post medicine prescription
        public async Task<ActionResult<Medicineprescription>> PostMedicineprescription(Medicineprescription medicineprescription)
        {
            if (_context != null)
            {
                await _context.Medicineprescription.AddAsync(medicineprescription);
                await _context.SaveChangesAsync();
                return medicineprescription;
            }
            return null;
        }
        //Update the medicine prescription
        public async Task<ActionResult<Medicineprescription>> PutMedicineprescription(Medicineprescription medicineprescription)
        {
            if (medicineprescription.MedicineprescriptionId == 0)
            {
                return null;
            }
            medicineprescription.CreatedDate = DateTime.Now;
            _context.Entry(medicineprescription).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return medicineprescription;
        }
        //Get all medicine prescription by Id
        public async Task<ActionResult<Medicineprescription>> GetMedicinePrescriptionbyId(int presId)
        {
            if (_context != null)
            {
                var pres = await _context.Medicineprescription.FirstOrDefaultAsync(p => p.MedicineprescriptionId == presId);
                return pres;
            }
            return null;
        }
        //Get all Medicine Prescription
        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GetAllMedicineprescription()
        {
            if (_context != null)
            {
                //return await _context.Department.Include(e => e.Employee).ToListAsync();
                return await _context.Medicineprescription.ToListAsync();
            }
            return null;
        }
        //View Model for View prescription
        public async Task<ActionResult<IEnumerable<ViewMedicinePrescriptionVM>>> GetViewModelMedicinePrescription()
        {
            //Linq
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
                              where mp.PatientId==p.PatientId
                              where p.GenderId == g.GenderId
                              where mp.DoctorId==d.DoctorId
                              where d.StaffId==s.StaffId
                              where mp.PrescriptionId==pr.PrescriptionId
                              where mp.MedicineId==m.MedicineId
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

        public async Task<ActionResult<BillGenerationViewModel>> GetViewModelMedicineBills()
        {
            if (_context != null)
            {
                return await (from Ap in _context.Appointment

                              from P in _context.Patient

                              from S in _context.Staff

                              from M in _context.BillTable

                              from D in _context.Doctor
                              from md in _context.Medicine

                              from E in _context.Medicineprescription

                              where S.RoleId == 3 && P.PatientId == M.PatientId && P.PatientId == Ap.PatientId && M.PatientId == Ap.PatientId &&

                              Ap.DoctorId == D.DoctorId && md.MedicineId == E.MedicineId

                              select new BillGenerationViewModel

                              {

                                  PatientName = P.PatientName,

                                  StaffName = S.StaffName,
                                  BillAmount = M.BillAmount,

                                  MedicineName = md.MedicineName,
                                  Course = E.Course,
                                  MedicineTimingId = E.MedicineTimingId,
                                  CreatedDate = E.CreatedDate,

                                  Quantity = md.Quantity,
                                  Unit = md.Unit,
                                  UnitPrice = md.UnitPrice


                              }).FirstOrDefaultAsync();
                              //}).ToListAsync();
            }
            return null;
        }
    }
}
