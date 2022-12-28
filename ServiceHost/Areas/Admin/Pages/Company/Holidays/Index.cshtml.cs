using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.empolyerAgg;
using Company.Domain.HolidayAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Employer;
using CompanyManagment.App.Contracts.Holiday;
using CompanyManagment.App.Contracts.HolidayItem;
using CompanyManagment.App.Contracts.Job;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using CompanyManagment.App.Contracts.Workshop;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using PersianTools.Core;
using Index = System.Index;

namespace ServiceHost.Areas.Admin.Pages.Company.Holidays    
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData] 
        public string Message { get; set; }
        public HolidaySearchModel searchModel;
        public HolidayItemSearchModel SearchModel2;

        public CreateHoliday h;
        public CreateHoliday m;
        public string years { get; set; }


        public List<HolidayViewModel> holidays;
        public List<HolidayItemViewModel> holidayItems;
        public List<string> _HolidayList;



        private readonly IHolidayApplication _holidayApplication;
        private readonly IHolidayItemApplication _holidayItemApplication;
        private readonly IHolidayRepository _holidayRepository;

        public IndexModel(IHolidayApplication holidayApplication, IHolidayItemApplication holidayItemApplication, IHolidayRepository holidayRepository)
        {
            _holidayApplication = holidayApplication;
            _holidayItemApplication = holidayItemApplication;
            _holidayRepository = holidayRepository;
        }


        public void OnGet(HolidaySearchModel searchModel, HolidayItemSearchModel SearchModel2)
        {

            holidays = _holidayApplication.Search(searchModel);
            holidayItems = _holidayItemApplication.Search(SearchModel2);

        }

    

        public IActionResult OnGetCreate(string years)
        {

            var checkExists = _holidayRepository.Exists(x => x.Year == years);
            if (checkExists)
            {
              

                return Partial("./alert");
            }
            else
            {
                var year = Convert.ToInt32(years);
                var d1 = new PersianDateTime(year, 01, 01);
                var d2 = PersianDateExtensions.ShamsiEndDateTimeOfPersianYear(year);

                var t = new List<string>();
                for (var da = d1; da <= d2; da.AddDays(1))
                {
                    if (da.IsHoliDay == true && da.DayOfWeek != "جمعه")
                    {
                        t.Add(da.ToString());
                    }
                }

                var command = new CreateHoliday
                {
                    PersiandatesList = t,
                    Year = years
                };



                return Partial("./Create", command);
            }
 
        }




        public IActionResult OnPostCreate(CreateHoliday command)
        {
            var test = command.PersiandatesList2;
            var createList = new List<string>();

            for (int i = 0; i <= command.PersiandatesList.Count - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(command.PersiandatesList[i]))
                {
                    createList.Add(command.PersiandatesList[i]);
                }
            }

          
                for (int n = 0; n <= command.PersiandatesList2.Count - 1; n++)
                {
                    if (!string.IsNullOrWhiteSpace(command.PersiandatesList2[n]))
                    {
                        createList.Add(command.PersiandatesList2[n]);
                    }
                }
           
           

            var command1 = new CreateHoliday
            {
                Year = command.Year,
                PersiandatesList = createList
                

            };
            var result = _holidayApplication.Create(command1);
            return new JsonResult(result);



        }

      



        public IActionResult OnGetEdit(long id)
        {
            var editHoliday = _holidayApplication.GetDetails(id);
            editHoliday.PersiandatesList = _holidayItemApplication.GetHolidayItem(editHoliday.Year);

            return Partial("Edit", editHoliday);
        }

 

        public JsonResult OnPostEdit(EditHoliday command)
        {

            if (ModelState.IsValid)
            {

            }

            var createList = new List<string>();

            for (int i = 0; i <= command.PersiandatesList.Count - 1; i++)
            {
                if (!string.IsNullOrWhiteSpace(command.PersiandatesList[i]))
                {
                    createList.Add(command.PersiandatesList[i]);
                }
            }


            for (int n = 0; n <= command.PersiandatesList2.Count - 1; n++)
            {
                if (!string.IsNullOrWhiteSpace(command.PersiandatesList2[n]))
                {
                    createList.Add(command.PersiandatesList2[n]);
                }
            }


            var command1 = new EditHoliday
            {
                Id = command.Id,
                Year = command.Year,
                PersiandatesList = createList


            };
            var result = _holidayApplication.Edit(command1);




            return new JsonResult(result);





        }
 
        public IActionResult OnGetDetails(long id)
        {
            var editHoliday = _holidayApplication.GetDetails(id);

            return Partial("Details", editHoliday);
        }
    


    }

}
