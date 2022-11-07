using System.Collections.Generic;
using _0_Framework.Domain;
using CompanyManagment.App.Contracts.ProceedingSession;


namespace Company.Domain.ProceedingSession
{
    public interface IProceedingSessionRepository : IRepository<long, ProceedingSession>
    {
        List<EditProceedingSession> Search(ProceedingSessionSearchModel searchModel);
        void RemoveProceedingSessions(List<EditProceedingSession> proceedingSessions);

    }
}
