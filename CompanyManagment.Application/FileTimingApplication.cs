using System;
using System.Collections.Generic;
using _0_Framework_b.Application;
using Company.Domain.FileTiming;
using CompanyManagment.App.Contracts.FileTiming;

namespace CompanyManagment.Application
{
    public class FileTimingApplication : IFileTimingApplication
    {
        private readonly IFileTimingRepository _fileTimingRepository;

        public FileTimingApplication(IFileTimingRepository fileTimingRepository)
        {
            _fileTimingRepository = fileTimingRepository;
        }

        public OperationResult Create(CreateFileTiming command)
        {
            var operation = new OperationResult();

            //TODO if
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            var fileTiming = new FileTiming(command.Deadline, command.Title, command.Tips);
            _fileTimingRepository.Create(fileTiming);
            _fileTimingRepository.SaveChanges();

            

            return operation.Succcedded(entityId: fileTiming.id);
        }

        public OperationResult Edit(EditFileTiming command)
        {
            var operation = new OperationResult();
            var fileTiming = _fileTimingRepository.Get(command.Id);

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            fileTiming.Edit(command.Deadline);
            _fileTimingRepository.SaveChanges();

            return operation.Succcedded(entityId: fileTiming.id);
        }

        public FileTimingViewModel GetDetails(long id)
        {
            return _fileTimingRepository.GetDetails(id);
        }

        //public OperationResult Remove(long id)
        //{
        //    var operation = new OperationResult();

        //    _fileTimingRepository.Remove(id);
        //    _fileTimingRepository.SaveChanges();

        //    return operation.Succcedded("عنوان با موفقیت حذف شد");
        //}

        //public EditFileTiming GetDetails(long id)
        //{
        //    return _fileTimingRepository.GetDetails(id);
        //}

        public List<EditFileTiming> Search(FileTimingSearchModel searchModel)
        {
            return _fileTimingRepository.Search(searchModel);
        }
    }
}
