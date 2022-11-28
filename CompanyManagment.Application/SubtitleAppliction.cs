using _0_Framework.Application;
using System.Collections.Generic;
using Company.Domain.SubtitleAgg;
using CompanyManagment.App.Contracts.Subtitle;

namespace CompanyManagment.Application
{
    public class SubtitleAppliction : ISubtitleApplication
    {
        private readonly ISubtitleRepozitory _subtitleRepozitory;

        public SubtitleAppliction(ISubtitleRepozitory SubtitleRepozitory)
        {
            _subtitleRepozitory = SubtitleRepozitory;
        }

        
        public OperationResult Create(CreateSubtitle command)
        {
            var oprtaion = new OperationResult();
      
            if (string.IsNullOrWhiteSpace(command.Subtitle))
                return oprtaion.Failed("ثبت  بخش الزامیست");
            if (command.OriginalTitle_Id<=0)
                return oprtaion.Failed("انتخاب  عنوان الزامیست");

            var Subtitle = new EntitySubtitle(command.Subtitle, command.OriginalTitle_Id);

            _subtitleRepozitory.Create(Subtitle);
            _subtitleRepozitory.SaveChanges();
            return oprtaion.Succcedded(); 
        }

        public OperationResult Edit(EditSubtitle command)
        {
            var oprtaion = new OperationResult();

            var SubtitleEdit = _subtitleRepozitory.Get(command.Id);
            if (string.IsNullOrWhiteSpace(command.Subtitle))
                return oprtaion.Failed("ثبت  بخش الزامیست");

            if (string.IsNullOrWhiteSpace(command.OriginalTitle_Id.ToString()))
                return oprtaion.Failed("انتخاب  عنوان الزامیست");

            SubtitleEdit.Edit( command.Subtitle,  command.OriginalTitle_Id);

            _subtitleRepozitory.SaveChanges();
            return oprtaion.Succcedded();
        }

       
        public EditSubtitle GetDetails( long id)
        {
            return _subtitleRepozitory.GetDetails(id);
        }

        public List<SubtitleViewModel> Search(SubtitleSearchModel SearchModel)
        {
            return _subtitleRepozitory.Search(SearchModel);
        }

        public List<SubtitleViewModel> GetAllSubtitle()
        {
            return _subtitleRepozitory.GetAllSubtitle();

        }
        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var subtitle = _subtitleRepozitory.Get(id);
            if (subtitle == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            subtitle.Active();

            _subtitleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var subtitle = _subtitleRepozitory.Get(id);
            if (subtitle == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            subtitle.DeActive();


            _subtitleRepozitory.SaveChanges();
            return opration.Succcedded();
        }
    }
}
