using System;
using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Contract
{
    public interface IContractApplication
    {
        OperationResult Create(CreateContract command);
        OperationResult Edit(EditContract command);
        ComputingViewModel MandatoryHours(CreateContract command);
        EditContract GetDetails(long id);
        OperationResult Active(long id);
        OperationResult DeActive(long id);
        OperationResult Sign(long id);
        OperationResult UnSign(long id);
        List<ContractViweModel> Search(ContractSearchModel searchModel);
        List<ContractViweModel> SearchForextension(ContractSearchModel searchModel);
       
        bool CheckNextContractExist(long employeeId, DateTime startContract,DateTime endContract, long WorkshopId);
        bool CkeckBetween(long employeeId, DateTime EndOfContract, DateTime StartOfExtension, long WorkshopId);
        List<ContractViweModel> PrintAll(List<long> id);
    }
}
