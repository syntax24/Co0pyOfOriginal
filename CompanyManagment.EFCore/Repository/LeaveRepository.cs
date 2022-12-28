using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.LeaveAgg;
using CompanyManagment.App.Contracts.Leave;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class LeaveRepository : RepositoryBase<long, Leave>, ILeaveRepository
    {
        private readonly CompanyContext _context;
        public LeaveRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditLeave GetDetails(long id)
        {
            return _context.LeaveList.Select(x => new EditLeave()
                {
                    Id = x.id,
                    StartLeave = x.StartLeave.ToFarsi(),
                    EndLeave = x.EndLeave.ToFarsi(),
                    WorkshopId = x.WorkshopId,
                    EmployeeId = x.EmployeeId,
                    LeaveHourses = x.LeaveHourses,
                    PaidLeaveType = x.PaidLeaveType,
                    LeaveType = x.LeaveType,
                    EmployeeFullName = x.EmployeeFullName,
                    WorkshopName = x.WorkshopName,
                   



                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<LeaveViewModel> search(LeaveSearchModel searchModel)
        {
            var query = _context.LeaveList.Select(x => new LeaveViewModel()
            {
                Id = x.id,
                StartLeave = x.StartLeave.ToFarsi(),
                EndLeave = x.EndLeave.ToFarsi(),
                StartLeaveGr = x.StartLeave,
                EndLeaveGr = x.EndLeave,
                WorkshopId = x.WorkshopId,
                EmployeeId = x.EmployeeId,
                LeaveHourses = x.LeaveHourses,
                PaidLeaveType = x.PaidLeaveType,
                LeaveType = x.LeaveType,
                EmployeeFullName = x.EmployeeFullName,
                WorkshopName = x.WorkshopName,
      

            });
            if (searchModel.WorkshopId != 0 && searchModel.EmployeeId != 0)
                query = query.Where(x => x.WorkshopId == searchModel.WorkshopId && x.EmployeeId == searchModel.EmployeeId && x.LeaveType == searchModel.LeaveType);
            return query.OrderByDescending(x => x.Id).ToList();
        }

        public OperationResult RemoveLeave(long id)
        {
            var op = new OperationResult();
            var item = _context.LeaveList.FirstOrDefault(x => x.id == id);
            if (item != null)
                _context.LeaveList.Remove(item);

            _context.SaveChanges();
            return op.Succcedded();
        }

        public bool CheckContractExist(DateTime myDate, long employeeId, long workshopId)
        {
            var result = _context.Contracts.Any(x => x.ContarctStart <= myDate
                                                     && x.ContractEnd >= myDate && x.EmployeeId == employeeId &&
                                                     x.WorkshopIds == workshopId && x.IsActiveString=="true");
            return result;
        }
    }
}
