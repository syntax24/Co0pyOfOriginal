using System.Collections.Generic;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Company.Employers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public EmployerSearchModel SearchModel;
     
        public List<EmployerViewModel> Employers;

        public SelectList ContactingParties;
      
        private readonly IEmployerApplication _employerApplication;
        private readonly IPersonalContractingPartyApp _personalContractingPartyApp;
        private readonly IPersonalContractingPartyRepository _personalContractingPartyRepository2;


        public IndexModel(IEmployerApplication employerApplication, IPersonalContractingPartyApp personalContractingPartyApp, IPersonalContractingPartyRepository personalContractingPartyRepository)
        {

            _employerApplication = employerApplication;
            _personalContractingPartyApp = personalContractingPartyApp;
            _personalContractingPartyRepository2 = personalContractingPartyRepository;


        }

        public void OnGet(EmployerSearchModel searchModel)
        {
            ContactingParties =
                new SelectList(_personalContractingPartyApp.GetPersonalContractingParties(), "id", "LName");
            Employers = _employerApplication.Search(searchModel);

        }

    

        public IActionResult OnGetCreate()
        {
            var command = new CreateEmployer
            {
               ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties()
            };
            
            return Partial("./Create", command);
        }

        public IActionResult OnGetInsertLegal()
        {
            var command = new CreateEmployer
            {
                ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties()
            };
            return Partial("./InsertLegal", command);
        }
        public IActionResult OnPostCreate(CreateEmployer command)
        {
           
            //var personalContractingParty = _personalContractingPartyRepository2.Get(command.ContractingPartyId);
           
            //personalContractingParty.Edit2( "test"); 

            var result = _employerApplication.Create(command);
            return new JsonResult(result);

 

        }


        public IActionResult OnPostInsertLegal(CreateEmployer command)
        {


            var result2 = _employerApplication.CreateLegals(command);
            return new JsonResult(result2);






        }


        public IActionResult OnGetEdit(long id)
        {
            var employer = _employerApplication.GetDetails(id);
            employer.ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties();
         
            return Partial("Edit", employer);
        }

        public IActionResult OnGetLegalEdit(long id)
        {
            var employerlegaly = _employerApplication.GetDetails(id);
            employerlegaly.ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties();
            return Partial("LegalEdit", employerlegaly);
        }

        public JsonResult OnPostEdit(EditEmployer command)
        {

            if (ModelState.IsValid)
            {

            }



            var result = _employerApplication.Edit(command);
            return new JsonResult(result);



        }
        public JsonResult OnPostLegalEdit(EditEmployer command)
        {

            if (ModelState.IsValid)
            {

            }



            var result = _employerApplication.EditLegal(command);
            return new JsonResult(result);



        }
        public IActionResult OnGetDetails(long id)
        {
            var emp = _employerApplication.GetDetails(id);
            emp.ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties();
            return Partial("Details", emp);
        }
        public IActionResult OnGetLegalDetails(long id)
        {
            var legaldetails = _employerApplication.GetDetails(id);
            legaldetails.ContractingParties = _personalContractingPartyApp.GetPersonalContractingParties();
            return Partial("LegalDetails", legaldetails);
        }

        public IActionResult OnGetDeActive(long id)
        {
          var result =  _employerApplication.DeActive(id);
          if (result.IsSuccedded)
              return RedirectToPage("./Index");
          Message = result.Message;
          return RedirectToPage("./Index");
        }

        public IActionResult OnGetIsActive(long id)
        {
            var result = _employerApplication.Active(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
