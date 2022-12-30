using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.WorkingHoursAgg;
using CompanyManagment.App.Contracts.WorkingHours;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class WorkingHoursRepository : RepositoryBase<long, WorkingHours>, IWorkingHoursRepository
    {
        private readonly CompanyContext _context;


        public WorkingHoursRepository(CompanyContext context) : base(context)
        {
            _context = context;
            
        }

        public EditWorkingHours GetDetails(long id)
        {
            return _context.WorkingHoursSet.Select(x => new EditWorkingHours
                {
                    Id = x.id,
                    ContractId = x.ContractId,
                    ContractNo = x.ContractNo,
                    NumberOfFriday = x.NumberOfFriday,
                    NumberOfWorkingDays = x.NumberOfWorkingDays,
                    ShiftWork = x.ShiftWork,
                    TotalHoursesH = x.TotalHoursesH,
                    TotalHoursesM = x.TotalHoursesM,
                    OverNightWorkH = x.OverTimeWorkH,
                    OverNightWorkM = x.OverNightWorkM,
                    OverTimeWorkH = x.OverTimeWorkH,
                    OverTimeWorkM = x.OverTimeWorkM,
                    WeeklyWorkingTime = x.WeeklyWorkingTime,

                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<WorkingHoursViewModel> GetWorkingHours()
        {
            return _context.WorkingHoursSet.Select(x => new WorkingHoursViewModel
                {
                    Id = x.id,
                    ContractId = x.ContractId,
                    ContractNo = x.ContractNo,
                    NumberOfFriday = x.NumberOfFriday,
                    NumberOfWorkingDays = x.NumberOfWorkingDays,
                    ShiftWork = x.ShiftWork,
                    TotalHoursesH = x.TotalHoursesH,
                    TotalHoursesM = x.TotalHoursesM,
                    OverNightWorkH = x.OverTimeWorkH,
                    OverNightWorkM = x.OverNightWorkM,
                    OverTimeWorkH = x.OverTimeWorkH,
                    OverTimeWorkM = x.OverTimeWorkM,
                    WeeklyWorkingTime = x.WeeklyWorkingTime,
                })
                .ToList();
        }

        public WorkingHoursViewModel GetByContractId(long id)
        {
            return _context.WorkingHoursSet.Select(x => new WorkingHoursViewModel
            {
                Id = x.id,
                ContractId = x.ContractId,
                ContractNo = x.ContractNo,
                NumberOfFriday = x.NumberOfFriday,
                NumberOfWorkingDays = x.NumberOfWorkingDays,
                ShiftWork = x.ShiftWork,
                TotalHoursesH = x.TotalHoursesH,
                TotalHoursesM = x.TotalHoursesM,
                OverNightWorkH = x.OverTimeWorkH,
                OverNightWorkM = x.OverNightWorkM,
                OverTimeWorkH = x.OverTimeWorkH,
                OverTimeWorkM = x.OverTimeWorkM,
                WeeklyWorkingTime = x.WeeklyWorkingTime,
            })
                .SingleOrDefault(x => x.ContractId == id);
        }
    }
}
