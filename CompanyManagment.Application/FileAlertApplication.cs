using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.FileAlert;
using CompanyManagment.App.Contracts.FileAlert;

namespace CompanyManagment.Application
{
    public class FileAlertApplication : IFileAlertApplication
    {
        private readonly IFileAlertRepository _fileAlertRepository;

        public FileAlertApplication(IFileAlertRepository fileAlertRepository)
        {
            _fileAlertRepository = fileAlertRepository;
        }

        public OperationResult Create(CreateFileAlert command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileAlert = new FileAlert(command.File_Id, command.FileState_Id, command.AdditionalDeadline);
            //_fileAlertRepository.Create(fileAlert);
            _fileAlertRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileAlert.id);
        }

        public OperationResult Edit(EditFileAlert command)
        {
            var operation = new OperationResult();
            var fileAlert = _fileAlertRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            //fileAlert.Edit(command.Alert, command.Type);
            _fileAlertRepository.SaveChanges();

            return operation.Succcedded(entityId: fileAlert.id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _fileAlertRepository.Remove(id);
            _fileAlertRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }

        public EditFileAlert GetDetails(long id)
        {
            return _fileAlertRepository.GetDetails(id);
        }

        public List<EditFileAlert> Search(FileAlertSearchModel searchModel)
        {
            return _fileAlertRepository.Search(searchModel);
        }
    }
}
