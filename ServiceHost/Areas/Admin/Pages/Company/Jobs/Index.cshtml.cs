using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Admin.Pages.Company.Jobs    
{
    [Authorize]
    public class IndexModel : PageModel
    {
  
        public JobSearchModel searchModel;
     
        public List<JobViewModel> Jobs;
        
      
      
        private readonly IJobApplication _jobApplication;

        public IndexModel(IJobApplication jobApplication)
        {
            _jobApplication = jobApplication;
        }


        public void OnGet(JobSearchModel searchModel)
        {
         
            Jobs = _jobApplication.Search(searchModel);

        }

    

        public IActionResult OnGetCreate()
        {
  
            return Partial("./Create");
        }


        public IActionResult OnPostCreate(CreateJob command)
        {
            var result = _jobApplication.Create(command);
            return new JsonResult(result);



        }

      



        public IActionResult OnGetEdit(long id)
        {
            var job = _jobApplication.GetDetails(id);


            return Partial("Edit", job);
        }

 

        public JsonResult OnPostEdit(EditJob command)
        {

            if (ModelState.IsValid)
            {

            }


            var result = _jobApplication.Edit(command);

            return new JsonResult(result);


        }
 
        public IActionResult OnGetDetails(long id)
        {
            var editJob = _jobApplication.GetDetails(id);

            return Partial("Details", editJob);
        }
    


    }

}
