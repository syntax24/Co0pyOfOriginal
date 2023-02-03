using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
      
        public string Mess { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public Login login;
        public AccountViewModel Search;
        private readonly ILogger<IndexModel> _logger;
        private readonly IAccountApplication _accountApplication;
        public IndexModel(ILogger<IndexModel> logger, IAccountApplication accountApplication)
        {
            _logger = logger;
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            
        }

      
        public IActionResult OnPostLogin(Login command)
        {
           
           var result= _accountApplication.Login(command);
           if (result.IsSuccedded)
               return RedirectToPage("/Admin");


            ModelState.AddModelError("Username", "اطلاعات وارد شده اشتباه است");
            TempData["h"] = "n";
            Mess = result.Message;
            return null;

        }

        public IActionResult OnPostEnter(Login command)
        {
            var result = _accountApplication.Login(command);
            if (result.IsSuccedded)
                return Redirect("/Admin");

            //ModelState.AddModelError("Username", "اطلاعات وارد شده اشتباه است");
       
            Mess = result.Message;
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}
