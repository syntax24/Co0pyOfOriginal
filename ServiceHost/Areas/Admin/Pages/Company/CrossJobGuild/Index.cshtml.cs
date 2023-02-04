using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobGuild;
using CompanyManagment.EFCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ServiceHost.Areas.Admin.Pages.Company.CrossJobGuild
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private const char Separator = '-';
        public CrossJobGuildSearchModel searchModel;

        public List<CrossJobGuildViewModel> crossJobGuilds;
        public List<CrossJobViewModel> crossJobs;



        private readonly ICrossJobGuildApplication _crossJobGuildApplication;
        private readonly ICrossJobApplication _crossJobApplication;

        public IndexModel(ICrossJobGuildApplication crossJobGuildApplication, ICrossJobApplication crossJobApplication)
        {
            _crossJobGuildApplication = crossJobGuildApplication;
            _crossJobApplication = crossJobApplication;
        }


        public void OnGet(CrossJobGuildSearchModel searchModel)
        {
            //crossJobs = _crossJobApplication.Search(searchModel);
            crossJobGuilds = _crossJobGuildApplication.Search(searchModel);

        }
        public void GetCrossJobs(long id)
        {
            CrossJobSearchModel searchModel = new CrossJobSearchModel();
            searchModel.CrossJobGuildId = id;
            //CrossJobGuildSearchModel searchModel = new CrossJobGuildSearchModel();
            //searchModel.id = id;
            crossJobs = _crossJobApplication.Search(searchModel);

        }



        public IActionResult OnGetCreate()
        {

            return Partial("./Create");
        }


        public IActionResult OnPostCreate(CreateCrossJobGuild command)
        {
            var valid = _crossJobGuildApplication.Validation(command);
            if (valid.IsSuccedded == false)
            {
                return new JsonResult(valid);
            }
            var items = command.crossJobsList.Count();
            string economicString = "";
            foreach (var item in command.economicCodeList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    economicString += "-" + item;
                }
            }
            if (economicString.Length > 2)
            {
                command.EconomicCode = economicString.Substring(1);
            }
            var result = _crossJobGuildApplication.Create(command);

            Thread.Sleep(1000);


            if (result.IsSuccedded)
            {
                var searchModel = new CrossJobGuildSearchModel
                {
                    Title = command.Title,
                    Year = command.Year,
                    EconomicCode = command.EconomicCode
                };


                var query = _crossJobGuildApplication.Search(searchModel).FirstOrDefault();

                for (int i = 0; i <= items - 1; i++)
                {
                    long parentRowId = 0;
                    string[] arr = command.crossJobsList[i].Title.Split("-");
                    foreach (var itemTitle in arr)
                    {
                        if (!string.IsNullOrWhiteSpace(itemTitle))
                        {
                            var item = new CreateCrossJob
                            {
                                Title = itemTitle, //command.crossJobsList[i].Title,
                                EquivalentRialUnder = command.crossJobsList[i].EquivalentRialUnder,
                                SalaryRatioUnder = command.crossJobsList[i].SalaryRatioUnder,
                                EquivalentRialOver = command.crossJobsList[i].EquivalentRialOver,
                                SalaryRatioOver = command.crossJobsList[i].SalaryRatioOver,
                                CrossJobGuildId = query.Id,
                                parentRowId = parentRowId
                            };
                            _crossJobApplication.Create(item);
                            if (parentRowId == 0)
                            {
                                // Get Id parent row crossJob
                                var searchModelCrossJob = new CrossJobSearchModel
                                {
                                    Title = itemTitle,
                                    EquivalentRialUnder = command.crossJobsList[i].EquivalentRialUnder,
                                    SalaryRatioUnder = command.crossJobsList[i].SalaryRatioUnder,
                                    EquivalentRialOver = command.crossJobsList[i].EquivalentRialOver,
                                    SalaryRatioOver = command.crossJobsList[i].SalaryRatioOver,
                                    CrossJobGuildId = query.Id,
                                    parentRowId = parentRowId
                                };
                                var res = _crossJobApplication.Search(searchModelCrossJob).FirstOrDefault();
                                parentRowId = res.Id;
                            }
                        }
                    }
                }
            }

            return new JsonResult(result);



        }

        public IActionResult OnGetEdit(long id)
        {
            var detail = _crossJobGuildApplication.GetDetails(id);
            detail.crossJobsListParent = _crossJobApplication.GetCrossJob(id);
            if (!string.IsNullOrWhiteSpace(detail.EconomicCode))
            {
                var economicCodeList = detail.EconomicCode.Split(Separator);
                detail.economicCodeList = economicCodeList.ToList();
            }
            detail.crossJobsList = detail.crossJobsListParent.Where(x => x.parentRowId == 0).ToList();

            return Partial("Edit", detail);
        }



        public JsonResult OnPostEdit(EditCrossJobGuild command)
        {
            var valid = _crossJobGuildApplication.Validation(command);
            if (valid.IsSuccedded == false)
            {
                return new JsonResult(valid);
            }
            if (ModelState.IsValid)
            {
            }
            string economicString = "";
            foreach (var item in command.economicCodeList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    economicString += "-" + item;
                }
            }
            if (economicString.Length > 2)
            {
                command.EconomicCode = economicString.Substring(1);
            }
            var result = _crossJobGuildApplication.Edit(command);
            Thread.Sleep(1000);
            if (result.IsSuccedded)
            {


                //----------------------------------
                // remove CrossJob
                // Get All crossJob By CrossJobGuildId
                var searchModelCrossJobs = new CrossJobSearchModel
                {
                    CrossJobGuildId = command.Id
                };
                var jobList = _crossJobApplication.Search(searchModelCrossJobs).ToList();
                foreach (var jo in jobList)
                {
                    if (jo.parentRowId == 0)
                    {
                        bool flg = false;
                        foreach (var newJo in command.crossJobsList)
                        {
                            if (jo.Id == newJo.Id)
                            {
                                flg = true;
                            }
                        }
                        if (flg == false)
                        {
                            try
                            {

                                var searchModelCrossJobsParent = new CrossJobSearchModel
                                {
                                    parentRowId = jo.Id
                                };
                                var jobListParent = _crossJobApplication.Search(searchModelCrossJobsParent).ToList();
                                foreach (var parent in jobListParent)
                                {
                                    _crossJobApplication.Remove(parent.Id);

                                }
                                _crossJobApplication.Remove(jo.Id);

                            }
                            catch (System.Exception)
                            {

                            }
                        }
                    }
                }
                //----------------------------------

                foreach (var item in command.crossJobsList)
                {
                    long parentRowId = 0;

                    string[] arr = item.Title.Split("-");
                    foreach (var itemTitle in arr)
                    {
                        if (!string.IsNullOrWhiteSpace(itemTitle))
                        {
                            bool newItem = false;

                            // Get Id parent row crossJob
                            var searchModelCrossJob = new CrossJobSearchModel
                            {
                                Title = itemTitle,
                                //EquivalentRialUnder = item.EquivalentRialUnder,
                                //SalaryRatioUnder = item.SalaryRatioUnder,
                                //EquivalentRialOver = item.EquivalentRialOver,
                                //SalaryRatioOver = item.SalaryRatioOver,
                                CrossJobGuildId = command.Id,
                                parentRowId = parentRowId
                            };
                            var res = _crossJobApplication.Search(searchModelCrossJob).FirstOrDefault();
                            if (res != null)
                            {
                                parentRowId = res.Id;

                            }
                            else
                            {
                                newItem = true;
                            }

                            if (item.Id == 0 || newItem)  //Create
                            {
                                var crossjob = new CreateCrossJob
                                {
                                    CrossJobGuildId = command.Id,
                                    Title = itemTitle,
                                    EquivalentRialUnder = item.EquivalentRialUnder,
                                    SalaryRatioUnder = item.SalaryRatioUnder,
                                    EquivalentRialOver = item.EquivalentRialOver,
                                    SalaryRatioOver = item.SalaryRatioOver,
                                    parentRowId = parentRowId
                                };
                                _crossJobApplication.Create(crossjob);
                                newItem = false;
                                if (parentRowId == 0)
                                {
                                    // Get Id parent row crossJob
                                    var searchModelCr = new CrossJobSearchModel
                                    {
                                        CrossJobGuildId = command.Id,
                                        Title = itemTitle,
                                        EquivalentRialUnder = item.EquivalentRialUnder,
                                        SalaryRatioUnder = item.SalaryRatioUnder,
                                        EquivalentRialOver = item.EquivalentRialOver,
                                        SalaryRatioOver = item.SalaryRatioOver,
                                        parentRowId = parentRowId
                                    };
                                    var rest = _crossJobApplication.Search(searchModelCr).FirstOrDefault();
                                    parentRowId = rest.Id;
                                }
                            }
                            else //Edit
                            {
                                var crossjob = new EditCrossJob
                                {
                                    Id = item.Id,
                                    CrossJobGuildId = command.Id,
                                    Title = itemTitle,
                                    EquivalentRialUnder = item.EquivalentRialUnder,
                                    SalaryRatioUnder = item.SalaryRatioUnder,
                                    EquivalentRialOver = item.EquivalentRialOver,
                                    SalaryRatioOver = item.SalaryRatioOver,
                                    parentRowId = item.Id == parentRowId ? 0 : parentRowId
                                };
                                _crossJobApplication.Edit(crossjob);

                            }

                        }
                    }



                }
            }
            return new JsonResult(result);


        }

        public IActionResult OnGetDetails(long id)
        {
            var detail = _crossJobGuildApplication.GetDetails(id);
            detail.crossJobsList = _crossJobApplication.GetCrossJob(id);
            if (!string.IsNullOrWhiteSpace(detail.EconomicCode))
            {
                var economicCodeList = detail.EconomicCode.Split(Separator);
                detail.economicCodeList = economicCodeList.ToList();
            }
            detail.crossJobsListParent = detail.crossJobsList.Where(x => x.parentRowId == 0).ToList();
            return Partial("Details", detail);
        }

        public IActionResult OnPostRemove(long id)
        {
            var result = new OperationResult();
            var searchModel = new CrossJobSearchModel
            {
                CrossJobGuildId = id
            };
            var query = _crossJobApplication.Search(searchModel);
            if (query.Count > 0)
            {
                var res = _crossJobApplication.RemoveRange(id);
                if (res.IsSuccedded)
                {
                    result = _crossJobGuildApplication.Remove(id);
                }
                else
                {
                    result = res;
                }
            }
            else
            {
                result = _crossJobGuildApplication.Remove(id);
            }
            return new JsonResult(result);

        }
    }

}
