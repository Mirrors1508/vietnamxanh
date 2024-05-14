using Lib.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Repositories.AccountRepo
{
    public interface IAccountRepository
    {
        Task<Account?> GetByUsernameAndPassword(string username, string password);
    }
}
