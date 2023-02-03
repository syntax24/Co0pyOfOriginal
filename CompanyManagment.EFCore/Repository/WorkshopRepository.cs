using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using AccountMangement.Infrastructure.EFCore;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAccountAgg;
using Company.Domain.WorkshopAgg;
using Company.Domain.WorkshopEmployerAgg;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.LeftWork;
using CompanyManagment.App.Contracts.Workshop;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class WorkshopRepository : RepositoryBase<long, Workshop>, IWorkshopRepository
    {
        private readonly CompanyContext _context;
        private readonly AccountContext _accountContext;
        private readonly IAuthHelper _authHelper;
        public WorkshopRepository(CompanyContext context, AccountContext accountContext, IAuthHelper authHelper) : base(context)
        {
            _context = context;
            _accountContext = accountContext;
            _authHelper = authHelper;
        }


        public List<WorkshopViewModel> GetWorkshop()
        {
            return _context.Workshops.Where(x => x.IsActive == true)
                .Select(x => new WorkshopViewModel
                {
                    Id = x.id,
                    WorkshopFullName = x.WorkshopFullName,
                    WorkshopName = x.WorkshopName,
                    InsuranceCode = x.InsuranceCode,
                    //EmployerName = x.Employer.LName,
                    ContractTerm = x.ContractTerm,
                    //EmployerId = x.EmployerId,
                    TypeOfOwnership = x.TypeOfOwnership,
                    ArchiveCode = x.ArchiveCode,
                    AgentName = x.AgentName,
                    AgentPhone = x.AgentPhone,
                    State = x.State,
                    City = x.City,
                    Address = x.Address,
                    TypeOfInsuranceSend = x.TypeOfInsuranceSend,
                    TypeOfContract = x.TypeOfContract,
                    IsActiveString = x.IsActiveString


                }).ToList();
        }

        public List<WorkshopViewModel> GetWorkshopAccount()
        {
            var AcountID = _authHelper.CurrentAccountId();
            var workshopAcounts = _context.WorkshopAccounts.Where(x => x.AccountId == AcountID)
                .Select(x => x.WorkshopId).ToList();
            //var res = (e => contractData.Contains(e.Id))


            var work = _context.Workshops
                .Include(x => x.WorkshopEmployers).ThenInclude(x=>x.Employer).ToList();

              var result =work
              .Select(x => new WorkshopViewModel
                {
                    Id = x.id,
                    WorkshopFullName = x.WorkshopFullName,
                    WorkshopName = x.WorkshopName,
                    InsuranceCode = x.InsuranceCode,
                    //EmployerName = x.Employer.LName,
                    ContractTerm = x.ContractTerm,
                    //EmployerId = x.EmployerId,
                    TypeOfOwnership = x.TypeOfOwnership,
                    ArchiveCode = x.ArchiveCode,
                    AgentName = x.AgentName,
                    AgentPhone = x.AgentPhone,
                    State = x.State,
                    City = x.City,
                    Address = x.Address,
                    TypeOfInsuranceSend = x.TypeOfInsuranceSend,
                    TypeOfContract = x.TypeOfContract,
                    IsActiveString = x.IsActiveString,
                    EmpList = x.WorkshopEmployers.Select(y => new EmployerViewModel() { Id = y.EmployerId, FullName = y.Employer.FullName }).ToList()

              }).Where(e => workshopAcounts.Contains(e.Id)).ToList();
              return result.Where(x => x.IsActiveString == "true").ToList();
        }

        public EditWorkshop GetDetails(long id)
        {
            
            return _context.Workshops.Select(x => new EditWorkshop
            {
                Id = x.id,
                WorkshopName = x.WorkshopName,
                WorkshopSureName = x.WorkshopSureName,
                WorkshopFullName = x.WorkshopFullName,
                InsuranceCode = x.InsuranceCode,
                //EmployerId = x.EmployerId,
                TypeOfOwnership = x.TypeOfOwnership,
                ArchiveCode = x.ArchiveCode,
                AgentName = x.AgentName,
                AgentPhone = x.AgentPhone,
                State = x.State,
                City = x.City,
                Address = x.Address,
                TypeOfInsuranceSend = x.TypeOfInsuranceSend,
                TypeOfContract = x.TypeOfContract,
                ContractTerm = x.ContractTerm

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<long> GetRelation(long workshopid)
        {

            var emp = _context.WorkshopEmployers.Where(x => x.WorkshopId == workshopid)
                .Select(x => x.EmployerId).ToList();
            return emp;

        }

        public List<long> GetWorkshopAccountRelation(long workshopid)
        {
            var emp = _context.WorkshopAccounts.Where(x => x.WorkshopId == workshopid)
                .Select(x => x.AccountId).ToList();
            return emp;
        }

        public void WorkshopAccounts(List<long> AccountIds, long workshopId)
        {
            var admins = _accountContext.Accounts.Where(x => x.RoleName == "مدیر سیستم").Select(x => x.id).ToList();

            if (AccountIds.Count > 0)
            {
                var accIds = new List<long>();
                foreach (var item in AccountIds)
                {
                    var test = _accountContext.Accounts.Where(x => x.id == item && x.RoleName != "مدیر سیستم")
                        .Select(x => x.id).SingleOrDefault();
                    if (test > 0)
                        accIds.Add(test);
                }
                var listOfAccountId = accIds.Concat(admins).ToList();

                foreach (var item in listOfAccountId)
                {
                    _context.WorkshopAccounts.Add(new WorkshopAccount()
                    {

                        WorkshopId = workshopId,
                        AccountId = item

                    });
                    _context.SaveChanges();
                }
            }
            else
            {
                foreach (var item in admins)
                {
                    _context.WorkshopAccounts.Add(new WorkshopAccount()
                    {

                        WorkshopId = workshopId,
                        AccountId = item

                    });
                    _context.SaveChanges();
                }
            }

        }

        public WorkshopViewModel GetWorkshopInfo(long id)
        {
            var employees = new List<EmployeeViewModel>();
            var left = _context.LeftWorkList.Where(x => x.WorkshopId == id).Select(x => x.EmployeeId).ToList();
            if (left.Count > 0)
            {
                employees = _context.Employees.Select(e => new EmployeeViewModel()
                {
                    Id = e.id,
                    EmployeeFullName = e.FName + " " + e.LName

                }).Where(p => left.Contains(p.Id)).ToList();
            }
             
            var work = _context.Workshops
                .Include(x => x.WorkshopEmployers).ThenInclude(x => x.Employer).FirstOrDefault(x=>x.id == id);
            var results = new WorkshopViewModel
            {
                Id = work.id,
                WorkshopFullName = work.WorkshopFullName,
                WorkshopName = work.WorkshopName,
                InsuranceCode = work.InsuranceCode,
                //EmployerName = x.Employer.LName,
                ContractTerm = work.ContractTerm,
                //EmployerId = x.EmployerId,
                TypeOfOwnership = work.TypeOfOwnership,
                ArchiveCode = work.ArchiveCode,
                AgentName = work.AgentName,
                AgentPhone = work.AgentPhone,
                State = work.State,
                City = work.City,
                Address = work.Address,
                TypeOfInsuranceSend = work.TypeOfInsuranceSend,
                TypeOfContract = work.TypeOfContract,
                IsActiveString = work.IsActiveString,
                EmpList = work.WorkshopEmployers.Select(y => new EmployerViewModel()
                {
                    Id = y.EmployerId, FullName = y.Employer.FullName, NationalId = y.Employer.NationalId,
                    Nationalcode = y.Employer.Nationalcode, IdNumber = y.Employer.IdNumber, RegisterId = y.Employer.RegisterId
                }).ToList(),
               EmployeeList = employees,
            };
           
            return results;
        }

        public void RemoveOldRelation(long workshopid)
        {
            _context.WorkshopEmployers.Where(x => x.WorkshopId == workshopid).ToList()
                .ForEach(x => _context.WorkshopEmployers.Remove(x));
            _context.WorkshopAccounts.Where(x => x.WorkshopId == workshopid).ToList()
                .ForEach(x => _context.WorkshopAccounts.Remove(x));
        }

        public List<WorkshopViewModel> Search(WorkshopSearchModel searchModel)
        {
            var emp = _context.WorkshopEmployers.Where(x => x.EmployerId == searchModel.EmployerId)
                .Select(x => x.WorkshopId).ToList();
            var query = _context.Workshops.Include(x => x.WorkshopEmployers)
                .Select(x => new WorkshopViewModel
                {
                    Id = x.id,
                    WorkshopName = x.WorkshopName,
                    InsuranceCode = x.InsuranceCode,
                    //EmployerName = x.WorkshopEmployers.
                    WorkshopSureName = x.WorkshopSureName,
                    WorkshopFullName = x.WorkshopFullName,
                    TypeOfOwnership = x.TypeOfOwnership,
                    ArchiveCode = x.ArchiveCode,
                    AgentName = x.AgentName,
                    AgentPhone = x.AgentPhone,
                    State = x.State,
                    City = x.City,
                    Address = x.Address,
                    TypeOfInsuranceSend = x.TypeOfInsuranceSend,
                    TypeOfContract = x.TypeOfContract,
                    IsActiveString = x.IsActiveString,
                    ContractTerm = x.ContractTerm


                });
            if (!string.IsNullOrWhiteSpace(searchModel.WorkshopName))
                query = query.Where(x => x.WorkshopName.Contains(searchModel.WorkshopName));
            if (!string.IsNullOrWhiteSpace(searchModel.InsuranceCode))
                query = query.Where(x => x.InsuranceCode.Contains(searchModel.InsuranceCode));
            if (!string.IsNullOrWhiteSpace(searchModel.ArchiveCode))
                query = query.Where(x => x.ArchiveCode == searchModel.ArchiveCode);
            if (!string.IsNullOrWhiteSpace(searchModel.WorkshopName))
                query = query.Where(x => x.WorkshopName.Contains(searchModel.WorkshopName));
            if (!string.IsNullOrWhiteSpace(searchModel.ContractTerm))
                query = query.Where(x => x.ContractTerm == searchModel.ContractTerm);
            if (!string.IsNullOrWhiteSpace(searchModel.TypeOfContract))
                query = query.Where(x => x.TypeOfContract == searchModel.TypeOfContract);
            if (searchModel.EmployerId != 0)
            {

                query = query.Where(x => emp.Contains(x.Id));

            }




            if (searchModel.IsActiveString == null)
            {
                query = query.Where(x => x.IsActiveString == "true");
            }

            if (searchModel.IsActiveString == "false")
            {
                query = query.Where(x => x.IsActiveString == "false");
            }
            else if (searchModel.IsActiveString == "both")
            {
                query = query.Where(x => x.IsActiveString == "false" || x.IsActiveString == "true");
            }

            return query.OrderByDescending(x => x.Id).ToList();

        }

        public void EmployerWorkshop(long workshopid, long employerid)
        {
            _context.WorkshopEmployers.Add(new WorkshopEmployer
            {

                WorkshopId = workshopid,
                EmployerId = employerid

            });
            _context.SaveChanges();
        }
    }
}
