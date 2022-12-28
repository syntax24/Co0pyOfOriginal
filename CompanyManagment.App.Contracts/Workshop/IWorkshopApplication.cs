using System.Collections.Generic;
using _0_Framework.Application;

namespace CompanyManagment.App.Contracts.Workshop
{
    public interface IWorkshopApplication
    {
        OperationResult Create(CreateWorkshop command);

        OperationResult Edit(EditWorkshop command);

        EditWorkshop GetDetails(long id);
        List<WorkshopViewModel> GetWorkshop();
        List<WorkshopViewModel> GetWorkshopAccount();
      

        List<WorkshopViewModel> Search(WorkshopSearchModel searchModel);

        OperationResult Active(long id);
        OperationResult DeActive(long id);

        WorkshopViewModel GetWorkshopInfo(long id);
        OperationResult Err();

        OperationResult ExistErr();




    }
}
