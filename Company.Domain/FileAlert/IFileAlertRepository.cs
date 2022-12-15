using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.FileAlert;


namespace Company.Domain.FileAlert
{
    public interface IFileAlertRepository : IRepository<long, FileAlert>
    {
        EditFileAlert GetDetails(long id);
        void Remove(long id);
        List<EditFileAlert> Search(FileAlertSearchModel searchModel);
    }
}
