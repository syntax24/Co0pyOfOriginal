using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.FileTitle;


namespace Company.Domain.FileTitle
{
    public interface IFileTitleRepository : IRepository<long, FileTitle>
    {
        EditFileTitle GetDetails(long id);
        void Remove(long id);
        List<EditFileTitle> Search(FileTitleSearchModel searchModel);
    }
}
