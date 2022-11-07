using System.Collections.Generic;
using System.Linq;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Areas.Admin.Pages.Company.Contact2
{
    public class IndexModel : PageModel
    {
        public Contact2ViewModel searchModel;
        public List<Contact2ViewModel> Contacts;
        private CompanyContext db;

        private readonly IContactApplication2 _contactApplication2;

        public IndexModel(IContactApplication2 contactApplication2)
        {
            _contactApplication2 = contactApplication2;
         
        }
        public void OnGet(Contact2SearchModel searchModel)
        {
            Contacts = _contactApplication2.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
       public IActionResult OnPostCreate(CreateContact2 command)
        {
            var result = _contactApplication2.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var Contact = _contactApplication2.GetDetails(id);
            return Partial("Edit", Contact);
        }
        public JsonResult OnPostEdit(EditContact2 command)
        {
            //if (ModelState.IsValid)
            //{
            //}
            var result = _contactApplication2.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetDetails(long id)
        {
            var editJob = _contactApplication2.GetDetails(id);
            return Partial("Details", editJob);
        }

        public IActionResult OnGetSearch(string term)
        {
            var names = db.EntityContacts.Where(p => p.NameContact.Contains(term)).Select(p => p.NameContact).ToList();
            return new JsonResult(names);
        }

        public IActionResult OnGetContact(string term)
        {
            var names = _contactApplication2.GetAllContact().Where(p => p.NameContact.Contains(term)).Select(p => p.NameContact).ToList();
            return new JsonResult(names);
        }

    }
}
