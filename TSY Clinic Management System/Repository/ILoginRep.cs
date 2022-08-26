using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public interface ILoginRep
    {
        //Login 
        public Task<ActionResult<Users>> GetTblUserbyPassword(string us, string ps);
    }
}
