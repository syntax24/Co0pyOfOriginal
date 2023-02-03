using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Admin.Pages.Company.Workshops
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public WorkshopSearchModel SearchModel;
      
        public List<WorkshopViewModel> Workshops;

 
        public SelectList Employers;
        
      
        private readonly IWorkshopApplication _workshopApplication;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IEmployerApplication _EmployerApplication;
        private readonly IEmployerRepository _EmployerRepository;
        private readonly IAccountRepository _accountRepository;
        

        public IndexModel(IWorkshopApplication workshopApplication, IEmployerApplication employerApplication, IEmployerRepository employerRepository, IWorkshopRepository workshopRepository, IAccountRepository accountRepository)
        {

            _workshopApplication = workshopApplication;
            _EmployerApplication = employerApplication;
            _EmployerRepository = employerRepository;
            _workshopRepository = workshopRepository;
            _accountRepository = accountRepository;
        }

        public void OnGet(WorkshopSearchModel searchModel)
        {

            Employers =
                new SelectList(_EmployerApplication.GetEmployers(), "Id", "LName");
            Workshops = _workshopApplication.Search(searchModel);

        }

    

        public IActionResult OnGetCreate()
        {
            var command = new CreateWorkshop
            {
                Employers = _EmployerApplication.GetEmployers(),
                AccountsList = _accountRepository.GetAccounts()
                
            };
         
            var res = _workshopApplication.GetWorkshop();
            var checkOk = res.Any();
            int item = 0;

            var codes = new List<int>();
            foreach (var i in res)
            {
               
                
                    string bb = string.Empty;

                    if (i.ArchiveCode != null)
                    {
                        for (int x = 0; x < i.ArchiveCode.Length; x++)
                        {
                            if (char.IsDigit(i.ArchiveCode[x]))
                                bb += i.ArchiveCode[x];
                        }

                        if (bb.Length > 0)
                        {
                            int convert = int.Parse(bb);
                            codes.Add(convert);
                        }
                    }
               
               
                 
                
            }
            if (checkOk)
            {
                item = codes.Max();
            }
           
          
            
            int sum = item + 1;
            string newcode = sum.ToString();
            command.ArchiveCode = newcode;
            return Partial("./Create", command);
        }


        public IActionResult OnPostCreate(CreateWorkshop command)
        {
            var res = _workshopApplication.GetWorkshop();
            bool checkNumber = false;
            bool checkExist = false;
      
            string a = command.ArchiveCode;
            string bb = string.Empty;
            int convert2 = 0;
            if (!string.IsNullOrWhiteSpace(a))
            {
                for (int x = 0; x < a.Length; x++)
                {
                    if (char.IsDigit(a[x]))
                        bb += a[x];
                }

                if (bb.Length > 0)
                {
                    checkNumber = true;
                     convert2 = int.Parse(bb);
                }
                else
                {
                    checkNumber = false;

                }
            }
            else
            {
                checkNumber = true;
             
            }

            var codes = new List<int>();
            foreach (var i in res)
            {

                string b2 = string.Empty;

                if (i.ArchiveCode != null)
                {
                    for (int x = 0; x < i.ArchiveCode.Length; x++)
                    {
                        if (char.IsDigit(i.ArchiveCode[x]))
                            b2 += i.ArchiveCode[x];
                    }

                    if (b2.Length > 0)
                    {
                        int convert = int.Parse(b2);
                        codes.Add(convert);
                    }
                }


            }
         
            foreach (var item in codes)
            {
                if (item == convert2)
                    checkExist = true;
            }

            if (checkNumber && !checkExist)
            {

              
                var result = _workshopApplication.Create(command);
                return new JsonResult(result);
            }
            else if(!checkNumber && !checkExist)
            {
                var res2 = _workshopApplication.Err();
                return new JsonResult(res2);
            }
            else
            {
                var res3 = _workshopApplication.ExistErr();
                return new JsonResult(res3);
            }

 

        }

      



        public IActionResult OnGetEdit(long id)
        {
            var workshop = _workshopApplication.GetDetails(id);
            workshop.Employers = _EmployerApplication.GetEmployers();
            workshop.AccountsList = _accountRepository.GetAccounts();
            workshop.EmployerIdList = _workshopRepository.GetRelation(id);
            workshop.AccountIdsList = _workshopRepository.GetWorkshopAccountRelation(id);
          


            Message = workshop.ArchiveCode;
            return Partial("Edit", workshop);
        }

 

        public JsonResult OnPostEdit(EditWorkshop command)
        {

            if (ModelState.IsValid)
            {

            }



            var workshop = _workshopApplication.GetDetails(command.Id);
            var lastNumber = workshop.ArchiveCode;
            var res = _workshopApplication.GetWorkshop();
            bool checkNumber = false;
            bool checkExist = false;
            var pration = new OperationResult();
            string a = command.ArchiveCode;
            string bb = string.Empty;
            int convert2 = 0;
            if (!string.IsNullOrWhiteSpace(a))
            {
                for (int x = 0; x < a.Length; x++)
                {
                    if (char.IsDigit(a[x]))
                        bb += a[x];
                }

                if (bb.Length > 0)
                {
                    checkNumber = true;
                    convert2 = int.Parse(bb);
                }
                else
                {
                    checkNumber = false;

                }
            }
            else
            {
                checkNumber = true;

            }

            var codes = new List<int>();
            foreach (var i in res)
            {

                string b2 = string.Empty;

                if (i.ArchiveCode != null && i.ArchiveCode != lastNumber)
                {
                    for (int x = 0; x < i.ArchiveCode.Length; x++)
                    {
                        if (char.IsDigit(i.ArchiveCode[x]))
                            b2 += i.ArchiveCode[x];
                    }

                    if (b2.Length > 0)
                    {
                        int convert = int.Parse(b2);
                        codes.Add(convert);
                    }
                }


            }
           
            foreach (var item in codes)
            {
                if (item == convert2)
                    checkExist = true;
            }

            if (checkNumber && !checkExist)
            {
                //var EmpoyersSelected = _EmployerRepository.Get(command.EmployerId);
                //if (EmpoyersSelected.EmployerNo == null)
                //{
                //    EmpoyersSelected.EditEmployerNo(command.ArchiveCode);
                //}

                var result = _workshopApplication.Edit(command);
             
                return new JsonResult(result);
            }
            else if (!checkNumber && !checkExist)
            {
                var res2 = _workshopApplication.Err();
                return new JsonResult(res2);
            }
            else
            {
                var res3 = _workshopApplication.ExistErr();
                return new JsonResult(res3);
            }




        



        }
 
        public IActionResult OnGetDetails(long id)
        {
            var wrk = _workshopApplication.GetDetails(id);
            wrk.Employers = _EmployerApplication.GetEmployers();
            wrk.EmployerIdList = _workshopRepository.GetRelation(id);
            return Partial("Details", wrk);
        }
    

        public IActionResult OnGetDeActive(long id)
        {
        

            var result =  _workshopApplication.DeActive(id);
          
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetIsActive(long id)
        {


            var result = _workshopApplication.Active(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }

}
