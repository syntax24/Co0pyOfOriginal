using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework_b.Application;
using Company.Domain.File1;
using Company.Domain.ProceedingSession;
using CompanyManagment.App.Contracts.Board;
using CompanyManagment.App.Contracts.File1;
using CompanyManagment.App.Contracts.ProceedingSession;
using MD.PersianDateTime.Standard;

namespace CompanyManagment.Application
{
    public class ProceedingSessionApplication : IProceedingSessionApplication
    {
        private readonly IProceedingSessionRepository _proceedingSessionRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IFileApplication _fileApplication;
        private readonly IBoardApplication _boardApplication;

        public ProceedingSessionApplication(
            IProceedingSessionRepository proceedingSessionRepository,
            IBoardApplication boardApplication,
            IFileRepository fileRepository,
            IFileApplication fileApplication
            )
        {
            _proceedingSessionRepository = proceedingSessionRepository;
            _fileRepository = fileRepository;
            _boardApplication = boardApplication;
            _fileApplication = fileApplication;
        }

        public OperationResult Create(CreateProceedingSession command)
        {
            var operation = new OperationResult();

            //var Time = new DateTime();
            //Time = command.Time.ToGeorgianDateTime();

            if (String.IsNullOrWhiteSpace(command.Date) && String.IsNullOrWhiteSpace(command.Time))
                return operation.Succcedded();

            if (String.IsNullOrWhiteSpace(command.Date) || String.IsNullOrWhiteSpace(command.Time))
                return operation.Failed("تاریخ و زمان رسیدگی الزامی است");
            
            var Date = new DateTime();
            Date = command.Date.ToGeorgianDateTime();

            var proSession = new ProceedingSession(Date, command.Time, command.Board_Id);
            _proceedingSessionRepository.Create(proSession);
            _proceedingSessionRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult CreateProceedingSessions(List<EditProceedingSession> proceedingSessions, long boardId)
        {
            var operation = new OperationResult();

            RemoveProceedingSessions(boardId);

            foreach (var obj in proceedingSessions)
            {
                obj.Board_Id = boardId;
                obj.Id = 0;

                Create(obj);
            }

            return operation.Succcedded();
        }

        public OperationResult Edit(EditProceedingSession command)
        {
            var operation = new OperationResult();
            var proSession = _proceedingSessionRepository.Get(command.Id);

            //var Date = new DateTime();
            //Date = command.Date.ToGeorgian();

            //var Time = new DateTime();
            //Time = command.Time.ToGeorgian();

            //TODO
            //if(_BoardRepository.Exists(x=>x.Branch == command.Branch))
            //    operation.Failed("fail message")

            proSession.Edit(command.Date.ToGeorgianDateTime(), command.Time, command.Board_Id, command.Status);
            _proceedingSessionRepository.SaveChanges();

            return operation.Succcedded();
        }

        public void RemoveProceedingSessions(long boardId)
        {
            var searchModel = new ProceedingSessionSearchModel { Board_Id = boardId };  
            
            var objects = Search(searchModel);

            _proceedingSessionRepository.RemoveProceedingSessions(objects);
        }

        public List<EditProceedingSession> Search(ProceedingSessionSearchModel searchModel)
        {
            return _proceedingSessionRepository.Search(searchModel);
        }


        public List<ProceedingSessionViewModel> FilterSessions(ProceedingSessionSearchModel searchModel)
        {
            var viewModels = new List<ProceedingSessionViewModel>();

            searchModel.FromDate = CreateFrom_ToDate(searchModel)[0];
            searchModel.ToDate = CreateFrom_ToDate(searchModel)[1];

            var proseedingSessions = Search(searchModel).OrderBy(x => x.Date).GroupBy(x => x.Date).ToList();
            var files = _fileRepository.Search(new FileSearchModel { ArchiveNo = searchModel.File.ArchiveNo.ToString() });

            foreach (var item in proseedingSessions)
            {

                viewModels.Add(new ProceedingSessionViewModel
                {
                    FullDate = PersianDateTime.Parse(item.Key).ToLongDateString(),
                    SessionsList = GetFile_Board_PSList(item, files, searchModel)
                });
            }

            foreach (var item in new List<ProceedingSessionViewModel>(viewModels))
            {
                if (item.SessionsList.Count == 0)
                    viewModels.Remove(item);
            }

            return viewModels;
        }

        private List<File_Board_PS> GetFile_Board_PSList(IGrouping<string, EditProceedingSession> list, List<FileViewModel> files, ProceedingSessionSearchModel searchModel)
        {
            var file_PSList = new List<File_Board_PS>();

            foreach (var item in list.ToList())
            { 
                var board = _boardApplication.GetDetails(item.Board_Id);

                if (searchModel.Board.BoardType_Id != 0 && board.BoardType_Id != searchModel.Board.BoardType_Id)
                    continue;

                if (searchModel.Board.BoardChairman != null && !board.BoardChairman.Contains(searchModel.Board.BoardChairman))
                    continue;

                var file = _fileRepository.Search(new FileSearchModel { Id = board.File_Id }).FirstOrDefault();
                file = _fileApplication.GetFileDetails(file);

                if (files.Where(x => x.Id == file.Id).Any())
                {
                    file_PSList.Add(new File_Board_PS
                    {
                        File = file,
                        Board = board,
                        Session = item
                    });
                }
            }

            return file_PSList;
        }

        private string[] CreateFrom_ToDate(ProceedingSessionSearchModel searchModel)
        {
            var result = new string[2];

            if (searchModel.Year == 0 && searchModel.Month == 0 && searchModel.Day == 0)
            {
                result[0] = PersianDateTime.Now.Date.ToString();
                result[1] = null;

                return result;
            }

            else if (searchModel.Year != 0 && searchModel.Month == 0 && searchModel.Day == 0)
            {
                var date = PersianDateTime.Parse(searchModel.Year + "/01/01");

                result[0] = date.ToString();
                result[1] = date.GetPersianDateOfLastDayOfYear().ToString();

                return result;
            }

            else if (searchModel.Year != 0 && searchModel.Month != 0 && searchModel.Day == 0)
            {
                var date = PersianDateTime.Parse(searchModel.Year + "/" + searchModel.Month + "/01");

                result[0] = date.ToString();
                result[1] = date.GetPersianDateOfLastDayOfMonth().ToString();

                return result;
            }

            else if (searchModel.Year != 0 && searchModel.Month != 0 && searchModel.Day != 0)
            {
                var date = PersianDateTime.Parse(searchModel.Year + "/" + searchModel.Month + "/" + searchModel.Day);

                result[0] = date.ToString();
                result[1] = date.ToString();

                return result;
            }

            return null;
        }
    }
}
