using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.BillAgg;
using CompanyManagment.App.Contracts.Bill;
using CompanyManagment.App.Contracts.TextManager;
using CompanyManagment.App.Contracts.Employee;
using Company.Domain.EmployeeAgg;

namespace CompanyManagment.Application
{
    public class BillAppliction : IBillApplication
    {
        private readonly IBillRepozitory _BillRepozitory;
        private readonly IEmployeeRepository _employeeRepository;

        public BillAppliction(IBillRepozitory BillRepozitory)
        {
            _BillRepozitory = BillRepozitory;
           
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var bill = _BillRepozitory.Get(id);
            if (bill == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            bill.Active();

            _BillRepozitory.SaveChanges();
            return opration.Succcedded();
        }
        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var bill = _BillRepozitory.Get(id);
            if (bill == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            bill.DeActive();


            _BillRepozitory.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult Create(CreateBill command)
        {
            var oprtaion = new OperationResult();
            //if (_BillRepozitory.Exists(x => x. == command.Paragraph))
            //    oprtaion.Failed("عنوان تکراری است");
            //if (command.ModuleIds==null)
            //    return oprtaion.Failed("انتخاب حداقل یک مورد قسمت سرفصل ها الزامیست");
            var bill = new EntityBill(command.SubjectBill,
                                command.Description,
                                command.Appointed,
                                command.Contact,
                                command.ProcessingStage
                                
                                );
            _BillRepozitory.Create(bill);
            _BillRepozitory.SaveChanges();
            //if (command.ModuleIds.Length > 0 && bill.Id > 0)
            //{
            //    foreach (var moduleid in command.ModuleIds)
            //    {
            //        _BillRepozitory.ModuleTextManager(bill.Id, moduleid);
            //    }
            //}
            return oprtaion.Succcedded();
        }

      

        public OperationResult Edit(EditBill command)
        {
            var oprtaion = new OperationResult();
            var textManager = _BillRepozitory.Get(command.Id);
            //if (_TextManagerRepozitory.Exists(x => x.Paragraph == command.Paragraph && x.Id != command.Id))
            //    return oprtaion.Failed("  این عنوان قبلا ثبت شده است");
            //if (command.ModuleIds == null)
            //    return oprtaion.Failed("انتخاب حداقل یک مورد الزامیست");


                textManager.Edit(command.SubjectBill,
                                command.Description,
                                command.Appointed,
                                command.Contact,
                                command.ProcessingStage
                               
                                );

            _BillRepozitory.SaveChanges();

            
            return oprtaion.Succcedded();
        }
     
        public EditBill GetDetails(long id)
        {
            return _BillRepozitory.GetDetails(id);
        }
        public List<BillViewModel> Search(BillSearchModel SearchModel)
        {
            return _BillRepozitory.Search(SearchModel);
        }

        public List<BillViewModel> GetAllTextManager()
        {
            throw new System.NotImplementedException();
        }
    }
}
