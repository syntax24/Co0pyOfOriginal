using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using Company.Domain.File1;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.File1;

namespace CompanyManagment.Application
{
    public class FileApplication : IFileApplication
    {
        private readonly IFileRepository _fileRepository;

        public FileApplication(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public OperationResult Create(CreateFile command)
        {
            var operation = new OperationResult();
            var clientVisitDate = new DateTime();

            clientVisitDate = command.ClientVisitDate.ToGeorgianDateTime();

            //TODO if
            if(_fileRepository.Exists(x=>x.ArchiveNo == command.ArchiveNo))
                return operation.Failed("شماره بایگانی تکراری است");

            var file = new Company.Domain.File1.File1(command.ArchiveNo, clientVisitDate, command.ProceederReference,
                command.Reqester, command.Summoned, command.Client, command.FileClass, command.HasMandate,
                command.Description);
            _fileRepository.Create(file);
            _fileRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditFile command)
        {
            var operation = new OperationResult();
            var file = _fileRepository.Get(command.Id);
            var clientVisitDate = new DateTime();

            if (command.ClientVisitDate != null)
            {
                
                clientVisitDate = command.ClientVisitDate.ToGeorgianDateTime();
            }
            else
            {
                clientVisitDate = file.ClientVisitDate;
            }


            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            file.Edit(command.ArchiveNo, clientVisitDate, command.ProceederReference,
                command.Reqester, command.Summoned, command.Client, command.FileClass, command.HasMandate,
                command.Description);
            _fileRepository.SaveChanges();

            return operation.Succcedded();
        }

        public EditFile GetDetails(long id)
        {
            return _fileRepository.GetDetails(id);
        }

        public List<FileViewModel> Search(FileSearchModel searchModel)
        {
            return _fileRepository.Search(searchModel);
        }

        public FileViewModel GetLastArchiveNumber(FileSearchModel searchModel)
        {
            var model = Search(searchModel);

           return model.Count != 0 ? model.OrderByDescending(x => x.ArchiveNo).FirstOrDefault() : new FileViewModel { ArchiveNo = 0 };
        }
        public long FindLastArchiveNumber()
        {
            return _fileRepository.FindLastArchiveNumber();
        }

        public string GetEmployeeFullNameById(long id)
        {
            return _fileRepository.GetEmployeeFullNameById(id);
        }

        public string GetEmployerFullNameById(long id)
        {
            return _fileRepository.GetEmployerFullNameById(id);
        }

        public List<EmployeeViewModel> GetAllEmploees()
        {
            return _fileRepository.GetAllEmploees();
        }

        public List<EmployerViewModel> GetAllEmployers()
        {
            return _fileRepository.GetAllEmployers();
        }
    }
}
