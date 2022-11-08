using _0_Framework.Domain;
using System.Collections.Generic;
using CompanyManagment.App.Contracts.Chapter;

namespace Company.Domain.ChapterAgg
{
 public interface IChapterRepozitory : IRepository<long,EntityChapter>
    {
        EditChapter GetDetails( long id);
        //DeleteChapter GetDelete(long id);
        List<ChapterViewModel> Search(ChapterSearchModel SearchModel);
        List<ChapterViewModel> GetAllChapter();
      }
}
