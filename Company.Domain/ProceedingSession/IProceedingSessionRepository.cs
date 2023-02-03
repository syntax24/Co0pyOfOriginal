using System;
using System.Collections.Generic;
using _0_Framework_b.Domain;
using CompanyManagment.App.Contracts.ProceedingSession;


namespace Company.Domain.ProceedingSession
{
    public interface IProceedingSessionRepository : IRepository<long, ProceedingSession>
    {
        List<EditProceedingSession> Search(ProceedingSessionSearchModel searchModel);
        void RemoveProceedingSessions(List<EditProceedingSession> proceedingSessions);

    }
}
