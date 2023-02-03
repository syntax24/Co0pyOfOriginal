using System.Collections.Generic;
using CompanyManagment.App.Contracts.EvidenceDetail;
using CompanyManagment.App.Contracts.File1;

namespace CompanyManagment.App.Contracts.Evidence
{
    public class CreateEvidence
    {
        public string Description { get; set; }
        public int BoardType_Id { get; set; }
        public long File_Id { get; set; }

        public bool BoardProcessingStage { get; set; }
        public EditFile FileData { get; set; }
        public List<EditEvidenceDetail> CreateEvidenceDetail { get; set; }

    }
}
