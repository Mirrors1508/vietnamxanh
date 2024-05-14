using Lib.Entities.Models;

namespace Lib.Entities.AccountWebModels
{
    public class AccountAuthenticationModel :Account
    {
        public string remote_ip { get; set; }
    }
}
