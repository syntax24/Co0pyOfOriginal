using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.HolidayItemAgg;
using CompanyManagment.App.Contracts.HolidayItem;

namespace CompanyManagment.Application
{
    public class HolidayItemApplication : IHolidayItemApplication
    {
        private readonly IHolidayItemRepository _holidayItemRepository;

        public HolidayItemApplication(IHolidayItemRepository holidayItemRepository)
        {
            _holidayItemRepository = holidayItemRepository;
        }

        public OperationResult Create(CreateHolidayItem command)
        {
            var operation = new OperationResult();
            if (_holidayItemRepository.Exists(x =>
                x.Holidaydate == command.Holidaydate.ToGeorgianDateTime() ))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            var holidayDate = command.Holidaydate.ToGeorgianDateTime();
            var createHolidayItem = new HolidayItem(holidayDate, command.HolidayId, command.HolidayYear);
            _holidayItemRepository.Create(createHolidayItem);
            _holidayItemRepository.SaveChanges();
            return operation.Succcedded();
        }

        public OperationResult Edit(EditHolidayItem command)
        {
            var opration = new OperationResult();
            var holidayItem = _holidayItemRepository.Get(command.Id);
            var holidayDate = command.Holidaydate.ToGeorgianDateTime();
            holidayItem.Edit(holidayDate, command.HolidayId, command.HolidayYear);
            _holidayItemRepository.SaveChanges();

            return opration.Succcedded();
        }

        public EditHolidayItem GetDetails(long id)
        {
            return _holidayItemRepository.GetDetails(id);
        }

        public List<string> GetHolidayItem(string year)
        {
            return _holidayItemRepository.GetHolidayItem(year);
        }

        public bool GetHoliday(DateTime holidayCheck)
        {
            return _holidayItemRepository.GetHoliday(holidayCheck);
        }

        public List<HolidayItemViewModel> Search(HolidayItemSearchModel searchModel)
        {
            return _holidayItemRepository.Search(searchModel);
        }
    }
}
