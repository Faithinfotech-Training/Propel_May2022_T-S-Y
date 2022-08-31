using TSY_Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TSY_Clinic_Management_System.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CLINIC_DBContext _context;

        public UsersRepository(CLINIC_DBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Users>> GetUsersbypassword(string UserName, string Password)
        {
            if (_context != null)
            {
                if (caseCheckUserNameAndPassword(UserName, Password))
                {
                    //checking username and password
                    Users tbluser = await _context.Users.Include(e => e.Role).Include(b => b.Staff).FirstOrDefaultAsync(up => up.UserName == UserName && up.Password == Password);
                    return tbluser;
                }

            }
            return null;
        }
        private bool caseCheckUserNameAndPassword(string UserName, string Password)
        {
            //loading to memory array
            var users = _context.Users.Where(u => u.UserName == UserName).ToArray();
            //compare

            if (users.Any(u => u.UserName == UserName && u.Password == Password))
            {
                return true;
            }
            return false;
        }
    }
}

