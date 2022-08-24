using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class CLINIC_DBContext : DbContext
    {
        public CLINIC_DBContext()
        {
        }

        public CLINIC_DBContext(DbContextOptions<CLINIC_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Labtest> Labtest { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineTiming> MedicineTiming { get; set; }
        public virtual DbSet<MedicineView> MedicineView { get; set; }
        public virtual DbSet<Medicineprescription> Medicineprescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<ReportNote> ReportNote { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<TestView> TestView { get; set; }
        public virtual DbSet<Testprescription> Testprescription { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SAJNA-NAZIR\\SQLEXPRESS;Database= CLINIC_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.AppointmentDate)
                    .HasColumnName("Appointment_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.TokenNo).HasColumnName("Token_No");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Depar__1332DBDC");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__14270015");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__151B244E");
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("Blood_group");

                entity.Property(e => e.BloodGroupId).HasColumnName("Blood_group_id");

                entity.Property(e => e.BloodGroupName)
                    .IsRequired()
                    .HasColumnName("Blood_group_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("Department_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.ConsultationFees).HasColumnName("Consultation_Fees");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.SpecializationId).HasColumnName("Specialization_Id");

                entity.Property(e => e.StaffId).HasColumnName("Staff_Id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Doctor__Departme__160F4887");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__Speciali__17036CC0");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doctor__Staff_Id__17F790F9");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId).HasColumnName("Gender_Id");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasColumnName("Gender_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Labtest>(entity =>
            {
                entity.HasKey(e => e.TestId)
                    .HasName("PK__Labtest__B502D0225299C5E6");

                entity.Property(e => e.TestId).HasColumnName("Test_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TestName)
                    .IsRequired()
                    .HasColumnName("Test_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("Medicine_Id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GenericName)
                    .IsRequired()
                    .HasColumnName("Generic_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("Medicine_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnName("Unit_Price");
            });

            modelBuilder.Entity<MedicineTiming>(entity =>
            {
                entity.Property(e => e.MedicineTimingId).HasColumnName("Medicine_Timing_Id");

                entity.Property(e => e.MedicineTiming1)
                    .HasColumnName("Medicine_Timing")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicineView>(entity =>
            {
                entity.ToTable("Medicine_View");

                entity.Property(e => e.MedicineViewId).HasColumnName("Medicine_view_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MedicineAmount).HasColumnName("Medicine_Amount");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("Medicine_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineprescriptionId).HasColumnName("Medicineprescription_Id");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Medicineprescription)
                    .WithMany(p => p.MedicineView)
                    .HasForeignKey(d => d.MedicineprescriptionId)
                    .HasConstraintName("FK__Medicine___Medic__18EBB532");
            });

            modelBuilder.Entity<Medicineprescription>(entity =>
            {
                entity.Property(e => e.MedicineprescriptionId).HasColumnName("Medicineprescription_Id");

                entity.Property(e => e.Course)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.MedicineId).HasColumnName("Medicine_Id");

                entity.Property(e => e.MedicineTimingId).HasColumnName("Medicine_Timing_Id");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.PrescriptionId).HasColumnName("Prescription_Id");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Medicineprescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Medicinep__Docto__19DFD96B");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.Medicineprescription)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__Medicinep__Medic__1AD3FDA4");

                entity.HasOne(d => d.MedicineTiming)
                    .WithMany(p => p.Medicineprescription)
                    .HasForeignKey(d => d.MedicineTimingId)
                    .HasConstraintName("FK__Medicinep__Medic__1BC821DD");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Medicineprescription)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Medicinep__Patie__1CBC4616");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.Medicineprescription)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__Medicinep__Presc__1DB06A4F");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroupId).HasColumnName("Blood_group_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("Gender_Id");

                entity.Property(e => e.IsActive).HasColumnName("Is_active");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasColumnName("Patient_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("Staff_Id");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK__Patient__Blood_g__1EA48E88");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Patient__Gender___1F98B2C1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Patient__Staff_I__208CD6FA");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.Property(e => e.PrescriptionId).HasColumnName("Prescription_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Diagnosis)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Prescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Prescript__Appoi__2180FB33");
            });

            modelBuilder.Entity<ReportNote>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK__ReportNo__F94B56A7B9A8FC71");

                entity.Property(e => e.NoteId).HasColumnName("Note_Id");

                entity.Property(e => e.AppliedDate)
                    .HasColumnName("Applied_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoteDescription)
                    .IsRequired()
                    .HasColumnName("Note_description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrescriptionId).HasColumnName("Prescription_id");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.ReportNote)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__ReportNot__Presc__22751F6C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("Role_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationId).HasColumnName("Specialization_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.SpecializationName)
                    .IsRequired()
                    .HasColumnName("Specialization_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Specialization)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Specializ__Depar__236943A5");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId).HasColumnName("Staff_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroupId).HasColumnName("Blood_group_id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfJoining)
                    .HasColumnName("Date_Of_Joining")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Education)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("Gender_Id");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_Date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasColumnName("Staff_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK__Staff__Blood_gro__245D67DE");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Staff__Gender_Id__25518C17");
            });

            modelBuilder.Entity<TestView>(entity =>
            {
                entity.ToTable("Test_view");

                entity.Property(e => e.TestViewId).HasColumnName("Test_view_Id");

                entity.Property(e => e.AppliedDate)
                    .HasColumnName("Applied_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HighRange)
                    .HasColumnName("High_range")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.LowRange)
                    .HasColumnName("Low_range")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NormalRange)
                    .HasColumnName("Normal_range")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TestAmount).HasColumnName("Test_amount");

                entity.Property(e => e.TestprescriptionId).HasColumnName("Testprescription_Id");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Testprescription)
                    .WithMany(p => p.TestView)
                    .HasForeignKey(d => d.TestprescriptionId)
                    .HasConstraintName("FK__Test_view__Testp__2645B050");
            });

            modelBuilder.Entity<Testprescription>(entity =>
            {
                entity.Property(e => e.TestprescriptionId).HasColumnName("Testprescription_Id");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("Created_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("Modified_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrescriptionId).HasColumnName("Prescription_Id");

                entity.Property(e => e.TestId).HasColumnName("Test_Id");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.Testprescription)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK__Testpresc__Presc__2739D489");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.Testprescription)
                    .HasForeignKey(d => d.TestId)
                    .HasConstraintName("FK__Testpresc__Test___282DF8C2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__206D9170ED26EF67");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.Property(e => e.StaffId).HasColumnName("Staff_Id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__Role_Id__29221CFB");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Users__Staff_Id__2A164134");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
