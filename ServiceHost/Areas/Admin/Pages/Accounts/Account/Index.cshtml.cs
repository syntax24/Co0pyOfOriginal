using System.Collections.Generic;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Accounts.Account
{
    [Authorize]
    public class IndexModel : PageModel
    {
       
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;
        public List<RoleViewModel> Roless;
        private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IAccountApplication accountApplication, IRoleApplication roleApplication)
        {
            _accountApplication = accountApplication;
            _roleApplication = roleApplication;
        }


        public void OnGet(AccountSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            Accounts = _accountApplication.Search(searchModel);
            Roless = _roleApplication.List();
        }

    

        public IActionResult OnGetCreate()
        {
            var command = new CreateAccount
            {
                Roles = _roleApplication.List()
            };
            return Partial("./Create", command);
        }

    

        public IActionResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetCreateRole()
        {
            var command = new CreateRole();

            return Partial("./CreateRole", command);
        }

        public IActionResult OnPostCreateRole(CreateRole command)
        {
            var result = _roleApplication.Create(command);
            return new JsonResult(result);

        }

     
        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetails(id);
            account.Roles = _roleApplication.List();
            return Partial("Edit", account);
        }

      


        public JsonResult OnPostEdit(EditAccount command)
        {

            var result = _accountApplication.Edit(command);
            return new JsonResult(result);

        }

        public IActionResult OnGetEditRole(long id)
        {
            var role = _roleApplication.GetDetails(id);
            var rol = new List<int>();
            foreach (var item in role.MappedPermissions)
            {
                rol.Add(item.Code);
            }

            role.Permissions = rol;
            return Partial("EditRole", role);
        }

        public JsonResult OnPostEditRole(EditRole command)
        {

            var result = _roleApplication.Edit(command);
            return new JsonResult(result);

        }
        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword {Id = id};
            return Partial("ChangePassword", command);
        }



        public JsonResult OnPostChangePassword(ChangePassword command)
        {

            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);

        }


    }
}
