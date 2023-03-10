using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.OriginalTitleAgg;
using CompanyManagment.App.Contracts.OriginalTitle;


namespace CompanyManagment.EFCore.Repository
{
    public class OriginalTitleRepository : RepositoryBase<long, EntityOriginalTitle>, IOriginalTitleRepozitory
    {
        private readonly CompanyContext _context;
        public OriginalTitleRepository(CompanyContext context):base(context)
        {
            _context = context;
        }
        public List<OriginalTitleViewModel> GetAllOriginalTitle()
        {
            return _context.EntityOriginalTitles.Select(x => new OriginalTitleViewModel
            {
                Id = x.id,
                Title = x.Title,
                IsActiveString = x.IsActiveString,
            }).ToList();
        }

        public EditOriginalTitle GetDetails(long id)
        {
            return _context.EntityOriginalTitles.Select(x => new EditOriginalTitle
            {
                Id = x.id,
                Title = x.Title,
              
            }).FirstOrDefault(x => x.Id == id);
        }
        List<OriginalTitleViewModel> IOriginalTitleRepozitory.Search(OriginalTitleSearchModel searchModel)
        {
            var query = _context.EntityOriginalTitles.Select(x => new OriginalTitleViewModel
            {
                Id = x.id,
                Title = x.Title,
                IsActiveString = x.IsActiveString,
            });



            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                query = query.Where(x => x.IsActiveString == "true");
            if (searchModel.IsActiveString == "false")
                query = query.Where(x => x.IsActiveString == "false");
            if (searchModel.IsActiveString == "true")
                query = query.Where(x => x.IsActiveString == "true");
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
