using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.YearlySalaryAgg;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.App.Contracts.YearlySalaryItems;
using CompanyManagment.App.Contracts.YearlySalaryTitles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace ServiceHost.Areas.Admin.Pages.Company.YearlySalaryTitles 
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public TitleSearchModel SearchModel;
  
        public List<TitleViewModel> TitleViewModels;
 



        private readonly IYearlySalaryTitleApplication _yearlySalaryTitleApplication;
      

        public IndexModel(IYearlySalaryTitleApplication yearlySalaryTitleApplication)
        {
            _yearlySalaryTitleApplication = yearlySalaryTitleApplication;
        }


        public void OnGet(TitleSearchModel searchModel)
        {

            TitleViewModels = _yearlySalaryTitleApplication.Search(searchModel);
          

        }

    

        public IActionResult OnGetCreate()
        {
         

        
            return Partial("./Create");
        }

     
        public  IActionResult OnPostCreate(CreateTitle command)
        {

            var result = _yearlySalaryTitleApplication.Create(command);
            return new JsonResult(result);
        }





        public IActionResult OnGetEdit(long id)
        {
            var employer = _yearlySalaryTitleApplication.GetDetails(id);
           

            return Partial("Edit", employer);
        }

     

        public JsonResult OnPostEdit(EditTitle command)
        {

            if (ModelState.IsValid)
            {

            }
           

            var result = _yearlySalaryTitleApplication.Edit(command);
     
       

 
            return new JsonResult(result);



        }

        public IActionResult OnGetDetails(long id)
        {
            var emp = _yearlySalaryTitleApplication.GetDetails(id);
           
            return Partial("Details", emp);
        }
   

    }
}
