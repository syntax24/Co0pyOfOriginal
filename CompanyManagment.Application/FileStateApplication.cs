using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.FileState;
using CompanyManagment.App.Contracts.FileState;

namespace CompanyManagment.Application
{
    public class FileStateApplication : IFileStateApplication
    {
        private readonly IFileStateRepository _fileStateRepository;

        public FileStateApplication(IFileStateRepository fileStateRepository)
        {
            _fileStateRepository = fileStateRepository;
        }

        public OperationResult Create(CreateFileState command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileState = new FileState(command.State, command.FileTiming_Id, command.Title);
            //_fileStateRepository.Create(fileState);
            _fileStateRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileState.id);
        }

        public OperationResult Edit(EditFileState command)
        {
            var operation = new OperationResult();
            var fileState = _fileStateRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            //fileState.Edit(command.State, command.Type);
            _fileStateRepository.SaveChanges();

            return operation.Succcedded(entityId: fileState.id);
        }

        //public OperationResult Remove(long id)
        //{
        //    var operation = new OperationResult();

        //    _fileStateRepository.Remove(id);
        //    _fileStateRepository.SaveChanges();

        //    return operation.Succcedded("عنوان با موفقیت حذف شد");
        //}

        public EditFileState GetDetails(long id)
        {
            return _fileStateRepository.GetDetails(id);
        }

        public List<EditFileState> Search(FileStateSearchModel searchModel)
        {
            return _fileStateRepository.Search(searchModel);
        }
    }
}
