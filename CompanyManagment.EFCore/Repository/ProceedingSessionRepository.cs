using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.ProceedingSession;
using CompanyManagment.App.Contracts.ProceedingSession;
using CompanyManagment.EFCore;

namespace File.EfCore.Repository
{
    public class ProceedingSessionRepository : RepositoryBase<long, ProceedingSession>, IProceedingSessionRepository
    {
        private readonly CompanyContext _context;
        public ProceedingSessionRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveProceedingSessions(List<EditProceedingSession> proceedingSessions)
        {
            foreach (var obj in proceedingSessions)
            {
                var proceedingSession = Get(obj.Id);

                Remove(proceedingSession);
            }
        }

        public List<EditProceedingSession> Search(ProceedingSessionSearchModel searchModel)
        {
            var query = _context.ProceedingSessions.Select(x => new EditProceedingSession
            {
                Id = x.id,
                Date = x.Date.ToFarsi(),
                Time = x.Time,
                Board_Id = x.Board_Id
            }).Where(x => x.Board_Id == searchModel.Board_Id);

            //TODO if

            if(!string.IsNullOrEmpty(searchModel.FromDate))
            {
                query = query.Where(x => x.Date.ToGeorgianDateTime() >= searchModel.FromDate.ToGeorgianDateTime());
            }
            
            if(!string.IsNullOrEmpty(searchModel.ToDate))
            {
                query = query.Where(x => x.Date.ToGeorgianDateTime() <= searchModel.ToDate.ToGeorgianDateTime());
            }

            return query.ToList();
        }
    }
}
