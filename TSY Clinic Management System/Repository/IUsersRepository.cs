using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public interface IUsersRepository
    {
        public Task<ActionResult<Users>> GetUsersbypassword(string UserName, string Password);
    }
}
