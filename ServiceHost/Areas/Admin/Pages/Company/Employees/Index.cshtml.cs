using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
    
namespace ServiceHost.Areas.Admin.Pages.Company.Employees
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public EmployeeSearchModel SearchModel;
        public List<CreateEmployeChildren> ChildrenList;
        public List<EmployeeViewModel> Employees;

       
      
        private readonly IEmployeeApplication _employeeApplication;
        private readonly IEmployeeChildrenApplication _employeeChildrenApplication;




        public IndexModel(IEmployeeApplication employeeApplication, IEmployeeChildrenApplication employeeChildrenApplication)
        {
            _employeeApplication = employeeApplication;
            _employeeChildrenApplication = employeeChildrenApplication;
        }

        public void OnGet(EmployeeSearchModel searchModel)
        {
           
            Employees = _employeeApplication.Search(searchModel);

        }

    

        public IActionResult OnGetCreate()
        {
           
            
            return Partial("./Create");
        }

     
        public  IActionResult OnPostCreate(CreateEmployee command)
        {

            var children = command.CreateEmployeChildrenList.Count(x => x.DateOfBirth !=null);
            command.NumberOfChildren = children.ToString();
            var result = _employeeApplication.Create(command);
            Thread.Sleep(1000);
            
            if (result.IsSuccedded)
            {

                for (int i = 0; i <= children-1; i++)
                {
                    if (command.CreateEmployeChildrenList[i].DateOfBirth != null)
                    {

                        var child = new CreateEmployeChildren
                        {
                            ParentNationalCode = command.NationalCode,
                            DateOfBirth = command.CreateEmployeChildrenList[i].DateOfBirth,
                            FName = command.CreateEmployeChildrenList[i].FName
                        };
                        _employeeChildrenApplication.Create(child);

                    }
                }
                    
            

            }

            
            return new JsonResult(result);

 

        }





        public IActionResult OnGetEdit(long id)
        {
            var employee = _employeeApplication.GetDetails(id);
            employee.EditEmployeChildrenList = _employeeChildrenApplication.GetChildren(employee.NationalCode);

            return Partial("Edit", employee);
        }

     

        public JsonResult OnPostEdit(EditEmployee command)
        {
            int childrenEdit = 0;
            int children = 0;
            if (ModelState.IsValid)
            {

            }

            if (command.CreateEmployeChildrenList!=null)
            {
                children = command.CreateEmployeChildrenList.Count(x => x.DateOfBirth != null);
            }
            
            if (command.EditEmployeChildrenList != null)
            {
                childrenEdit = command.EditEmployeChildrenList.Count(x => x.DateOfBirth != null);
            }
             
            //if (children > 0)
            //{
            //    var oldChildrenNumber = Convert.ToInt32(command.NumberOfChildren);
            //    var sumChildren = oldChildrenNumber + children;
            //    command.NumberOfChildren = sumChildren.ToString();
            //}



            var result = _employeeApplication.Edit(command);
            Thread.Sleep(1000);
            if (result.IsSuccedded)
            {

                for (int i = 0; i <= childrenEdit-1; i++)
                {
                    if (command.EditEmployeChildrenList[i].DateOfBirth != null)
                    {

                        var child = new EditEmployeeChildren
                        {
                            ParentNationalCode = command.NationalCode,
                            DateOfBirth = command.EditEmployeChildrenList[i].DateOfBirth,
                            FName = command.EditEmployeChildrenList[i].FName,
                            EmployeeId = command.Id,
                            Id = command.EditEmployeChildrenList[i].Id,
                            IsRemoved = command.EditEmployeChildrenList[i].IsRemoved
                        };
                        _employeeChildrenApplication.Edit(child);

                    }
                }

                for (int i = 0; i <= children - 1; i++)
                {
                    if (command.CreateEmployeChildrenList[i].DateOfBirth != null)
                    {

                        var child = new CreateEmployeChildren
                        {
                            ParentNationalCode = command.NationalCode,
                            DateOfBirth = command.CreateEmployeChildrenList[i].DateOfBirth,
                            FName = command.CreateEmployeChildrenList[i].FName
                        };
                        _employeeChildrenApplication.Create(child);

                    }
                }

            }

            var childrenCunt = _employeeChildrenApplication.GetChildren(command.NationalCode).Count;
            command.NumberOfChildren = childrenCunt.ToString();
             _employeeApplication.Edit(command);
            return new JsonResult(result);



        }

        public IActionResult OnGetDetails(long id)
        {
            var emp = _employeeApplication.GetDetails(id);
            emp.CreateEmployeChildrenList = _employeeChildrenApplication.GetChildren(emp.NationalCode);
           
            return Partial("Details", emp);
        }
   

        public IActionResult OnGetDeActive(long id)
        {
          var result =  _employeeApplication.DeActive(id);
          if (result.IsSuccedded)
              return RedirectToPage("./Index");
          Message = result.Message;
          return RedirectToPage("./Index");
        }

        public IActionResult OnGetIsActive(long id)
        {
            var result = _employeeApplication.Active(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
