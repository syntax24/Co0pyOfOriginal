using System.Collections.Generic;

using _0_Framework_b.Application;

namespace CompanyManagment.App.Contracts.ProceedingSession
{
    public interface IProceedingSessionApplication
    {
        OperationResult Create(CreateProceedingSession command);
        OperationResult Edit(EditProceedingSession command);
        List<EditProceedingSession> Search(ProceedingSessionSearchModel searchModel);
        OperationResult CreateProceedingSessions(List<EditProceedingSession> proceedingSessions, long boardId);
        void RemoveProceedingSessions(long boardId);
        public List<ProceedingSessionViewModel> FilterSessions(ProceedingSessionSearchModel searchModel);
    }
}
