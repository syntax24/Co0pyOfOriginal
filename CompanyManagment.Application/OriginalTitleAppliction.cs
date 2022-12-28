using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.OriginalTitleAgg;
using CompanyManagment.App.Contracts.OriginalTitle;

namespace CompanyManagment.Application
{
    public class OriginalTitleAppliction : IOriginalTitleApplication
    {
        private readonly IOriginalTitleRepozitory _originalTitleRepozitory;

        public OriginalTitleAppliction(IOriginalTitleRepozitory originalTitleRepozitory)
        {
            _originalTitleRepozitory = originalTitleRepozitory;
        }

        
        public OperationResult Create(CreateOriginalTitle command)
        {
            var oprtaion = new OperationResult();
            if (_originalTitleRepozitory.Exists(x => x.Title == command.Title ))
                return oprtaion.Failed("  این عنوان قبلا ثبت شده است");

            if (string.IsNullOrWhiteSpace(command.Title))
                return oprtaion.Failed("ثبت  عنوان الزامیست");



            var originalTitle = new EntityOriginalTitle(command.Title);
            _originalTitleRepozitory.Create(originalTitle);
            _originalTitleRepozitory.SaveChanges();
            return oprtaion.Succcedded(); 
        }

        public OperationResult Edit(EditOriginalTitle command)
        {
            var oprtaion = new OperationResult();

            var originalTitle = _originalTitleRepozitory.Get(command.Id);

            if (_originalTitleRepozitory.Exists(x => x.Title == command.Title && x.id != command.Id))
                return oprtaion.Failed("  این عنوان قبلا ثبت شده است");

            if (string.IsNullOrWhiteSpace(command.Title))
                return oprtaion.Failed("ثبت  عنوان الزامیست");


            originalTitle.Edit( command.Title);
            _originalTitleRepozitory.SaveChanges();
            return oprtaion.Succcedded();
        }

        public List<OriginalTitleViewModel> GetAllOriginalTitle()
        {
            return _originalTitleRepozitory.GetAllOriginalTitle();
        }

        public EditOriginalTitle GetDetails( long id)
        {
            return _originalTitleRepozitory.GetDetails(id);
        }

        public List<OriginalTitleViewModel> Search(OriginalTitleSearchModel SearchModel)
        {
            return _originalTitleRepozitory.Search(SearchModel);
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var originalTitle = _originalTitleRepozitory.Get(id);
            if (originalTitle == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            originalTitle.Active();

            _originalTitleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var originalTitle = _originalTitleRepozitory.Get(id);
            if (originalTitle == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            originalTitle.DeActive();


            _originalTitleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
    }
}
