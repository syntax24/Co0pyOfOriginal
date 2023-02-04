using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.CrossJobGuildAgg;
using CompanyManagment.App.Contracts.CrossJobGuild;

namespace CompanyManagment.EFCore.Repository
{
    public class CrossJobGuildRepository : RepositoryBase<long, CrossJobGuild>, ICrossJobGuildRepository
    {
        private readonly CompanyContext _context;
        public bool nationalCodValid = false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool StatCity = true;
        public bool city = true;
        public DateTime initial = new DateTime(1922, 01, 01, 00, 00, 00, 0000000);
        public CrossJobGuildRepository(CompanyContext context) :base(context)
        {
            _context = context;
        }

        public List<CrossJobGuildViewModel> GetCrossJobGuild()
        {
            return _context.CrossJobGuilds.Select(x => new CrossJobGuildViewModel
            {
                Id = x.id,
                Year= x.Year,
                Title= x.Title,
                EconomicCode= x.EconomicCode
            }).ToList();
        }

        public EditCrossJobGuild GetDetails(long id)
        {
            return _context.CrossJobGuilds.Select(x => new EditCrossJobGuild
            {
                Id = x.id,
                Year = x.Year,
                Title = x.Title,
                EconomicCode = x.EconomicCode,
                
            }).FirstOrDefault(x => x.Id == id);
            
        }

        public List<CrossJobGuildViewModel> Search(CrossJobGuildSearchModel searchModel)
        {
            var query = _context.CrossJobGuilds.Select(x => new CrossJobGuildViewModel
            {
                Id = x.id,
                Year = x.Year,
                Title = x.Title,
                EconomicCode = x.EconomicCode
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if (!string.IsNullOrWhiteSpace(searchModel.EconomicCode))
                query = query.Where(x => x.EconomicCode.Contains(searchModel.EconomicCode));
            if (searchModel.Year !=0)
                query = query.Where(x => x.Year== searchModel.Year);


            return query.OrderByDescending(x => x.Id).ToList();
        }


        public void Remove(long id)
        {
            var query = _context.CrossJobGuilds.Where(x => x.id == id).FirstOrDefault();
            Remove(query);
        }

    }
}
