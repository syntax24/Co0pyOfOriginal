using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.FileTitle
{
    public class EditFileTitle : CreateFileTitle
    {
        public long Id { get; set; }
        //public long FileId { get; set; }
        //public long BoardTypeId { get; set; }

        public List<EditFileTitle> FileTitlesList { get; set; }

    }
}