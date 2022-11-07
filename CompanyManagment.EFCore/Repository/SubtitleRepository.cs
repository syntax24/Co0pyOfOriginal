using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.SubtitleAgg;
using CompanyManagment.App.Contracts.Subtitle;

namespace CompanyManagment.EFCore.Repository
{
    public class SubtitleRepository : RepositoryBase<long, EntitySubtitle>, ISubtitleRepozitory
    {
        private readonly CompanyContext _context;
        public SubtitleRepository(CompanyContext context):base(context)
        {
            _context = context;
        }

        public List<SubtitleViewModel> GetAllSubtitle()
        {
            return _context.EntitySubtitles.Select(x => new SubtitleViewModel
            {
                Id = x.id,
                Subtitle = x.Subtitle,
                OriginalTitle_Id = x.OriginalTitle_Id

            }).ToList();
        }

        public EditSubtitle GetDetails(long id)
        {

            return _context.EntitySubtitles.Select(x => new EditSubtitle
            {
                Id = x.id,
                Subtitle =x.Subtitle,
                OriginalTitle_Id=x.OriginalTitle_Id
              }).FirstOrDefault(x => x.Id == id);
        }


        public List<SubtitleViewModel> Search(SubtitleSearchModel SearchModel)
        {
            var query = _context.EntitySubtitles.Select(x => new SubtitleViewModel
            {
                Id = x.id,
                Subtitle = x.Subtitle,
                OriginalTitle_Id = x.OriginalTitle_Id,
                OriginalTitle =x.EntityOriginalTitle.Title
            });

       
            if (SearchModel.OriginalTitle_Id!=0)
                query = query.Where(x => x.OriginalTitle_Id==SearchModel.OriginalTitle_Id);
            if (!string.IsNullOrWhiteSpace(SearchModel.Subtitle))
                query = query.Where(x => x.Subtitle.Contains(SearchModel.Subtitle));

            return query.OrderByDescending(x => x.Id).ToList();
        }

      

    }
}
