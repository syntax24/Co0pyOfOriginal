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


        public List<ChapterViewModel> Search(ChapterSearchModel searchModel)
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

       
            
            if (!string.IsNullOrWhiteSpace(searchModel.Chapter))
                query = query.Where(x => x.Chapter.Contains(searchModel.Chapter));
            if (searchModel.OriginalTitle_Id != 0)
            {
                query = query.Where(x => x.OriginalTitle_Id == searchModel.OriginalTitle_Id);
                if (searchModel.Subtitle_Id != 0)
                {

                    query = query.Where(x => x.Subtitle_Id == searchModel.Subtitle_Id);

                }
                if (searchModel.IsActiveString == "false")
                    query = query.Where(x => x.IsActiveString == "false");
                if (searchModel.IsActiveString == "true")
                    query = query.Where(x => x.IsActiveString == "true");
                if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                    query = query.Where(x => x.IsActiveString == "true");
            }
            else
            {
                if (searchModel.IsActiveString == "false")
                    query = query.Where(x => x.IsActiveString == "false");
                if (searchModel.IsActiveString == "true")
                    query = query.Where(x => x.IsActiveString == "true");
                if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                    query = query.Where(x => x.IsActiveString == "true");
            }

           



            return query.OrderByDescending(x => x.Id).ToList();
        }

      

    }
}
