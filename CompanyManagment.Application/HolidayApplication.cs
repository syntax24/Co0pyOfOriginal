using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.HolidayAgg;
using Company.Domain.HolidayItemAgg;
using CompanyManagment.App.Contracts.Holiday;
using CompanyManagment.App.Contracts.HolidayItem;

namespace CompanyManagment.Application
{
    public class HolidayApplication : IHolidayApplication 
    {
        private readonly IHolidayRepository _holidayRepository;
        private readonly IHolidayItemApplication _holidayItemApplication;
        private readonly IHolidayItemRepository _holidayItemRepository;

        public HolidayApplication(IHolidayRepository holidayRepository, IHolidayItemApplication holidayItemApplication, IHolidayItemRepository holidayItemRepository)
        {
            _holidayRepository = holidayRepository;
            _holidayItemApplication = holidayItemApplication;
            _holidayItemRepository = holidayItemRepository;
        }

        public OperationResult Create(CreateHoliday command)
        {
            var operation = new OperationResult();
            if (_holidayRepository.Exists(x => x.Year == command.Year))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            var holiday = new Holiday(command.Year);
            _holidayRepository.Create(holiday);
            _holidayRepository.SaveChanges();

            foreach (var item in command.PersiandatesList)
            {

                var holidayItems = new CreateHolidayItem
                {
                   HolidayYear = holiday.Year,
                   HolidayId = holiday.id,
                   Holidaydate = item,
                };

                _holidayItemApplication.Create(holidayItems);
            }
           
            return operation.Succcedded();
        }

        public OperationResult Edit(EditHoliday command)
        {
            var operation = new OperationResult();
            var holidayEdit = _holidayRepository.Get(command.Id);
            if (holidayEdit == null)
                operation.Failed("رکورد مورد نظر وجود ندارد");

            if (_holidayRepository.Exists(x => x.Year == command.Year && x.id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            holidayEdit.Edit(command.Year);
            _holidayRepository.SaveChanges();
            _holidayItemRepository.RemoveItems(command.Year);
            foreach (var item in command.PersiandatesList)
            {

                var holidayItems = new CreateHolidayItem
                {
                    HolidayYear = command.Year,
                    HolidayId = command.Id,
                    Holidaydate = item,
                };

                _holidayItemApplication.Create(holidayItems);
            }
            return operation.Succcedded();
        }

        public EditHoliday GetDetails(long id)
        {
            return _holidayRepository.GetDetails(id);
        }

        public List<HolidayViewModel> GetHoliday()
        {
            return _holidayRepository.GetHoliday();
        }

        public List<HolidayViewModel> Search(HolidaySearchModel searchModel)
        {
            return _holidayRepository.Search(searchModel);
        }
    }
}
