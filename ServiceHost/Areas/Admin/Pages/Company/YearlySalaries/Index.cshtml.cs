using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlysSalaryTitleAgg;
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

namespace ServiceHost.Areas.Admin.Pages.Company.YearlySalaries  
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public YearlySalarySearchModel SearchModel;
  
        public List<YearlySalaryViewModel> YearlySalaries;
        public List<YearlysalaryItemViewModel> YearlysalaryItemss;
        public List<string> TitleList { get; set; }



        private readonly IYearlySalaryApplication _yearlySalaryApplication;
        private readonly IYearlySalaryItemApplication _yearlySalaryItemApplication;
        private readonly IYearlySalaryRepository _yearlySalaryRepository;
        private readonly IYearlySalaryTitleRepository _yearlySalaryTitleRepository;

        public IndexModel(IYearlySalaryApplication yearlySalaryApplication, IYearlySalaryRepository yearlySalaryRepository, IYearlySalaryItemApplication yearlySalaryItemApplication, IYearlySalaryTitleApplication yearlySalaryTitleApplication, IYearlySalaryTitleRepository yearlySalaryTitleRepository)
        {
            _yearlySalaryApplication = yearlySalaryApplication;
            _yearlySalaryRepository = yearlySalaryRepository;
            _yearlySalaryItemApplication = yearlySalaryItemApplication;
            _yearlySalaryTitleRepository = yearlySalaryTitleRepository;
        }


        public void OnGet(YearlySalarySearchModel searchModel, YearlySalaryItemSearchModel searchModel2)
        {
         
            YearlySalaries = _yearlySalaryApplication.Search(searchModel);
            YearlysalaryItemss = _yearlySalaryItemApplication.Search(searchModel2);
            TitleList = _yearlySalaryTitleRepository.GetLast();
        }

    

        public IActionResult OnGetCreate()
        {
            var titles = _yearlySalaryTitleRepository.GetLast();

            var find = _yearlySalaryRepository.FindConnection();
            var command = new CreateYearlySalary();
            command.ConnectionId = find;
            command.TitleViewModels = titles;
            return Partial("./Create", command);
        }

     
        public  IActionResult OnPostCreate(CreateYearlySalary command)
        {
            bool valu0 = true;
          
            var opratioon = new OperationResult();
            var find = _yearlySalaryRepository.FindConnection();
            var children = command.CreateYearlyItemsList.Count(x => x.ItemName !=null);
           
            command.ConnectionId = find;
            for (int i = 0; i <= children - 1; i++)
            {
                if (command.CreateYearlyItemsList[i].ItemValue == null)
                {
                    valu0 = false;
                }
            }

         


            

            if (valu0 == true)
            {
                var result = _yearlySalaryApplication.Create(command);
                Thread.Sleep(1000);

                if (result.IsSuccedded)
                {

                    for (int i = 0; i <= children - 1; i++)
                    {
                        if (command.CreateYearlyItemsList[i].ItemName != null)
                        {

                            var item = new CreateYearlySalaryItem()
                            {
                                ItemName = command.CreateYearlyItemsList[i].ItemName,
                                ItemValue = command.CreateYearlyItemsList[i].ItemValue,
                                ValueType = command.CreateYearlyItemsList[i].ValueType,
                                ParentConnectionId = find


                            };
                            _yearlySalaryItemApplication.Create(item);

                        }

                    }

                   




                }





                return new JsonResult(result);
            }
            else
            {
                
                    var res2 = _yearlySalaryApplication.Err();
                    return new JsonResult(res2);
                
                
            }
           



        }





        public IActionResult OnGetEdit(long id)
        {
            var yearlySalary1 = _yearlySalaryApplication.GetDetails(id);
            yearlySalary1.EditYearlyItemsList = _yearlySalaryItemApplication.GetItems(yearlySalary1.ConnectionId);

            return Partial("Edit", yearlySalary1);
        }

     

        public JsonResult OnPostEdit(EditYearlySalary command)
        {

            if (ModelState.IsValid)
            {

            }

            var children = command.EditYearlyItemsList.Count();
            var result = _yearlySalaryApplication.Edit(command);

         
            Thread.Sleep(1000);
            if (result.IsSuccedded)
            {

                for (int i = 0; i <= children - 1; i++)
                {

                    var child = new EditYearlySalaryItem
                    {
                        ItemValue = command.EditYearlyItemsList[i].ItemValue,
                        ParentConnectionId = command.EditYearlyItemsList[i].ParentConnectionId,
                        ItemName = command.EditYearlyItemsList[i].ItemName,
                        ValueType = command.EditYearlyItemsList[i].ValueType,
                        YearlySalaryId = command.Id,
                        Id = command.EditYearlyItemsList[i].Id,
                       
                    };
                    _yearlySalaryItemApplication.Edit(child);

                }


               


            }
            return new JsonResult(result);
        }

        public IActionResult OnGetDetails(long id)
        {
            var emp = _yearlySalaryApplication.GetDetails(id);
           
            return Partial("Details", emp);
        }
   

    }
}
