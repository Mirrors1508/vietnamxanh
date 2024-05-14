using Lib.Repositories.AccountRepo;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index(string url=null)
        {
            ViewBag.URL = url ?? "";
            return View();
        }
    }
}
