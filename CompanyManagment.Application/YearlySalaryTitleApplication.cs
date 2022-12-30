using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.YearlySalaryItemsAgg;
using Company.Domain.YearlysSalaryTitleAgg;
using CompanyManagment.App.Contracts.YearlySalaryTitles;
using CompanyManagment.EFCore;

namespace CompanyManagment.Application
{
    public class YearlySalaryTitleApplication : IYearlySalaryTitleApplication
    {
        private readonly IYearlySalaryTitleRepository _yearlySalaryTitleRepository;
        private readonly IYearlySalaryItemRepository _yearlySalaryItemRepository;
        private readonly CompanyContext _context;

        public YearlySalaryTitleApplication(IYearlySalaryTitleRepository yearlySalaryTitleRepository, CompanyContext context, IYearlySalaryItemRepository yearlySalaryItemRepository)
        {
            _yearlySalaryTitleRepository = yearlySalaryTitleRepository;
            _context = context;
            _yearlySalaryItemRepository = yearlySalaryItemRepository;
        }

        public OperationResult Create(CreateTitle command)
        {
            var operation = new OperationResult();
            var CreateTitle = new YearlySalaryTitle("مزد روزانه", "کمک هزینه اقلام", "کمک هزینه مسکن",
                "پایه سنوات", "مبلغ مزد ثابت", "درصد مزد ثابت", command.Title7, command.Title8, command.Title9,
                command.Title10);
            _yearlySalaryTitleRepository.Create(CreateTitle);
            _yearlySalaryTitleRepository.SaveChanges();
            return operation.Succcedded();
        }


        public OperationResult Edit(EditTitle command)
        {
           
            var opration = new OperationResult();
            var yearlysalaryedit = _yearlySalaryTitleRepository.Get(command.Id);
            if (yearlysalaryedit == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            var itemcheck7 = _context.YearlySalaryItems.Any(x => x.ItemName == yearlysalaryedit.Title7);
            if (itemcheck7 == true && command.Title7 == null)
                return opration.Failed(" ( "+ yearlysalaryedit.Title7 + " ) "+ " قبلا مقداردهی شده است، شما نمی توانید آن را حذف کنید");
            var itemedit = _context.YearlySalaryItems.Where(x => x.ItemName == yearlysalaryedit.Title7).ToList();
            if (itemcheck7)
            {
                foreach (var items in itemedit)
                {
                    var edititems = _yearlySalaryItemRepository.Get(items.id);
                    edititems.Edit(command.Title7, edititems.ItemValue,edititems.ParentConnectionId, edititems.YearlySalaryId, edititems.ValueType);
                    _yearlySalaryItemRepository.SaveChanges();
                }
            }

            var itemcheck8 = _context.YearlySalaryItems.Any(x => x.ItemName == yearlysalaryedit.Title8);
            if (itemcheck8 == true && command.Title8 == null)
                return opration.Failed(" ( " + yearlysalaryedit.Title8 + " ) " + " قبلا مقداردهی شده است، شما نمی توانید آن را حذف کنید");
            var itemedit8 = _context.YearlySalaryItems.Where(x => x.ItemName == yearlysalaryedit.Title8).ToList();
            if (itemcheck8)
            {
                foreach (var items in itemedit8)
                {
                    var edititems = _yearlySalaryItemRepository.Get(items.id);
                    edititems.Edit(command.Title8, edititems.ItemValue, edititems.ParentConnectionId, edititems.YearlySalaryId, edititems.ValueType);
                    _yearlySalaryItemRepository.SaveChanges();
                }
            }

            var itemcheck9 = _context.YearlySalaryItems.Any(x => x.ItemName == yearlysalaryedit.Title9);
            if (itemcheck9 == true && command.Title9 == null)
                return opration.Failed(" ( " + yearlysalaryedit.Title9 + " ) " + " قبلا مقداردهی شده است، شما نمی توانید آن را حذف کنید");
            var itemedit9 = _context.YearlySalaryItems.Where(x => x.ItemName == yearlysalaryedit.Title9).ToList();
            if (itemcheck9)
            {
                foreach (var items in itemedit9)
                {
                    var edititems = _yearlySalaryItemRepository.Get(items.id);
                    edititems.Edit(command.Title9, edititems.ItemValue, edititems.ParentConnectionId, edititems.YearlySalaryId, edititems.ValueType);
                    _yearlySalaryItemRepository.SaveChanges();
                }
            }

            var itemcheck10 = _context.YearlySalaryItems.Any(x => x.ItemName == yearlysalaryedit.Title10);
            if (itemcheck10 == true && command.Title10 == null)
                return opration.Failed(" ( " + yearlysalaryedit.Title10 + " ) " + " قبلا مقداردهی شده است، شما نمی توانید آن را حذف کنید");
            var itemedit10 = _context.YearlySalaryItems.Where(x => x.ItemName == yearlysalaryedit.Title10).ToList();
            if (itemcheck10)
            {
                foreach (var items in itemedit10)
                {
                    var edititems = _yearlySalaryItemRepository.Get(items.id);
                    edititems.Edit(command.Title10, edititems.ItemValue, edititems.ParentConnectionId, edititems.YearlySalaryId, edititems.ValueType);
                    _yearlySalaryItemRepository.SaveChanges();
                }
            }
            yearlysalaryedit.Edit("مزد روزانه", "کمک هزینه اقلام", "کمک هزینه مسکن",
                "پایه سنوات", "مبلغ مزد ثابت", "درصد مزد ثابت", command.Title7, command.Title8, command.Title9,
                command.Title10);
            _yearlySalaryTitleRepository.SaveChanges();
            return opration.Succcedded();
        }

        public EditTitle GetDetails(long id)
        {
            return _yearlySalaryTitleRepository.GetDetails(id);
        }

        public List<TitleViewModel> Search(TitleSearchModel searchModel)
        {
            return _yearlySalaryTitleRepository.Search(searchModel);
        }
    }
}
