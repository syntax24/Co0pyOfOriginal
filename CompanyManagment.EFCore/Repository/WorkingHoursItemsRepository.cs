using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.WorkingHoursItemsAgg;
using CompanyManagment.App.Contracts.WorkingHoursItems;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class WorkingHoursItemsRepository : RepositoryBase<long, WorkingHoursItems>, IWorkingHoursItemsRepository
    {
        private readonly CompanyContext _context;


        public WorkingHoursItemsRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditWorkingHoursItems GetDetails(long id)
        {
            return _context.WorkingHoursItemsSet.Select(x => new EditWorkingHoursItems
                {
                    Id = x.id,
                    DayOfWork = x.DayOfWork,
                    ComplexStart = x.ComplexStart,
                    ComplexEnd = x.ComplexEnd,
                    Start1 = x.Start1,
                    End1 = x.End1,
                    RestTime = x.RestTime,
                    Start2 = x.Start2,
                    End2 = x.End2,
                    Start3 = x.Start3,
                    End3 = x.End3,
                    WorkingHoursId = x.WorkingHoursId


                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<WorkingHoursItemsViewModel> GetWorkingHoursItems()
        {
            return _context.WorkingHoursItemsSet.Select(x => new WorkingHoursItemsViewModel
                {
                    Id = x.id,
                    DayOfWork = x.DayOfWork,
                    ComplexStart = x.ComplexStart,
                    ComplexEnd = x.ComplexEnd,
                    Start1 = x.Start1,
                    End1 = x.End1,
                    RestTime = x.RestTime,
                    Start2 = x.Start2,
                    End2 = x.End2,
                    Start3 = x.Start3,
                    End3 = x.End3,
                    WorkingHoursId = x.WorkingHoursId
            })
                .ToList();
        }

        public WorkingHoursItemsViewModel GetByWorkingHoursId(long id)
        {
            return _context.WorkingHoursItemsSet.Select(x => new WorkingHoursItemsViewModel
                {
                    Id = x.id,
                    DayOfWork = x.DayOfWork,
                    ComplexStart = x.ComplexStart,
                    ComplexEnd = x.ComplexEnd,
                    Start1 = x.Start1,
                    End1 = x.End1,
                    RestTime = x.RestTime,
                    Start2 = x.Start2,
                    End2 = x.End2,
                    Start3 = x.Start3,
                    End3 = x.End3,
                    WorkingHoursId = x.WorkingHoursId
                })
                .SingleOrDefault(x => x.WorkingHoursId == id);
        }
    }
}
