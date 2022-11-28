using _0_Framework.Application;
using CompanyManagment.App.Contracts.Subtitle;
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.Chapter
{
    public interface IChapterApplication
    {
        OperationResult Create(CreateChapter command);
        OperationResult Edit(EditChapter command);
        EditChapter GetDetails( long id);
        List<ChapterViewModel> Search(ChapterSearchModel SearchModel);
        List<ChapterViewModel> GetAllChapter();
        OperationResult Active(long id);
        OperationResult DeActive(long id);
    }
}
