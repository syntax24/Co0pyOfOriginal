using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.Petition;
using CompanyManagment.App.Contracts.ProceedingSession;
using System;

namespace CompanyManagment.App.Contracts.File1
{
    public class FileViewModel
    {
        public long Id { get; set; }
        public long ArchiveNo { get; set; }
        public string ClientVisitDate { get; set; }
        public string ProceederReference { get; set; }
        public long Reqester { get; set; }
        public long Summoned { get; set; }
        public int Client { get; set; }
        public string FileClass { get; set; }
        public int HasMandate { get; set; }
        public string Description { get; set; }
        public string ReqesterFullname { get; set; }
        public string SummonedFullname { get; set; }
        public string ClientFullName { get; set; }
        public string OppositePersonFullName { get; set; }
        public EditBoard DiagnosisBoard { get; set; }
        public EditBoard DisputeResolutionBoard { get; set; }
        public int DiagnosisPsCount { get; set; }
        public EditProceedingSession FirstDiagnosisPS { get; set; }
        public EditProceedingSession LastDiagnosisPS { get; set; }
        public int DisputeResolutionPsCount { get; set; }
        public EditProceedingSession FirstDisputeResolutionPS { get; set; }
        public EditProceedingSession LastDisputeResolutionPS { get; set; }
        public EditPetition DiagnosisPetition { get; set; }
        public EditPetition DisputeResolutionPetition { get; set; }
        public long DiagnosisMasterPetitionId { get; set; }
        public long DisputeResolutionMasterPetitionId { get; set; }
        public long DiagnosisEvidenceId { get; set; }
        public long DisputeResolutionEvidenceId { get; set; }
        public int Status { get; set; }
        public int State { get; set; }
        public DateTime? StateDate { get; set; }
    }
}