using _0_Framework.Domain;
using System.Collections.Generic;
using Company.Domain.TextManagerAgg;
using CompanyManagment.App.Contracts.TextManager;


namespace P_TextManager.Domin.TextManagerAgg
{
 public interface ITextManagerRepozitory:IRepository<long,EntityTextManager>
    {
        EditTextManager GetDetails( long id);
        List<TextManagerViewModel> Search(TextManagerSearchModel SearchModel);
        List<TextManagerViewModel> GetAllTextManager();
        List<long> GetRelation(long textManagerId);
        void ModuleTextManager(long textManagerId, long moduleId);
        void RemoveOldRelation(long textManagerId, long moduleId);
        List<string> GetlisAllModulet();
    }
}
