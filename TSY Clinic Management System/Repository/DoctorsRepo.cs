using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TSY_Clinic_Management_System.Repository
{
    public class DoctorsRepo:IDoctorsRepo
    {
        private readonly CLINIC_DBContext _context;


        //Default Constructor
        public DoctorsRepo(CLINIC_DBContext context)
        {
            _context = context;
        }


        #region GetAppointedPatients

        
        public async Task<ActionResult<IEnumerable<GetAppointedPatientsViewmodel>>> GetAppointedPatients(int staffid)
        {
            if (_context != null)
            {  //LINQ
                DateTime startDateTime = DateTime.Today;
                DateTime endDateTime = DateTime.Today.AddDays(1).AddTicks(-1);

                return await (from a in _context.Appointment
                              from p in _context.Patient
                              from dr in _context.Doctor
                              where a.DoctorId==dr.DoctorId
                              where dr.StaffId == staffid
                              where a.PatientId == p.PatientId
                              where (a.AppointmentDate >= startDateTime && a.AppointmentDate <= endDateTime) 
                              
                              select new GetAppointedPatientsViewmodel
                              {
                                  AppointmentId = a.AppointmentId,
                                  PatientName = p.PatientName,
                                  Status = a.Status,
                                  TokenNo = a.TokenNo

                              }).ToListAsync();
            }
            return null;
        
        }

        #endregion

        #region DiagnoseNotes

        

        public async Task<ActionResult<IEnumerable<Prescription>>> GetpatientPrescription()
        {
            if (_context != null)
            {

                return await _context.Prescription.ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<Prescription>> PostdiaPrescription(Prescription prescription)
        {
            if (_context != null)
            {


                _context.Prescription.Add(prescription);
                await _context.SaveChangesAsync();

                return prescription;


            }
            return null;
        }


        #endregion

        #region Med prescribe

        public async Task<ActionResult<IEnumerable<Medicineprescription>>> GettheMedicineprescription()
        {
            if (_context != null)
            {

                return await _context.Medicineprescription.Include(e => e.MedicineTiming).ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<Medicineprescription>> PosttheMedicineprescription(Medicineprescription medicineprescription)
        {
            if (_context != null)
            {


                _context.Medicineprescription.Add(medicineprescription);
                await _context.SaveChangesAsync();

                return medicineprescription;


            }
            return null;
        }

        #endregion

        #region Lab view model

        public async Task<ActionResult<IEnumerable<DoctorsLabReportViewModel>>> GetLabViewModel()
        {
            if (_context != null)
            {

                return await (from a in _context.Appointment
                              from b in _context.Prescription
                              from c in _context.Labtest
                              from d in _context.Patient
                              from e in _context.TestView
                              from f in _context.Testprescription
                              where (a.AppointmentId == b.AppointmentId) && (e.TestprescriptionId == f.TestprescriptionId) && (f.TestId == c.TestId) &&
                              (f.PrescriptionId == b.PrescriptionId) && (b.AppointmentId == a.AppointmentId) && (a.PatientId == d.PatientId)

                              select new DoctorsLabReportViewModel
                              {
                                  PatientName = d.PatientName,
                                  TestName = c.TestName,
                                  HighRange = e.HighRange,
                                  LowRange = e.LowRange,
                                  NormalRange = e.NormalRange

                              }).ToListAsync();
            }
            return null;

        }



        #endregion


    }
}
