using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.YearlySalaryAgg;
using Company.Domain.YearlySalaryItemsAgg;
using CompanyManagment.App.Contracts.YearlySalary;
using CompanyManagment.App.Contracts.YearlySalaryItems;

namespace CompanyManagment.EFCore.Repository
{
    public class YearlySalaryItemRepository : RepositoryBase<long, YearlySalaryItem>, IYearlySalaryItemRepository
    {
        private readonly CompanyContext _context;

        public YearlySalaryItemRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditYearlySalaryItem GetDetails(long id)
        {
            return _context.YearlySalaryItems.Select(x => new EditYearlySalaryItem
                {
                    Id = x.id,
                    ItemName = x.ItemName,
                    ItemValue = x.ItemValue,
                    ValueType = x.ValueType,
                    ParentConnectionId = x.ParentConnectionId,
                    YearlySalaryId = x.YearlySalaryId,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<YearlysalaryItemViewModel> GetItems(int parentalConnectionId)
        {
            return _context.YearlySalaryItems.Select(x => new YearlysalaryItemViewModel
            {
                Id = x.id,

                ItemName = x.ItemName,
                ItemValue = x.ItemValue,
                ValueType = x.ValueType,
                ParentConnectionId = x.ParentConnectionId,
                YearlySalaryId = x.YearlySalaryId,


            }).Where(x => x.ParentConnectionId == parentalConnectionId).ToList();
        }

        public List<YearlysalaryItemViewModel> Search(YearlySalaryItemSearchModel searchModel2)
        {
            var query = _context.YearlySalaryItems.Select(x => new YearlysalaryItemViewModel
            {
                Id = x.id,
                ItemName = x.ItemName,
                ItemValue = x.ItemValue,
                ValueType = x.ValueType,
                ParentConnectionId = x.ParentConnectionId,
                YearlySalaryId = x.YearlySalaryId,
            });
            if (!string.IsNullOrWhiteSpace(searchModel2.ItemName))
                query = query.Where(x => x.ItemName.Contains(searchModel2.ItemName));
          
           



            return query.OrderBy(x => x.Id).ToList();
        }
    }
    
}
