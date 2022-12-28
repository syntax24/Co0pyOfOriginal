using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.FileAlert;
using Company.Domain.FileState;
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

        public FileAlertViewModel GetDetails(long id)
        {
            return _context.FileAlerts.Select(x => new FileAlertViewModel
            {
                Id = x.id,
                File_Id = x.File_Id,
                FileState_Id = x.FileState_Id,
                AdditionalDeadline = x.AdditionalDeadline,
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
            var fileAlert = _context.FileAlerts.Where(x => x.id == id).FirstOrDefault();

            Remove(fileAlert);
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
            if(searchModel.FileState_Id != 0)
            {
                query = query.Where(x => x.FileState_Id == searchModel.FileState_Id);
            }
            
            if(searchModel.File_Id != 0)
            {
                query = query.Where(x => x.File_Id == searchModel.File_Id);
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
