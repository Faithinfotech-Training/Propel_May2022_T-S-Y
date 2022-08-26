using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TSY_Clinic_Management_System.Models;

namespace TSY_Clinic_Management_System.Repository
{
    public class LoginRep : ILoginRep
    {
        private readonly CLINIC_DBContext _context;

        public LoginRep(CLINIC_DBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Users>> GetTblUserbyPassword(string us, string ps)
        {
            if (_context != null)
            {
                if (CaseUsernameAndPassword(us, ps))
                {
                    Users users = await _context.Users.FirstOrDefaultAsync(u => u.UserName.Contains(us) && u.Password.Contains(ps));
                    return users;
                }
            }
            return null;
        }
        private bool CaseUsernameAndPassword(string us, string ps)
        {
            //Load into memory --array
            var users = _context.Users.Where(u => u.UserName == us).ToArray();

            //Compare IN
            if (users.Any(u => u.UserName == us && u.Password == ps))
            {
                return true;
            }
            return false;
            
        }
    }
}
