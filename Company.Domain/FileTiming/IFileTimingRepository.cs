using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.FileTiming;


namespace Company.Domain.FileTiming
{
    public interface IFileTimingRepository : IRepository<long, FileTiming>
    {
        //EditFileTiming GetDetails(long id);
        //void Remove(long id);
        List<EditFileTiming> Search(FileTimingSearchModel searchModel);
    }
}
