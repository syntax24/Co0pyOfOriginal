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
            if (_subtitleRepozitory.Exists(x => x.Subtitle == command.Subtitle ))
                return oprtaion.Failed("  این متن برای بخش قبلا ثبت شده است");

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

            if (_subtitleRepozitory.Exists(x => x.Subtitle == command.Subtitle))
                return oprtaion.Failed("  این متن برای بخش قبلا ثبت شده است");
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

     
    }
}
