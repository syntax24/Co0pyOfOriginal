using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.HolidayItemAgg;
using CompanyManagment.App.Contracts.HolidayItem;

namespace CompanyManagment.EFCore.Repository
{
    public class HolidayItemRepository : RepositoryBase<long, HolidayItem>, IHolidayItemRepository
    {
        private readonly CompanyContext _context;

        public HolidayItemRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<string> GetHolidayItem(string year)
        {
            var items= _context.HolidayItems.Select(x => new HolidayItemViewModel
            {
                Id = x.id,

               
                Holidaydate = x.Holidaydate.ToFarsi(),
                HolidayId = x.HolidayId,
                HolidayYear = x.HolidayYear



            }).Where(x => x.HolidayYear == year).ToList();
            var itemString = new List<string>();
            foreach (var item in items)
            {
                itemString.Add(item.Holidaydate);
            }
            return itemString;
        }

        public void RemoveItems(string year)
        {
            var items = _context.HolidayItems.Where(x => x.HolidayYear == year).ToList();
         
           
            _context.HolidayItems.RemoveRange(items);
            _context.SaveChanges();
        }

        public bool GetHoliday(DateTime holidayCheck)
        {
            var testHoliday = _context.HolidayItems.Any(x => x.Holidaydate == holidayCheck);
            return testHoliday;
        }

        public EditHolidayItem GetDetails(long id)
        {
            return _context.HolidayItems.Select(x => new EditHolidayItem
                {
                    Id = x.id,
                    Holidaydate = x.Holidaydate.ToFarsi(),
                    HolidayId = x.HolidayId,
                    HolidayYear = x.HolidayYear


            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<HolidayItemViewModel> Search(HolidayItemSearchModel searchModel)
        {
           
                var query = _context.HolidayItems.Select(x => new HolidayItemViewModel
                {
                    Id = x.id,
                    Holidaydate = x.Holidaydate.ToFarsi(),
                    HolidayId = x.HolidayId,
                    HolidayYear = x.HolidayYear
                });
                if (!string.IsNullOrWhiteSpace(searchModel.HolidayYear))
                    query = query.Where(x => x.HolidayYear.Contains(searchModel.HolidayYear));



                return query.OrderByDescending(x => x.Id).ToList();
           
        }
    }
}
