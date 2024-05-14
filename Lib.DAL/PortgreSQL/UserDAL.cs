using DAL.Generic;
using ENTITIES.Models;
using Lib.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DAL.PortgreSQL
{
  
    public class UserDAL : GenericService<User>
    {
        public UserDAL(string connection) : base(connection)
        {

        }
        public async Task<User?> GetById(int id)
        {
            try
            {
                using (var _DbContext = new PortgreDataContext(_connection))
                {
                    return await _DbContext.Users.FirstOrDefaultAsync(s => s.Id==id);
                }
            }
            catch 
            {
                return null;
            }
        }
    }
}
