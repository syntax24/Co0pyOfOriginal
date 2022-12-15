using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.FileAlert;
using CompanyManagment.App.Contracts.FileAlert;


namespace CompanyManagment.EFCore.Repository
{
    public class FileAlertRepository : RepositoryBase<long, FileAlert>, IFileAlertRepository
    {
        private readonly CompanyContext _context;
        public FileAlertRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditFileAlert GetDetails(long id)
        {
            return _context.FileAlerts.Select(x => new EditFileAlert
            {
                Id = x.id,
                File_Id = x.File_Id,
                FileState_Id = x.FileState_Id,
                AdditionalDeadline = x.AdditionalDeadline
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
            var evidence = _context.FileAlerts.Where(x => x.id == id).FirstOrDefault();

            Remove(evidence);
        }

        public List<EditFileAlert> Search(FileAlertSearchModel searchModel)
        {
            var query = _context.FileAlerts.Select(x => new EditFileAlert
            {
                Id = x.id,
                File_Id = x.File_Id,
                FileState_Id = x.FileState_Id,
                AdditionalDeadline = x.AdditionalDeadline
            });

            //TODO if

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
