using Lib.DAL.PortgreSQL;
using Lib.Entities.Models;
using Microsoft.Extensions.Configuration;

namespace Lib.Repositories.AccountRepo
{
    public class AccountRepository : IAccountRepository
    {
       
        private readonly AccountDAL _accountDAL;
        private readonly IConfiguration _configuration;

        public AccountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _accountDAL = new AccountDAL(configuration["DbConnection:PortgreSQL"]);
        }
        public async Task<Account?> GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                return await _accountDAL.GetByUsernameAndPassword(username, password);
            }
            catch
            {

            }
            return null;
        }
    }
}
