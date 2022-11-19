using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.ChapterAgg;
using CompanyManagment.App.Contracts.Chapter;

namespace CompanyManagment.EFCore.Repository
{
    public class ChapterRepository : RepositoryBase<long, EntityChapter>, IChapterRepozitory
    {
        private readonly CompanyContext _context;
        public ChapterRepository(CompanyContext context):base(context)
        {
            _context = context;
        }

        public List<ChapterViewModel> GetAllChapter()
        {
            return _context.EntityChapters.Select(x => new ChapterViewModel
            {
                Id = x.id,
                Chapter = x.Chapter,
                Subtitle_Id = x.Subtitle_Id,
                IsActiveString=x.IsActiveString

            }).ToList();
        }

        public EditChapter GetDetails(long id)
        {

            return _context.EntityChapters.Select(x => new EditChapter
            {
                Id = x.id,
                Chapter =x.Chapter,
                Subtitle_Id = x.Subtitle_Id,
            }).FirstOrDefault(x => x.Id == id);
        }


        public List<ChapterViewModel> Search(ChapterSearchModel SearchModel)
        {
            var query = _context.EntityChapters.Select(x => new ChapterViewModel
            {
                Id = x.id,
                Chapter = x.Chapter,
                Subtitle_Id = x.Subtitle_Id,
                IsActiveString = x.IsActiveString,
                Subtitle =x.EntitySubtitle.Subtitle,
                OriginalTitle=x.EntitySubtitle.EntityOriginalTitle.Title

            });

       
            if (SearchModel.Subtitle_Id!=0)
                query = query.Where(x => x.Subtitle_Id==SearchModel.Subtitle_Id);
            if (!string.IsNullOrWhiteSpace(SearchModel.Chapter))
                query = query.Where(x => x.Chapter.Contains(SearchModel.Chapter));

            return query.OrderByDescending(x => x.Id).ToList();
        }

      

    }
}
