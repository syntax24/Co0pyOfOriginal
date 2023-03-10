using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.empolyerAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Workshop;

namespace Company.Domain.WorkshopAgg
{
    public interface IWorkshopRepository : IRepository<long, Workshop>
    {
        List<WorkshopViewModel> GetWorkshop();
        List<WorkshopViewModel> GetWorkshopAccount();
        EditWorkshop GetDetails(long id);
        List<long> GetRelation(long workshopid);
        List<long> GetWorkshopAccountRelation(long workshopid);
        void EmployerWorkshop(long workshopid, long employerid);
        void WorkshopAccounts(List<long> AccountIds, long workshopId);
        WorkshopViewModel GetWorkshopInfo(long id);
        void RemoveOldRelation(long workshopid);
        List<WorkshopViewModel> Search(WorkshopSearchModel searchModel);
    }
}
