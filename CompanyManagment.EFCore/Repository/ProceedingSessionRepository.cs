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
            var query = _context.ProceedingSessions.Select(x => new 
            {
                Id = x.id,
                Date = x.Date,
                Time = x.Time,
                Board_Id = x.Board_Id,
                Status = x.Status
            });

            //TODO if

            if(searchModel.Id != 0)
            {
                query = query.Where(x => x.Id == searchModel.Id);
            }
            
            if(searchModel.Board_Id != 0)
            {
                query = query.Where(x => x.Board_Id == searchModel.Board_Id);
            }
            
            if(searchModel.Status != 0)
            {
                query = query.Where(x => x.Status == searchModel.Status);
            }

            if(!string.IsNullOrEmpty(searchModel.FromDate))
            {
                query = query.Where(x => x.Date >= searchModel.FromDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrEmpty(searchModel.ToDate))
            {
                query = query.Where(x => x.Date <= searchModel.ToDate.ToGeorgianDateTime());
            }
            
            if (!string.IsNullOrEmpty(searchModel.Time))
            {
                query = query.Where(x => x.Time == searchModel.Time);
            }

            return query.Select(x => new EditProceedingSession {
                Id = x.Id,
                Date = x.Date.ToFarsi(),
                Time = x.Time,
                Board_Id = x.Board_Id,
                Status = x.Status
            }).ToList();
        }
    }
}
