using _0_Framework.InfraStructure;
using System.Collections.Generic;
using System.Linq;
using Company.Domain.Contact2Agg;
using CompanyManagment.App.Contracts.Contact2;
using _0_Framework.Application;

namespace CompanyManagment.EFCore.Repository
{
    public class ContactRepository2 : RepositoryBase<long, EntityContact>, IContactRepozitory2
    {
        private readonly CompanyContext _context;
        public ContactRepository2(CompanyContext context):base(context)
        {
            _context = context;
        }

        public OperationResult Active(long id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult DeActive(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<Contact2ViewModel> GetAllContact()
        {
            return _context.EntityContacts.Select(x => new Contact2ViewModel
            {
                Id = x.id,
                NameContact = x.NameContact,
                IsActiveString = x.IsActiveString,
                Signature = x.Signature,

            }).ToList();
        }

        public EditContact2 GetDetails(long id)
        {

            return _context.EntityContacts.Select(x => new EditContact2
            {
                Id = x.id,
                NameContact = x.NameContact,
              


            }).FirstOrDefault(x => x.Id == id);
        }

        public List<Contact2ViewModel> PrintAll(List<long> ids)
        {
             return   _context.EntityContacts.Select(x => new Contact2ViewModel
                {
                 Id = x.id,
                 NameContact = x.NameContact,
                 IsActiveString = x.IsActiveString,
                 Signature = x.Signature,
             }).ToList();

          
        }

        public OperationResult Sign(long id)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult UnSign(long id)
        {
            throw new System.NotImplementedException();
        }

        List<Contact2ViewModel> IContactRepozitory2.Search(Contact2SearchModel searchModel)
        {
            var query = _context.EntityContacts.Select(x => new Contact2ViewModel
            {
                Id = x.id,
                NameContact = x.NameContact,
                IsActiveString = x.IsActiveString,
                Signature = x.Signature,

            });
            if (!string.IsNullOrWhiteSpace(searchModel.NameContact))
            {
               query = query.Where(x => x.NameContact.Contains(searchModel.NameContact));
            
            }

            if (string.IsNullOrWhiteSpace(searchModel.IsActiveString) || searchModel.IsActiveString == null || searchModel.IsActiveString == "null")
                query = query.Where(x => x.IsActiveString == "true");
            if (searchModel.IsActiveString== "false")
                query = query.Where(x => x.IsActiveString == "false");
            if (searchModel.IsActiveString == "true")
                query = query.Where(x => x.IsActiveString == "true");
      

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
