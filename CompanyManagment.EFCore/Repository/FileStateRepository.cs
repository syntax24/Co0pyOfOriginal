using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.FileState;
using CompanyManagment.App.Contracts.FileState;


namespace CompanyManagment.EFCore.Repository
{
    public class FileStateRepository : RepositoryBase<long, FileState>, IFileStateRepository
    {
        private readonly CompanyContext _context;
        public FileStateRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public FileStateViewModel GetDetails(long id)
        {
            return _context.FileStates.Select(x => new FileStateViewModel
            {
                Id = x.id,
                FileTiming_Id = x.FileTiming_Id,
                State = x.State,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        //public void Remove(long id)
        //{
        //    var evidence = _context.FileStates.Where(x => x.id == id).FirstOrDefault();

        //    Remove(evidence);
        //}

        public List<EditFileState> Search(FileStateSearchModel searchModel)
        {
            var query = _context.FileStates.Select(x => new EditFileState
            {
                Id = x.id,
                FileTiming_Id = x.FileTiming_Id,
                State = x.State,
                Title = x.Title,
                Deadline = _context.FileTimings.Where(y => y.id == x.FileTiming_Id).FirstOrDefault().Deadline
            });

            //TODO if

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
