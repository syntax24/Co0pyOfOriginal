using System.Collections.Generic;
using System.Linq;
using _0_Framework.InfraStructure;
using Company.Domain.ContarctingPartyAgg;
using CompanyManagment.App.Contracts.PersonalContractingParty;

namespace CompanyManagment.EFCore.Repository
{
    public class PersonalContractingPartyRepository : RepositoryBase<long, PersonalContractingParty>, IPersonalContractingPartyRepository
    {
        private readonly CompanyContext _context;

        public PersonalContractingPartyRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }


        public List<PersonalContractingPartyViewModel> GetPersonalContractingParties()
        {
            return _context.PersonalContractingParties.Select(x => new PersonalContractingPartyViewModel
            {
                id = x.id,
               
                //FName = x.FName,
                LName = x.LName,
                //Nationalcode = x.Nationalcode,
                //IdNumber = x.IdNumber,
                //RegisterId = x.RegisterId,
                //NationalId = x.NationalId,
                //IsLegal = x.IsLegal,
                //Phone = x.Phone,
                //AgentPhone = x.AgentPhone,
                //Address = x.Address
                
            }).ToList();
        }


        public EditPersonalContractingParty GetDetails(long id)
        {
            return _context.PersonalContractingParties.Select(x => new EditPersonalContractingParty()
                {
                Id = x.id,
              
                FName = x.FName,
                LName = x.LName,
                Nationalcode = x.Nationalcode,
                IdNumber = x.IdNumber,
                RegisterId = x.RegisterId,
                NationalId = x.NationalId,
                IsLegal = x.IsLegal,
                Phone = x.Phone,
                AgentPhone = x.AgentPhone,
                Address = x.Address

            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<PersonalContractingPartyViewModel> Search(PersonalContractingPartySearchModel searchModel2)
        {
            var query = _context.PersonalContractingParties.Select(x => new PersonalContractingPartyViewModel
            {
                id = x.id,
              
                FName = x.FName,
                LName = x.LName,
                Nationalcode = x.Nationalcode,
                IdNumber = x.IdNumber,
                RegisterId = x.RegisterId,
                NationalId = x.NationalId,
                IsLegal = x.IsLegal,
                
              

                CreationDate = x.CreationDate.ToString()
        });
            
            if (!string.IsNullOrWhiteSpace(searchModel2.FName))
                query = query.Where(x => x.FName.Contains(searchModel2.FName));
            if (!string.IsNullOrWhiteSpace(searchModel2.LName))
                query = query.Where(x => x.LName.Contains(searchModel2.LName));
            if (!string.IsNullOrWhiteSpace(searchModel2.Nationalcode))
                query = query.Where(x => x.Nationalcode.Contains(searchModel2.Nationalcode));
            if (!string.IsNullOrWhiteSpace(searchModel2.IdNumber))
                query = query.Where(x => x.IdNumber.Contains(searchModel2.IdNumber));
            if (!string.IsNullOrWhiteSpace(searchModel2.RegisterId))
                query = query.Where(x => x.RegisterId.Contains(searchModel2.RegisterId));
            if (!string.IsNullOrWhiteSpace(searchModel2.NationalId))
                query = query.Where(x => x.NationalId.Contains(searchModel2.NationalId));
            if (!string.IsNullOrWhiteSpace(searchModel2.IsLegal))
                query = query.Where(x => x.IsLegal.Contains(searchModel2.IsLegal));

            return query.OrderByDescending(x => x.id).ToList();
        }
    }
}
