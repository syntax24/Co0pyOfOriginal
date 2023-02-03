using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.MandantoryHours;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Admin.Pages.Company.MandatoryHours      
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public MandatoryHoursSearchModel searchModel;
     
        public List<MandatoryHoursViewModel> Mandatoires;
        
      
      
        private readonly IMandatoryHoursApplication _mandatoryHoursApplication;

        public IndexModel(IMandatoryHoursApplication mandatoryHoursApplication)
        {
            _mandatoryHoursApplication = mandatoryHoursApplication;
        }


        public void OnGet(MandatoryHoursSearchModel searchModel)
        {
         
            Mandatoires = _mandatoryHoursApplication.Search(searchModel);

        }

    

        public IActionResult OnGetCreate()
        {
  
            return Partial("./Create");
        }


        public IActionResult OnPostCreate(CreateMandatoryHours command)
        {
            var result = _mandatoryHoursApplication.Create(command);
            return new JsonResult(result);



        }

      



        public IActionResult OnGetEdit(long id)
        {
            var mandatory = _mandatoryHoursApplication.GetDetails(id);


            return Partial("Edit", mandatory);
        }

 

        public JsonResult OnPostEdit(EditMandatoryHours command)
        {

            if (ModelState.IsValid)
            {

            }



            var result = _mandatoryHoursApplication.Edit(command);




            return new JsonResult(result);





        }
 
        public IActionResult OnGetDetails(long id)
        {
            var mandatoryDedails = _mandatoryHoursApplication.GetDetails(id);

            return Partial("Details", mandatoryDedails);
        }
    


    }

}
