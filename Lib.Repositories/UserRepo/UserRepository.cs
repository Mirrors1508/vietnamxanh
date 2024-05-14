using Lib.DAL.PortgreSQL;
using Lib.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Lib.Repositories.AccountRepo
{
    public class UserRepository : IUserRepository
    {
       
        private readonly UserDAL _userDAL;
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _userDAL = new UserDAL(configuration["DbConnection:PortgreSQL"]);
        }
        public async Task<User?> GetById(int id)
        {
            try
            {
                return await _userDAL.GetById(id);
            }
            catch
            {

            }
            return null;
        }
    }
}
