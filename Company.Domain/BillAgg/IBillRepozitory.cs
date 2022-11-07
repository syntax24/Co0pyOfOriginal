using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Bill;


namespace Company.Domain.BillAgg
{
 public interface IBillRepozitory : IRepository<long, EntityBill>
    {
        EditBill GetDetails( long id);
        List<BillViewModel> Search(BillSearchModel SearchModel);
        List<BillViewModel> GetAllBill();
        //List<long> GetRelation(long textManagerId);
        //void ModuleTextManager(long textManagerId, long moduleId);
        //void RemoveOldRelation(long textManagerId);
        //List<string> GetlisAllModulet();
    }
}
