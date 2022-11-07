using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.Contract;

namespace Company.Domain.ContractAgg
{
    public interface IContractRepository : IRepository<long, Contract>
    {
        EditContract GetDetails(long id);

        List<ContractViweModel> Search(ContractSearchModel searchModel);
        List<ContractViweModel> SearchForextension(ContractSearchModel searchModel);
        List<ContractViweModel> PrintAll(List<long> id);
        IQueryable<WorkshopEmployerViewModel> GetWorkshopEmployer();
        long FindPersonnelCode(long workshopId,long employeeId);

        string ContractStartCheck(DateTime cstart,long employeeId);
        bool CheckNextContractExist(long employeeId, DateTime startContract, DateTime endContract, long WorkshopId);
        bool CkeckBetween(long employeeId, DateTime EndOfContract, DateTime StartOfExtension, long WorkshopId);
    }
}
