using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.FileAlert
{
    public class CreateFileAlert
    {
        public long File_Id { get; set; }
        public long FileState_Id { get; set; }
        public int AdditionalDeadline { get; set; }
    }
}
