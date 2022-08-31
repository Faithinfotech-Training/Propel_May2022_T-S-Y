using CMSByTeamJava.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;
using TSY_Clinic_Management_System.View_Model;

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


        public int TempAppointmentId;

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
                              where dr.StaffId == staffid
                              where dr.DoctorId==a.DoctorId
                              where a.PatientId == p.PatientId
                              //where (a.AppointmentDate >= startDateTime && a.AppointmentDate <= endDateTime) 
                              let TempAppointmentId=a.AppointmentId
                              select new GetAppointedPatientsViewmodel
                              {
                                  PatientId = p.PatientId,
                                  AppointmentId = a.AppointmentId,
                                  TokenNo = a.TokenNo,
                                  PatientName = p.PatientName,
                                  Mobile = p.Mobile

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

               // prescription.AppointmentId = TempAppointmentId;
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

        public async Task<ActionResult<IEnumerable<DoctorsLabReportViewModel>>> GetLabViewModel(int patitentId)
        {
            if (_context != null)
            {

                return await (from a in _context.Appointment
                              from p in _context.Prescription
                              from lt in _context.Labtest
                              from pt in _context.Patient
                              from tv in _context.TestView
                              from tp in _context.Testprescription
                              where a.PatientId==patitentId
                              where a.PatientId == pt.PatientId
                              where a.AppointmentId == p.AppointmentId 
                              where tv.TestprescriptionId == tp.TestprescriptionId 
                              where tp.TestId == lt.TestId
                              where tp.PrescriptionId == p.PrescriptionId 
                              where p.AppointmentId == a.AppointmentId
                              select new DoctorsLabReportViewModel
                              {
                                  PatientName = pt.PatientName,
                                  TestName = lt.TestName,
                                  HighRange = tv.HighRange,
                                  LowRange = tv.LowRange,
                                  NormalRange = tv.NormalRange

                              }).ToListAsync();
            }
            return null;

        }



        #endregion

        #region lab prescribe Controller

        public async Task<ActionResult<IEnumerable<Testprescription>>> Getthelabprescription()
        {
            if (_context != null)
            {

                return await _context.Testprescription.ToListAsync();

            }
            return null;
        }

        public async Task<ActionResult<Testprescription>> Postthelabprescription(Testprescription Testprescription)
        {
            if (_context != null)
            {


                _context.Testprescription.Add(Testprescription);
                await _context.SaveChangesAsync();

                return Testprescription;


            }
            return null;
        }

        #endregion


        #region DiagnoseHistory VM

        public async Task<ActionResult<IEnumerable<DoctorDiagnoseHistoryVM>>> GetDiagnosehistoryViewModel(int pid)
        {
            if (_context != null)
            {
                ////LINQ

                return await (from a in _context.Appointment
                              from p in _context.Patient
                              from pr in _context.Prescription

                              where p.PatientId == pid
                              where a.PatientId == p.PatientId
                              where a.AppointmentId == pr.AppointmentId

                              select new DoctorDiagnoseHistoryVM
                              {
                                  PatientName = p.PatientName,
                                  CreatedDate = pr.CreatedDate,
                                  Diagnosis = pr.Diagnosis

                              }).ToListAsync();


            }
            return null;
        }

        #endregion

        #region MedicineHistory VM

        public async Task<ActionResult<IEnumerable<DoctorMedicineHistoryVMcs>>> GetMedicineHistoryViewModel(int patid)
        {
            if (_context != null)
            {

                return await (from mp in _context.Medicineprescription
                              from m in _context.Medicine
                              from mt in _context.MedicineTiming
                              from p in _context.Patient
                                  //where p.PatientId == pid
                              where mp.PatientId == patid
                              where m.MedicineId == mp.MedicineId
                              where mt.MedicineTimingId == mp.MedicineTimingId
                              select new DoctorMedicineHistoryVMcs
                              {
                                  MedicineName = m.MedicineName,

                                  Course = mp.Course,

                                  MedicineTiming1 = mt.MedicineTiming1

                              }).ToListAsync();
            }
            return null;

        }



        #endregion

        #region labtestHistory VM

        public async Task<ActionResult<IEnumerable<DoctorLabTestPresHistoryVM>>> GetLabtestprescribedViewModel(int patid)
        {

            if (_context != null)
            {

                return await (from l in _context.Labtest
                              from tp in _context.Testprescription
                              from pr in _context.Prescription
                              from a in _context.Appointment
                              where a.PatientId == patid
                              where pr.AppointmentId == a.AppointmentId
                              where pr.PrescriptionId == tp.PrescriptionId
                              where tp.TestId == l.TestId
                              select new DoctorLabTestPresHistoryVM
                              {
                                  CreatedDate = l.CreatedDate,
                                  TestName = l.TestName


                              }).ToListAsync();
            }
            return null;
        }

        #endregion
    }
}
