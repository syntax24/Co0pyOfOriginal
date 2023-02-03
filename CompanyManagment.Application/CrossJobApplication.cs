using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.CrossJobAgg;
using Company.Domain.EmployeeChildrenAgg;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobGuild;
using CompanyManagment.App.Contracts.EmployeeChildren;
using CompanyManagment.EFCore;
using CompanyManagment.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Application
{
    public class CrossJobApplication : ICrossJobApplication
    {
        private readonly ICrossJobRepository _crossJobRepository;
        private readonly CompanyContext _context;

        public CrossJobApplication(ICrossJobRepository crossJobRepository, CompanyContext context)
        {
            _crossJobRepository = crossJobRepository;
            _context = context;
        }

        public OperationResult Create(CreateCrossJob command)
        {
            var ress = _context.CrossJobs.SingleOrDefault(x => x.Title == command.Title);
            var opration = new OperationResult();
            var crossjob = new CrossJob(
                command.Title,
                command.SalaryRatioUnder,
                command.EquivalentRialUnder,
                command.SalaryRatioOver,
                command.EquivalentRialOver,
                command.CrossJobGuildId,
                command.parentRowId
                );

            _crossJobRepository.Create(crossjob);
            _crossJobRepository.SaveChanges();
            return opration.Succcedded();

        }

        public OperationResult Edit(EditCrossJob command)
        {
            var opration = new OperationResult();
            var crossJob = _crossJobRepository.Get(command.Id);
            if (crossJob == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            crossJob.Edit(
                command.Title,
                command.SalaryRatioUnder,
                command.EquivalentRialUnder,
                command.SalaryRatioOver,
                command.EquivalentRialOver,
                command.CrossJobGuildId,
                command.parentRowId
                );
            _crossJobRepository.SaveChanges();
            return opration.Succcedded();
        }

        public EditCrossJob GetDetails(long id)
        {
            return _crossJobRepository.GetDetails(id);
        }

        public List<CrossJobViewModel> GetCrossJob(long idGuild)
        {
            return _crossJobRepository.GetCrossJob(idGuild);
        }

        public List<CrossJobViewModel> Search(CrossJobSearchModel searchModel)
        {
            return _crossJobRepository.Search(searchModel);
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _crossJobRepository.Remove(id);
            _crossJobRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

        public OperationResult RemoveRange(long id)
        {
            var operation = new OperationResult();

            _crossJobRepository.RemoveRange(id);
            _crossJobRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

    }
}
