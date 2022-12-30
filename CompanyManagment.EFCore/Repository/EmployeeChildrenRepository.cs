using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.EmployeeChildrenAgg;
using CompanyManagment.App.Contracts.EmployeeChildren;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class EmployeeChildrenRepository : RepositoryBase<long, EmployeeChildren>, IEmployeeChildrenRepository
    {
        private readonly CompanyContext _context;

        public EmployeeChildrenRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<EmployeeChildernViewModel> GetChildren(string parentalCode)
        {
            return _context.EmployeeChildrenSet.Select(x => new EmployeeChildernViewModel
            {
                Id = x.id,

                FName = x.FName,
                DateOfBirth = x.DateOfBirth.ToFarsi(),
                ParentNationalCode = x.ParentNationalCode,
                IsRemoved = false,
           

            }).Where(x => x.ParentNationalCode == parentalCode).ToList();
        }

      

        public EditEmployeeChildren GetDetails(long id)
        {
            return _context.EmployeeChildrenSet.Select(x => new EditEmployeeChildren
            {
                Id = x.id,
                FName = x.FName,
                DateOfBirth = x.DateOfBirth.ToFarsi(),
                ParentNationalCode = x.ParentNationalCode,
                EmployeeId = x.EmployeeId,
            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<EmployeeChildernViewModel> Search(EmployeeChildrenSearchModel searchModel)
        {
            var query = _context.EmployeeChildrenSet.Select(x => new EmployeeChildernViewModel
            {
                Id = x.id,
                FName = x.FName,
                DateOfBirth = x.DateOfBirth.ToFarsi(),
                ParentNationalCode = x.ParentNationalCode,
                EmployeeId = x.EmployeeId,
            });
            if (!string.IsNullOrWhiteSpace(searchModel.FName))
                query = query.Where(x => x.FName.Contains(searchModel.FName));



            return query.OrderByDescending(x => x.Id).ToList();
        }


    }
}
