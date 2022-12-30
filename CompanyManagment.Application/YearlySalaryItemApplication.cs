using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.YearlySalaryItemsAgg;
using CompanyManagment.App.Contracts.YearlySalaryItems;
using CompanyManagment.EFCore;

namespace CompanyManagment.Application
{
    public class YearlySalaryItemApplication : IYearlySalaryItemApplication
    {
        private readonly IYearlySalaryItemRepository _yearlySalaryItemRepository;
        private readonly CompanyContext _context;

        public YearlySalaryItemApplication(IYearlySalaryItemRepository yearlySalaryItemRepository, CompanyContext context)
        {
            _yearlySalaryItemRepository = yearlySalaryItemRepository;
            _context = context;
        }

        public OperationResult Create(CreateYearlySalaryItem command)
        {
            bool ok = false;
            var opration = new OperationResult();
            var ress = _context.YearlySalaries.SingleOrDefault(x => x.ConnectionId == command.ParentConnectionId);
            var parentid = ress.id;
         
                //var itemValue = double.Parse(command.ItemValue);
                var items = new YearlySalaryItem(command.ItemName, command.ItemValue, command.ParentConnectionId, parentid, command.ValueType);
                _yearlySalaryItemRepository.Create(items);
                _yearlySalaryItemRepository.SaveChanges();
                return opration.Succcedded();
        


        }

        public OperationResult Edit(EditYearlySalaryItem command)
        {
            var opration = new OperationResult();
            var edititems = _yearlySalaryItemRepository.Get(command.Id);
            if(edititems==null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            //var itemValue = double.Parse(command.ItemValue);
            edititems.Edit(command.ItemName, command.ItemValue, command.ParentConnectionId,command.YearlySalaryId,command.ValueType);
            _yearlySalaryItemRepository.SaveChanges();
            return opration.Succcedded();
        }

        public EditYearlySalaryItem GetDetails(long id)
        {
           return _yearlySalaryItemRepository.GetDetails(id);
        }

        public List<YearlysalaryItemViewModel> GetItems(int parentalConnectionId)
        {
            return _yearlySalaryItemRepository.GetItems(parentalConnectionId);
        }

        public List<YearlysalaryItemViewModel> Search(YearlySalaryItemSearchModel searchModel2)
        {
            return _yearlySalaryItemRepository.Search(searchModel2);
        }
    }
}
