using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.EmployeeChildrenAgg;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.EFCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Application
{
    public class EmployeeChildrenApplication : IEmployeeChildrenApplication
    {
        private readonly IEmployeeChildrenRepository _employeeChildrenRepository;
        private readonly CompanyContext _context;

        public EmployeeChildrenApplication(IEmployeeChildrenRepository employeeChildrenRepository, CompanyContext context)
        {
            _employeeChildrenRepository = employeeChildrenRepository;
            _context = context;
        }


        public OperationResult Create(CreateEmployeChildren command)
        {
            var ress = _context.Employees.SingleOrDefault(x => x.NationalCode == command.ParentNationalCode);
            var parentid = ress.id;
            var dateOfBirth = command.DateOfBirth.ToGeorgianDateTime();
            var opration = new OperationResult();
            var children = new EmployeeChildren(command.FName, dateOfBirth, command.ParentNationalCode,
                parentid);

            _employeeChildrenRepository.Create(children);
            _employeeChildrenRepository.SaveChanges();
            return opration.Succcedded();

        }

        public OperationResult Edit(EditEmployeeChildren command)
        {
            var dateOfBirth = command.DateOfBirth.ToGeorgianDateTime();
            var opration = new OperationResult();
            var employeChildren = _employeeChildrenRepository.Get(command.Id);
            if (employeChildren == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (command.IsRemoved)
            {
                var remove = _context.EmployeeChildrenSet.FirstOrDefault(x => x.id == command.Id);
                if (remove != null)
                {
                    _context.EmployeeChildrenSet.Remove(remove);
                    _context.SaveChanges();
                }
            }
            employeChildren.Edit(command.FName, dateOfBirth, command.ParentNationalCode,
                command.EmployeeId);
            _employeeChildrenRepository.SaveChanges();
            return opration.Succcedded();
        }

        public EditEmployeeChildren GetDetails(long id)
        {
            return _employeeChildrenRepository.GetDetails(id);
        }

      

        public List<EmployeeChildernViewModel> GetChildren(string parentalCode)
        {
            return _employeeChildrenRepository.GetChildren(parentalCode);
        }

        public List<EmployeeChildernViewModel> Search(EmployeeChildrenSearchModel searchModel)
        {
            return _employeeChildrenRepository.Search(searchModel);
        }
    }
}
