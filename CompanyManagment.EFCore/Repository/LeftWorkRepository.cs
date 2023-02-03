using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.LeftWorkAgg;
using CompanyManagment.App.Contracts.LeftWork;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class LeftWorkRepository : RepositoryBase<long, LeftWork>, ILeftWorkRepository
    {
        private readonly CompanyContext _context;
        public LeftWorkRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditLeftWork GetDetails(long id)
        {
            return _context.LeftWorkList.Select(x => new EditLeftWork()
                {
                    Id = x.id,
                    LeftWorkDate = x.LeftWorkDate.ToFarsi(),
                    StartWorkDate = x.StartWorkDate.ToFarsi(),
                    EmployeeFullName = x.EmployeeFullName,
                    WorkshopName = x.WorkshopName,
                    WorkshopId = x.WorkshopId,
                    EmployeeId = x.EmployeeId



                })
                .FirstOrDefault(x => x.Id == id);
        }

        public string StartWork(long employeeId, long workshopId, string leftWork)
        {
            var checkExist = _context.LeftWorkList.Any(x => x.EmployeeId == employeeId && x.WorkshopId == workshopId);
            if (checkExist)
            {
                var LeftWorks = _context.LeftWorkList
                    .Where(x => x.EmployeeId == employeeId && x.WorkshopId == workshopId)
                    .OrderByDescending(x => x.LeftWorkDate).ToList();
                var lastLeft = LeftWorks.Select(x => x.LeftWorkDate).FirstOrDefault();

                var leftWorkNew = leftWork.ToGeorgianDateTime();

                var startWorkList = _context.Contracts
                    .Where(x => x.EmployeeId == employeeId && x.WorkshopIds == workshopId)
                    .Where(x => x.ContarctStart < leftWorkNew && x.ContarctStart > lastLeft)
                    .OrderBy(x => x.ContarctStart).ToList();

                var startWorkDate = startWorkList.Select(x => x.ContarctStart).FirstOrDefault();
                var result = startWorkDate.ToFarsi();
                return result;

            }
            else
            {
                var leftWorkNew = leftWork.ToGeorgianDateTime();

                var startWorkList = _context.Contracts
                    .Where(x => x.EmployeeId == employeeId && x.WorkshopIds == workshopId)
                    .Where(x => x.ContarctStart < leftWorkNew)
                    .OrderBy(x => x.ContarctStart).ToList();

                var startWorkDate = startWorkList.Select(x => x.ContarctStart).FirstOrDefault();
                var result = startWorkDate.ToFarsi();
                return result;
            }
        }


        public List<LeftWorkViewModel> search(LeftWorkSearchModel searchModel)
        {
            var query = _context.LeftWorkList.Select(x => new LeftWorkViewModel()
            {
                Id = x.id,
                LeftWorkDate = x.LeftWorkDate.ToFarsi(),
                StartWorkDate = x.StartWorkDate.ToFarsi(),
                LeftWorkDateGr = x.LeftWorkDate,
                StartWorkDateGr = x.StartWorkDate,
                EmployeeFullName = x.EmployeeFullName,
                WorkshopName = x.WorkshopName,
                WorkshopId = x.WorkshopId,
                EmployeeId = x.EmployeeId

            });
            if (searchModel.WorkshopId != 0 && searchModel.EmployeeId !=0)
                query = query.Where(x => x.WorkshopId == searchModel.WorkshopId && x.EmployeeId == searchModel.EmployeeId);
            if (searchModel.EmployeeId != 0)
                query = query.Where(x => x.EmployeeId == searchModel.EmployeeId);
            return query.OrderByDescending(x => x.StartWorkDateGr).ToList();
        }

        public OperationResult RemoveLeftWork(long id)
        {
            var op = new OperationResult();
           var item = _context.LeftWorkList.FirstOrDefault(x=>x.id==id);
           if(item !=null)
            _context.LeftWorkList.Remove(item);
           
           _context.SaveChanges();
           return op.Succcedded();
        }
    }
}
