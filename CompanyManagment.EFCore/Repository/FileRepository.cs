using System.Collections.Generic;
using System.Linq;
using _0_Framework.InfraStructure;
using _0_Framework.Application;
using Company.Domain.File1;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.File1;

namespace CompanyManagment.EFCore.Repository
{
    public class FileRepository : RepositoryBase<long, Company.Domain.File1.File1>, IFileRepository
    {
        private readonly CompanyContext _context;
        public FileRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditFile GetDetails(long id)
        {
            return _context.Files.Select(x => new EditFile
            {
                Id = x.id,
                ArchiveNo = x.ArchiveNo,
                ClientVisitDate = x.ClientVisitDate.ToFarsi(),
                ProceederReference = x.ProceederReference,
                Reqester = x.Reqester,
                Summoned = x.Summoned,
                Client = x.Client,
                FileClass = x.FileClass,
                HasMandate = x.HasMandate,
                Description = x.Description,
                Status = x.Status
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<FileViewModel> Search(FileSearchModel searchModel)
        {
            var query = _context.Files.Select(x => new FileViewModel
            {
                Id = x.id,
                ArchiveNo = x.ArchiveNo,
                ClientVisitDate = x.ClientVisitDate.ToFarsi(),
                ProceederReference = x.ProceederReference,
                Reqester = x.Reqester,
                Summoned = x.Summoned,
                Client = x.Client,
                FileClass = x.FileClass,
                HasMandate = x.HasMandate,
                Description = x.Description,
                Status = x.Status
            });

            if (searchModel.Id != 0)
            {
                query = query.Where(x => x.Id == searchModel.Id);
            }

            //TODO if
            if (searchModel.ArchiveNo != null && int.Parse(searchModel.ArchiveNo) != -1)
            {
                query = query.Where(x => x.ArchiveNo == int.Parse(searchModel.ArchiveNo));
            }

            if(!string.IsNullOrEmpty(searchModel.FileClass) && searchModel.FileClass != "-1")
            {
                query = query.Where(x => x.FileClass.Contains(searchModel.FileClass));
            }

            if(searchModel.UserId != 0)
            {
                query = query.Where(x => x.Reqester == searchModel.UserId || x.Summoned == searchModel.UserId);
            }
            
            if(searchModel.Status != 0)
            {
                query = query.Where(x => x.Status == searchModel.Status);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
     
        public long FindLastArchiveNumber()
        {
            var checkExist = _context.Files.Any();
            long ArchiveNo = 0;
            if (checkExist)
            {
                ArchiveNo = _context.Files.OrderByDescending(x => x.ArchiveNo).Select(x => x.ArchiveNo)
                    .FirstOrDefault();

            }

            return ArchiveNo;
        }

        public string GetEmployeeFullNameById(long id)
        {
            var result = _context.Employees.Where(x => x.id == id).Select(x => new EmployeeViewModel()
            {
                EmployeeFullName = x.FName + " " + x.LName

            }).FirstOrDefault();
            return result.EmployeeFullName;
        }

        public string GetEmployerFullNameById(long id)
        {
            var result = _context.Employers.Where(x=>x.id == id).Select(x => new EmployerViewModel()
            {
                FullName = x.FullName

            }).FirstOrDefault();
            return result.FullName;
        }

        public List<EmployeeViewModel> GetAllEmploees()
        {
            //var query = _context.Files.Select(x => x.Reqester).ToList();
            //query.AddRange(_context.Files.Select(x => x.Summoned).ToList());

            //var query_1 = _context.Employees.Where(x=>x.IsActive).Select(x => new EmployeeViewModel()
            //{
            //    Id = x.id,
            //    EmployeeFullName = x.FName + " " + x.LName,

            //}).Where(x => query.Contains(x.Id));

            //return query_1.ToList();

            return _context.Employees.Where(x => x.IsActive).Select(x => new EmployeeViewModel()
            {
                Id = x.id,
                EmployeeFullName = x.FName + " " + x.LName,


            }).ToList();

        }

        public List<EmployerViewModel> GetAllEmployers()
        {
            return _context.Employers.Where(x => x.IsActive).Select(x => new EmployerViewModel()
            {
                Id = x.id,
                FullName = x.FullName,


            }).ToList();
        }
    }
}
