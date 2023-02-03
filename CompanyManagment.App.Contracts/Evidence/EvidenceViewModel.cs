using System;

namespace CompanyManagment.App.Contracts.Evidence
{
    public class EvidenceViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long BoardType_Id { get; set; }
        public long File_Id { get; set; }
    }
}