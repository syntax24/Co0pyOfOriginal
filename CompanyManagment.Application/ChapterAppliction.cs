using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.ChapterAgg;
using CompanyManagment.App.Contracts.Chapter;

namespace CompanyManagment.Application
{
    public class ChapterAppliction : IChapterApplication
    {
        private readonly IChapterRepozitory _ChapterRepozitory;

        public ChapterAppliction(IChapterRepozitory ChapterRepozitory)
        {
            _ChapterRepozitory = ChapterRepozitory;
        }

        
        public OperationResult Create(CreateChapter command)
        {
            var oprtaion = new OperationResult();
            if (_ChapterRepozitory.Exists(x => x.Chapter == command.Chapter ))
                return oprtaion.Failed("  این متن برای بخش قبلا ثبت شده است");

            if (string.IsNullOrWhiteSpace(command.Chapter))
                return oprtaion.Failed("ثبت  بخش الزامیست");
            if (command.Subtitle_Id<=0)
                return oprtaion.Failed("انتخاب  عنوان الزامیست");

            var Chapter = new EntityChapter(command.Chapter, command.Subtitle_Id);

            _ChapterRepozitory.Create(Chapter);
            _ChapterRepozitory.SaveChanges();
            return oprtaion.Succcedded(); 
        }

        public OperationResult Edit(EditChapter command)
        {
            var oprtaion = new OperationResult();

            var ChapterEdit = _ChapterRepozitory.Get(command.Id);

            if (_ChapterRepozitory.Exists(x => x.Chapter == command.Chapter))
                return oprtaion.Failed("  این متن برای بخش قبلا ثبت شده است");
            if (string.IsNullOrWhiteSpace(command.Chapter))
                return oprtaion.Failed("ثبت  بخش الزامیست");

            if (string.IsNullOrWhiteSpace(command.Subtitle_Id.ToString()))
                return oprtaion.Failed("انتخاب  عنوان الزامیست");

            ChapterEdit.Edit( command.Chapter,  command.Subtitle_Id);

            _ChapterRepozitory.SaveChanges();
            return oprtaion.Succcedded();
        }

       
        public EditChapter GetDetails( long id)
        {
            return _ChapterRepozitory.GetDetails(id);
        }

        public List<ChapterViewModel> Search(ChapterSearchModel SearchModel)
        {
            return _ChapterRepozitory.Search(SearchModel);
        }

        public List<ChapterViewModel> GetAllChapter()
        {
            return _ChapterRepozitory.GetAllChapter();

        }

     
    }
}
