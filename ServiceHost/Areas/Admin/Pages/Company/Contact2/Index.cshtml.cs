using System.Collections.Generic;
using System.Linq;
using CompanyManagment.App.Contracts.Contact2;
using CompanyManagment.App.Contracts.Contract;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ServiceHost.Areas.Admin.Pages.Company.Contact2
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public Contact2ViewModel searchModel;
        public List<Contact2ViewModel> Contacts;
        private CompanyContext db;
        public string cation2Search = "false";

        private readonly IContactApplication2 _contactApplication2;

        public IndexModel(IContactApplication2 contactApplication2)
        {
            _contactApplication2 = contactApplication2;
         
        }
        public void OnGet(Contact2SearchModel searchModel)
        {
            Contacts = _contactApplication2.Search(searchModel);
    
            if (Contacts != null)
            {
              

                if (!string.IsNullOrEmpty(searchModel.NameContact))
                {
                    cation2Search = "true";
                }
            }
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







        public IActionResult OnGetDeActive(long id, string url)
        {
           var result = _contactApplication2.DeActive(id);
            if (result.IsSuccedded)
                return Redirect(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
        public IActionResult OnGetIsActive(long id, string url)
        {
           var result = _contactApplication2.Active(id);
            if (result.IsSuccedded)
                return Redirect(url);
            Message = result.Message;
            return RedirectToPage(url);
        }
      
        public IActionResult OnGetGroupDeActive(List<long> ids)
        {
            foreach (var item in ids)
            {
                var result = _contactApplication2.DeActive(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupReActive(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contactApplication2.Active(item);
            }


            //if (result.IsSuccedded)
            //    return RedirectToPage("./Index");

            return RedirectToPage("./Index");
        }


        public IActionResult OnGetGroupSign(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contactApplication2.Sign(item);
            }
            return RedirectToPage("./Index");

        }
        public IActionResult OnGetGroupUnSign(List<long> ids)
        {

            foreach (var item in ids)
            {
                var result = _contactApplication2.UnSign(item);
            }
            return RedirectToPage("./Index");

        }

    }
}
