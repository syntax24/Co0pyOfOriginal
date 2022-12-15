using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.FileState;


namespace Company.Domain.FileState
{
    public interface IFileStateRepository : IRepository<long, FileState>
    {
        EditFileState GetDetails(long id);
        //void Remove(long id);
        List<EditFileState> Search(FileStateSearchModel searchModel);
    }
}
