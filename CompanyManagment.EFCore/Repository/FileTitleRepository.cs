using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.FileTitle;
using CompanyManagment.App.Contracts.FileTitle;


namespace CompanyManagment.EFCore.Repository
{
    public class FileTitleRepository : RepositoryBase<long, FileTitle>, IFileTitleRepository
    {
        private readonly CompanyContext _context;
        public FileTitleRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditFileTitle GetDetails(long id)
        {
            return _context.FileTitles.Select(x => new EditFileTitle
            {
                Id = x.id,
                Title = x.Title,
                Type = x.Type,
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
            var evidence = _context.FileTitles.Where(x => x.id == id).FirstOrDefault();

            Remove(evidence);
        }

        public List<EditFileTitle> Search(FileTitleSearchModel searchModel)
        {
            var query = _context.FileTitles.Select(x => new EditFileTitle
            {
                Id = x.id,
                Title = x.Title,
                Type = x.Type,
            });

            //TODO if

            if (searchModel.Type != null)
            {
                query = query.Where(x => x.Type == searchModel.Type);
            }

            if (searchModel.Id == 0 && searchModel.Title != null)
            {
                query = query.Where(x => x.Title == searchModel.Title);
            }
            
            if(searchModel.Id != 0)
            {
                query = query.Where(x => x.Id == searchModel.Id);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
