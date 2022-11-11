using _0_Framework.Application;
using P_TextManager.Domin.TextManagerAgg;
using System.Collections.Generic;
using Company.Domain.TextManagerAgg;
using CompanyManagment.App.Contracts.TextManager;

namespace CompanyManagment.Application
{
    public class TextManagerAppliction : ITextManagerApplication
    {
        private readonly ITextManagerRepozitory _TextManagerRepozitory;


        public TextManagerAppliction(ITextManagerRepozitory TextManagerRepozitory)
        {
            _TextManagerRepozitory = TextManagerRepozitory;
        }
        public OperationResult Create(CreateTextManager command)
        {
            var oprtaion = new OperationResult();
            if (_TextManagerRepozitory.Exists(x => x.Paragraph == command.Paragraph))
                oprtaion.Failed("عنوان تکراری است");
            if (command.ModuleIds==null)
                return oprtaion.Failed("انتخاب حداقل یک مورد قسمت سرفصل ها الزامیست");
            var textManager = new EntityTextManager(command.NoteNumber,
                command.SubjectTextManager,
                command.NumberTextManager,
                Tools.ToGeorgian(command.DateTextManager.ToString()),
                command.Description,
                command.Paragraph,
                command.OriginalTitle_Id,
                command.Subtitle_Id,
                 command.Chapter_Id
                 
               );
            _TextManagerRepozitory.Create(textManager);
            _TextManagerRepozitory.SaveChanges();
            if (command.ModuleIds.Length > 0 && textManager.id > 0)
            {
                foreach (var moduleid in command.ModuleIds)
                {
                    _TextManagerRepozitory.ModuleTextManager(textManager.id, moduleid);
                }
            }
            return oprtaion.Succcedded();
        }
        public OperationResult Edit(EditTextManager command)
        {
            var oprtaion = new OperationResult();
            var textManager = _TextManagerRepozitory.Get(command.Id);
            //if (_TextManagerRepozitory.Exists(x => x.Paragraph == command.Paragraph && x.Id != command.Id))
            //    return oprtaion.Failed("  این عنوان قبلا ثبت شده است");
            if (command.ModuleIds == null)
                return oprtaion.Failed("انتخاب حداقل یک ماژول الزامیست");
        

            textManager.Edit(command.NoteNumber,
                                command.SubjectTextManager,
                                command.NumberTextManager,
                                Tools.ToGeorgian(command.DateTextManager.ToString()),
                                command.Description,
                                command.Paragraph,
                                command.OriginalTitle_Id,
                                command.Subtitle_Id,
                                command.Chapter_Id
                           
                                );
               
            _TextManagerRepozitory.SaveChanges();

            if (command.ModuleIds.Length > 0 && textManager.id > 0)
            {
                _TextManagerRepozitory.RemoveOldRelation(textManager.id);
                foreach (var moduleid in command.ModuleIds)
                {
                    _TextManagerRepozitory.ModuleTextManager(textManager.id, moduleid);
                }
            }
            return oprtaion.Succcedded();
        }
        public List<TextManagerViewModel> GetAllTextManager()
        {
            return _TextManagerRepozitory.GetAllTextManager();
        }
        public EditTextManager GetDetails(long id)
        {
            return _TextManagerRepozitory.GetDetails(id);
        }
        public List<TextManagerViewModel> Search(TextManagerSearchModel SearchModel)
        {
            return _TextManagerRepozitory.Search(SearchModel);
        }


        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var contract = _TextManagerRepozitory.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.Active();

            _TextManagerRepozitory.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var contract = _TextManagerRepozitory.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.DeActive();


            _TextManagerRepozitory.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult Sign(long id)
        {
            var opration = new OperationResult();
            var contract = _TextManagerRepozitory.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.Sign();


            _TextManagerRepozitory.SaveChanges();
            return opration.Succcedded();


        }

        public OperationResult UnSign(long id)
        {
            var opration = new OperationResult();
            var contract = _TextManagerRepozitory.Get(id);
            if (contract == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            contract.UnSign();


            _TextManagerRepozitory.SaveChanges();
            return opration.Succcedded();
        }

        public List<TextManagerViewModel> PrintAll(List<long> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
