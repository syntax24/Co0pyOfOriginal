using System.Collections.Generic;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;

namespace CompanyManagment.App.Contracts.File1
{
    public class EditFile : CreateFile
    {
        public long Id { get; set; }

        public EditBoard createDiagnosisBoard { get; set; }
        public EditBoard createDisputeResolutionBoard { get; set; }
        public List<EditProceedingSession> createDiagnosisPS { get; set; }
        public List<EditProceedingSession> createDisputeResolutionPS { get; set; }
        public EditPetition createDiagnosisPetition { get; set; }
        public EditPetition createDisputeResolutionPetition { get; set; }
    }
}