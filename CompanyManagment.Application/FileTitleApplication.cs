using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.FileTitle;
using CompanyManagment.App.Contracts.FileTitle;

namespace CompanyManagment.Application
{
    public class FileTitleApplication : IFileTitleApplication
    {
        private readonly IFileTitleRepository _fileTitleRepository;

        public FileTitleApplication(IFileTitleRepository fileTitleRepository)
        {
            _fileTitleRepository = fileTitleRepository;
        }

        public OperationResult Create(CreateFileTitle command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileTitle = new FileTitle(command.Title, command.Type);
            _fileTitleRepository.Create(fileTitle);
            _fileTitleRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileTitle.id);
        }

        public OperationResult Edit(EditFileTitle command)
        {
            var operation = new OperationResult();
            var fileTitle = _fileTitleRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            fileTitle.Edit(command.Title, command.Type);
            _fileTitleRepository.SaveChanges();

            return operation.Succcedded(entityId: fileTitle.id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _fileTitleRepository.Remove(id);
            _fileTitleRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

        public EditFileTitle GetDetails(long id)
        {
            return _fileTitleRepository.GetDetails(id);
        }

        public List<EditFileTitle> Search(FileTitleSearchModel searchModel)
        {
            return _fileTitleRepository.Search(searchModel);
        }
    }
}
