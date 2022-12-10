using _0_Framework.Application;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Bill;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.App.Contracts.TextManager
{
    public interface IBillApplication
    {
        OperationResult Create(CreateBill command);
        OperationResult Edit(EditBill command);
        EditBill GetDetails( long id);
        List<BillViewModel> Search(BillSearchModel SearchModel);
        //List<BillViewModel> GetAllTextManager();

        OperationResult Active(long id);
        OperationResult DeActive(long id);

    }
}
