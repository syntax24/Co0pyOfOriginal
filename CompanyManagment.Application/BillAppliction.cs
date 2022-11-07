using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.BillAgg;
using CompanyManagment.App.Contracts.Bill;
using CompanyManagment.App.Contracts.TextManager;

namespace CompanyManagment.Application
{
    public class BillAppliction : IBillApplication
    {
        private readonly IBillRepozitory _BillRepozitory;


        public BillAppliction(IBillRepozitory BillRepozitory)
        {
            _BillRepozitory = BillRepozitory;
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
                                command.ProcessingStage,
                                 command.Status
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
                                command.ProcessingStage,
                                 command.Status
                                );

            _BillRepozitory.SaveChanges();

            
            return oprtaion.Succcedded();
        }
        public List<BillViewModel> GetAllTextManager()
        {
            return _BillRepozitory.GetAllBill();
        }
        public EditBill GetDetails(long id)
        {
            return _BillRepozitory.GetDetails(id);
        }
        public List<BillViewModel> Search(BillSearchModel SearchModel)
        {
            return _BillRepozitory.Search(SearchModel);
        }
    }
}
