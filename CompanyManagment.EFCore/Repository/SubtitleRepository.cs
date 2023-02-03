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
                IsActiveString = x.IsActiveString,
                OriginalTitle_Id = x.OriginalTitle_Id

            }).ToList();
        }

        public EditSubtitle GetDetails(long id)
        {

            return _context.EntitySubtitles.Select(x => new EditSubtitle
            {
                Id = x.id,
                Subtitle =x.Subtitle,
                OriginalTitle_Id =x.OriginalTitle_Id
              }).FirstOrDefault(x => x.Id == id);
        }


        public List<SubtitleViewModel> Search(SubtitleSearchModel searchModel)
        {
            var query = _context.EntitySubtitles.Select(x => new SubtitleViewModel
            {
                Id = x.id,
                Subtitle = x.Subtitle,
                OriginalTitle_Id = x.OriginalTitle_Id,
                IsActiveString = x.IsActiveString,
                OriginalTitle =x.EntityOriginalTitle.Title
            });

          
            if (!string.IsNullOrWhiteSpace(searchModel.Subtitle))
                query = query.Where(x => x.Subtitle.Contains(searchModel.Subtitle));

            if (searchModel.OriginalTitle_Id != 0)
            {
                query = query.Where(x => x.OriginalTitle_Id == searchModel.OriginalTitle_Id);
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
