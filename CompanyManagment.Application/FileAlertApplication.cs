using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework_b.Application;
using Company.Domain.File1;
using Company.Domain.FileAlert;
using Company.Domain.FileState;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.FileAlert;
using CompanyManagment.App.Contracts.FileState;

namespace CompanyManagment.Application
{
    public class FileAlertApplication : IFileAlertApplication
    {
        private readonly IFileAlertRepository _fileAlertRepository;
        private readonly IFileStateApplication _fileStateApplication;
        private readonly IFileApplication _fileApplication;

        public FileAlertApplication(IFileAlertRepository fileAlertRepository, IFileStateApplication fileStateApplication, IFileApplication fileApplication)
        {
            _fileAlertRepository = fileAlertRepository;
            _fileStateApplication = fileStateApplication;
            _fileApplication = fileApplication;
        }

        public OperationResult Create(CreateFileAlert command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileAlert = new FileAlert(command.File_Id, command.FileState_Id, command.AdditionalDeadline);
            _fileAlertRepository.Create(fileAlert);
            _fileAlertRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileAlert.id);
        }

        public OperationResult Edit(EditFileAlert command)
        {
            var operation = new OperationResult();
            var fileAlert = _fileAlertRepository.Get(command.Id);

            //TODO

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

        public FileAlertViewModel GetDetails(long id)
        {
            var fileAlert = _fileAlertRepository.GetDetails(id);
            fileAlert.FileState = _fileStateApplication.GetDetails(fileAlert.FileState_Id);
            fileAlert.File = _fileApplication.GetDetails(fileAlert.File_Id);

            return fileAlert;
        }

        public List<EditFileAlert> Search(FileAlertSearchModel searchModel)
        {
            return _fileAlertRepository.Search(searchModel);
        }

        public List<FileAlertViewModel> GetFilesAlerts(List<FileViewModel> files)
        {
            var fileStates = _fileStateApplication.Search(new FileStateSearchModel());
            var fileAlertsVM = new List<FileAlertViewModel>();

            foreach (var item in files)
            {
                var file = _fileApplication.GetFileDetails(item);
                file.State = _fileApplication.GetFileState(file);

                if (file.State == 0)
                    continue;

                file.StateDate = _fileApplication.GetFileStateDate(file);
                var today = DateTime.Now.Date;

                var fileAlerts = Search(new FileAlertSearchModel { File_Id = file.Id, FileState_Id = file.State });

                if (today < file.StateDate)
                    //TODO
                    //check Alerts table
                    continue;

                if (fileAlerts.Count == 0)
                {
                    var dueDate = file.StateDate + TimeSpan.FromDays(fileStates.Where(x => x.State == file.State).FirstOrDefault().Deadline);
                    var workingDaysDifference = Tools.GetWorkingDaysDifference(today, dueDate);

                    if (workingDaysDifference <= 1)
                    {
                        var fileAlertId = Create(new CreateFileAlert
                        {
                            File_Id = file.Id,
                            FileState_Id = file.State,
                            AdditionalDeadline = 0
                        }).EntityId;

                        var fileAlert = GetDetails(fileAlertId);
                        if (workingDaysDifference < 0)
                            fileAlert.IsExpired = true;

                        fileAlertsVM.Add(fileAlert);
                    }
                }

                else if (fileAlerts.Count == 1)
                {
                    var dueDate = file.StateDate + TimeSpan.FromDays(fileStates.Where(x => x.State == file.State).FirstOrDefault().Deadline);
                    var workingDaysDifference = Tools.GetWorkingDaysDifference(today, dueDate);

                    if (workingDaysDifference <= 1)
                    {
                        var fileAlert = GetDetails(fileAlerts[0].Id);
                        if (workingDaysDifference < 0)
                            fileAlert.IsExpired = true;

                        fileAlertsVM.Add(fileAlert);
                    }
                }

                else
                {
                    var totalAdditionalDeadline = fileAlerts.Sum(x => x.AdditionalDeadline);
                    var dueDate = file.StateDate + TimeSpan.FromDays(fileStates.Where(x => x.State == file.State).FirstOrDefault().Deadline) + TimeSpan.FromDays(totalAdditionalDeadline);
                    var workingDaysDifference = Tools.GetWorkingDaysDifference(today, dueDate);

                    if (workingDaysDifference <= 1)
                    {
                        var fileAlert = GetDetails(fileAlerts.LastOrDefault().Id);
                        if (workingDaysDifference < 0)
                            fileAlert.IsExpired = true;

                        fileAlertsVM.Add(fileAlert);
                    }
                }
            }

            return fileAlertsVM;
        }

        public int getMaximumAdditionalDeadlineTimes(int additionalDeadline)
        {

            switch (additionalDeadline)
            {
                case 2:
                    return (int) FileAlertEnums.Maximum_2_DaysExtension;

                case 5:
                    return (int) FileAlertEnums.Maximum_5_DaysExtension;

                case 10:
                    return (int) FileAlertEnums.Maximum_10_DaysExtension;

            }

            return 0;
        }

    }
}
