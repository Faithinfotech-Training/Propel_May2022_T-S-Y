using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TSY_Clinic_Management_System.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Doctor = new HashSet<Doctor>();
            Patient = new HashSet<Patient>();
            Users = new HashSet<Users>();
        }

        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime Dob { get; set; }
        public int? BloodGroupId { get; set; }
        public int? GenderId { get; set; }
        public string Education { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? RoleId { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
