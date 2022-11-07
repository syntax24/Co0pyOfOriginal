using _0_Framework.Application;

using Company.Domain.Contact2Agg;
using System.Collections.Generic;

using CompanyManagment.App.Contracts.Contact2;



namespace CompanyManagment.Application
{
    public class Contact2Appliction : IContactApplication2
    {
        private readonly IContactRepozitory2 _contactRepozitory2;

        public Contact2Appliction(IContactRepozitory2 contactRepozitory2)
        {
            _contactRepozitory2 = contactRepozitory2;
        }
        public OperationResult Create(CreateContact2 command)
        {
            var oprtaion = new OperationResult();
            if (_contactRepozitory2.Exists(x => x.NameContact == command.NameContact))
                oprtaion.Failed("عنوان تکراری است");
            var Contact = new EntityContact(command.NameContact);

            _contactRepozitory2.Create(Contact);
            _contactRepozitory2.SaveChanges();
            return oprtaion.Succcedded();
        }
        public OperationResult Edit(EditContact2 command)
        {
            var oprtaion = new OperationResult();

            var ContactEdit = _contactRepozitory2.Get(command.Id);

            if (_contactRepozitory2.Exists(x => x.NameContact == command.NameContact && x.id != command.Id))
                return oprtaion.Failed("  این عنوان قبلا ثبت شده است");

            if (string.IsNullOrWhiteSpace(command.NameContact))
                return oprtaion.Failed("ثبت  عوان الزامیست");


            ContactEdit.Edit(command.NameContact); ;
            _contactRepozitory2.SaveChanges();
            return oprtaion.Succcedded();
        }

        public List<Contact2ViewModel> GetAllContact()
        {
            return _contactRepozitory2.GetAllContact();
        }

        public EditContact2 GetDetails(long id)
        {
            return _contactRepozitory2.GetDetails(id);
        }

        public List<Contact2ViewModel> Search(Contact2SearchModel SearchModel)
        {
            return _contactRepozitory2.Search(SearchModel);
        }
    }
}
