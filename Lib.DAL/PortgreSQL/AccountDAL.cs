using DAL.Generic;
using ENTITIES.Models;
using Lib.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Lib.DAL.PortgreSQL
{
    public class AccountDAL : GenericService<Account>
    {
        public AccountDAL(string connection) : base(connection)
        {

        }
        public async Task<Account?> GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    return await _DbContext.Accounts.FirstOrDefaultAsync(s => s.Username.Trim()== username.Trim() && s.Password.Trim() == password.Trim());
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
