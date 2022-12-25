using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.FileTiming;
using CompanyManagment.App.Contracts.FileTiming;


namespace CompanyManagment.EFCore.Repository
{
    public class FileTimingRepository : RepositoryBase<long, FileTiming>, IFileTimingRepository
    {
        private readonly CompanyContext _context;
        public FileTimingRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public FileTimingViewModel GetDetails(long id)
        {
            return _context.FileTimings.Select(x => new FileTimingViewModel
            {
                Id = x.id,
                Deadline = x.Deadline,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<EditFileTiming> Search(FileTimingSearchModel searchModel)
        {
            var query = _context.FileTimings.Select(x => new EditFileTiming
            {
                Id = x.id,
                Deadline = x.Deadline,
                Title = x.Title,
                Tips = x.Tips
            });

            return query.ToList();
        }
    }
}
