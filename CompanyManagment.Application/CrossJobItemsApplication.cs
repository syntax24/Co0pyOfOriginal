using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.CrossJobAgg;
using Company.Domain.CrossJobItemsAgg;
using CompanyManagment.App.Contracts.CrossJobItems;
using CompanyManagment.EFCore;
using CompanyManagment.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.Application
{
    public class CrossJobItemsApplication : ICrossJobItemsApplication
    {
        private readonly ICrossJobItemsRepository _crossJobItemsRepository;
        private readonly CompanyContext _context;

        public CrossJobItemsApplication(ICrossJobItemsRepository crossJobItemsRepository, CompanyContext context)
        {
            _crossJobItemsRepository = crossJobItemsRepository;
            _context = context;
        }

        public OperationResult Create(CreateCrossJobItems command)
        {
            var opration = new OperationResult();
            var crossjob = new CrossJobItems(
                command.crossJobId,
                command.jobId
                );

            _crossJobItemsRepository.Create(crossjob);
            _crossJobItemsRepository.SaveChanges();
            return opration.Succcedded();

        }

        //public OperationResult Edit(EditCrossJobItems command)
        //{
        //    var opration = new OperationResult();
        //    var crossJob = _crossJobRepository.Get(command.Id);
        //    if (crossJob == null)
        //        return opration.Failed("رکورد مورد نظر یافت نشد");

        //    crossJob.Edit(
        //        command.SalaryRatioUnder,
        //        command.EquivalentRialUnder,
        //        command.SalaryRatioOver,
        //        command.EquivalentRialOver,
        //        command.CrossJobGuildId,
        //        command.parentRowId,
        //        command.jobId
        //        );
        //    _crossJobRepository.SaveChanges();
        //    return opration.Succcedded();
        //}

        public CrossJobItemsViewModel GetDetails(long id)
        {
            return _crossJobItemsRepository.GetDetails(id);
        }

        public List<CrossJobItemsViewModel> GetCrossJobItems(long idGuild)
        {
            return _crossJobItemsRepository.GetCrossJobItems(idGuild);
        }

        public List<CrossJobItemsViewModel> Search(CrossJobItemsSearchModel searchModel)
        {
            return _crossJobItemsRepository.Search(searchModel);
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _crossJobItemsRepository.Remove(id);
            _crossJobItemsRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

        public OperationResult RemoveRange(long idrossJob)
        {
            var operation = new OperationResult();

            _crossJobItemsRepository.RemoveRange(idrossJob);
            _crossJobItemsRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

    }
}
