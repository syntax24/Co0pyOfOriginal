using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;
using CompanyManagment.App.Contracts.CrossJob;
using CompanyManagment.App.Contracts.CrossJobGuild;
using CompanyManagment.App.Contracts.CrossJobItems;
using CompanyManagment.App.Contracts.Job;
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
        public List<CrossJobItemsViewModel> crossJobItems;



        private readonly ICrossJobGuildApplication _crossJobGuildApplication;
        private readonly ICrossJobApplication _crossJobApplication;
        private readonly ICrossJobItemsApplication _crossJobItemsApplication;

        public IndexModel(ICrossJobGuildApplication crossJobGuildApplication,
            ICrossJobApplication crossJobApplication,
            ICrossJobItemsApplication crossJobItemsApplication)
        {
            _crossJobGuildApplication = crossJobGuildApplication;
            _crossJobItemsApplication = crossJobItemsApplication;
            _crossJobApplication = crossJobApplication;
        }


        public void OnGet(CrossJobGuildSearchModel searchModel)
        {
            crossJobGuilds = _crossJobGuildApplication.Search(searchModel);

        }
        public void GetCrossJobs(long id)
        {
            CrossJobSearchModel searchModel = new CrossJobSearchModel();
            searchModel.CrossJobGuildId = id;
            crossJobs = _crossJobApplication.Search(searchModel);

        }
        public void GetCrossJobItems(long id)
        {
            CrossJobItemsSearchModel searchModel = new CrossJobItemsSearchModel();
            searchModel.crossJobId = id;
            crossJobItems = _crossJobItemsApplication.Search(searchModel);

        }


        public IActionResult OnGetCreate()
        {

            CreateCrossJobGuild detail = new CreateCrossJobGuild();
            var deta = _crossJobGuildApplication.GetCrossJobGuild().LastOrDefault();
            detail.jobs = new SelectList(_crossJobGuildApplication.GetJob(), "Id", "JobName");
            if (deta != null)
            {
                detail.Year = deta.Year;
            }
            return Partial("./Create", detail);
        }


        public IActionResult OnPostCreate(CreateCrossJobGuild command)
        {
            #region Validation
            var valid = _crossJobGuildApplication.Validation(command);
            if (valid.IsSuccedded == false)
            {
                return new JsonResult(valid);
            }
            #endregion

            #region Economic String
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
            #endregion

            #region Create CrossJob Guild

            var result = _crossJobGuildApplication.Create(command);
            Thread.Sleep(1000);

            #endregion

            if (result.IsSuccedded)
            {
                var items = command.crossJobsList.Count();

                #region Get New ID Crossob Guild
                var searchModel = new CrossJobGuildSearchModel
                {
                    Title = command.Title,
                    Year = command.Year,
                    EconomicCode = command.EconomicCode
                };
                var query_new_crossjobGuild = _crossJobGuildApplication.Search(searchModel).FirstOrDefault();
                #endregion

                for (int i = 0; i <= items - 1; i++)
                {
                    #region Create_crossJob

                    var new_createCrosJob = new CreateCrossJob
                    {
                        EquivalentRialUnder = command.crossJobsList[i].EquivalentRialUnder,
                        SalaryRatioUnder = command.crossJobsList[i].SalaryRatioUnder,
                        EquivalentRialOver = command.crossJobsList[i].EquivalentRialOver,
                        SalaryRatioOver = command.crossJobsList[i].SalaryRatioOver,
                        CrossJobGuildId = query_new_crossjobGuild.Id
                    };
                    var newRecord_crossJob = _crossJobApplication.CreateBackId(new_createCrosJob);

                    #endregion
                    #region Create new CrossJoItem
                    if (newRecord_crossJob.IsSuccedded)
                    {
                        if (command.crossJobsList[i].jobItems != null)
                            foreach (var newItem in command.crossJobsList[i].jobItems)
                            {
                                var new_CrossJobItems = new CreateCrossJobItems
                                {
                                    crossJobId = newRecord_crossJob.EntityId,
                                    jobId = newItem
                                };
                                var newRecord_crossJobItem = _crossJobItemsApplication.Create(new_CrossJobItems);

                            }
                    }


                    #endregion
                }
            }

            return new JsonResult(result);



        }

        public IActionResult OnGetEdit(long id)
        {
            var detail = _crossJobGuildApplication.GetDetails(id);
            detail.crossJobsList = _crossJobApplication.GetCrossJob(id);
            detail.crossJobItemsList = _crossJobItemsApplication.GetCrossJobItems(id);

            if (!string.IsNullOrWhiteSpace(detail.EconomicCode))
            {
                var economicCodeList = detail.EconomicCode.Split(Separator);
                detail.economicCodeList = economicCodeList.ToList();
            }

            foreach (var item in detail.crossJobsList)
            {

                item.SelectedValues = detail.crossJobItemsList.Where(x => x.crossJobId == item.Id).Select(c => c.jobId).ToList();
            }
            detail.jobs = new SelectList(_crossJobGuildApplication.GetJob(), "Id", "JobName");


            return Partial("Edit", detail);
        }



        public JsonResult OnPostEdit(EditCrossJobGuild command)
        {
            #region Validation
            var valid = _crossJobGuildApplication.Validation(command);
            if (valid.IsSuccedded == false)
            {
                return new JsonResult(valid);
            }
            #endregion

            #region Economic Code
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
            #endregion

            #region Edit Guild
            var result = _crossJobGuildApplication.Edit(command);
            Thread.Sleep(1000);
            #endregion

            #region Remove Row CrossJob




            var searchModelCrossJobs = new CrossJobSearchModel
            {
                CrossJobGuildId = command.Id
            };
            var crossjobList = _crossJobApplication.Search(searchModelCrossJobs).ToList();

            if (crossjobList != null)
            {
                bool flg = false;
                foreach (var oldCrossJob in crossjobList)
                {
                    flg = false;
                    if (command.crossJobsList != null)
                        foreach (var newCrossJob in command.crossJobsList)
                        {
                            if (oldCrossJob.Id == newCrossJob.Id)
                            {
                                flg = true;
                            }

                        }
                    if (flg == false)
                    {
                        var res = _crossJobItemsApplication.RemoveRange(oldCrossJob.Id);
                        if (res.IsSuccedded)
                        {
                            res = _crossJobApplication.Remove(oldCrossJob.Id);
                            if (res.IsSuccedded)
                            {
                                //OK
                            }
                            else
                            {
                                return new JsonResult(res);
                            }
                        }
                        else
                        {
                            return new JsonResult(res);
                        }
                    }
                }
            }
            #endregion

            #region Remove crossJoItem

            foreach (var _cj in command.crossJobsList)
            {
                if (_cj.Id != 0)
                {
                    var _searchItem = new CrossJobItemsSearchModel
                    {
                        crossJobId = _cj.Id,
                    };
                    var _itemResult = _crossJobItemsApplication.Search(_searchItem);

                    if (_itemResult != null)
                        foreach (var oldItems in _itemResult)
                        {
                            bool flg = false;
                            if (_cj.SelectedValues != null)
                                foreach (var NewItems in _cj.SelectedValues)
                                {
                                    if (oldItems.jobId == NewItems)
                                    {
                                        flg = true;
                                    }
                                }
                            if (flg == false)
                            {
                                var Item_res = _crossJobItemsApplication.Remove(oldItems.Id);
                                if (Item_res.IsSuccedded)
                                {

                                }
                                else
                                {
                                    return new JsonResult(Item_res);
                                }
                            }
                            if (_cj.jobItems != null)
                                foreach (var sel in _cj.jobItems)
                                {

                                }
                        }
                }

            }

            #endregion

            if (result.IsSuccedded)
            {
                foreach (var cj in command.crossJobsList)
                {
                    if (cj.Id != 0) //Edit CrossJo
                    {
                        EditCrossJob _editCrossJob = new EditCrossJob()
                        {
                            Id = cj.Id,
                            CrossJobGuildId = command.Id,
                            SalaryRatioOver = cj.SalaryRatioOver,
                            SalaryRatioUnder = cj.SalaryRatioUnder,
                            EquivalentRialOver = cj.EquivalentRialOver,
                            EquivalentRialUnder = cj.EquivalentRialUnder,
                        };
                        _crossJobApplication.Edit(_editCrossJob);
                    }
                    else //new CrossJob
                    {
                        var _createCrossjob = new CreateCrossJob
                        {
                            CrossJobGuildId = command.Id,
                            EquivalentRialUnder = cj.EquivalentRialUnder,
                            SalaryRatioUnder = cj.SalaryRatioUnder,
                            EquivalentRialOver = cj.EquivalentRialOver,
                            SalaryRatioOver = cj.SalaryRatioOver,
                        };
                        var res = _crossJobApplication.CreateBackId(_createCrossjob);
                        cj.Id = res.EntityId;
                    }
                    if (cj.SelectedValues != null)
                        foreach (var sel in cj.SelectedValues)
                        {
                            var searchItem = new CrossJobItemsSearchModel
                            {
                                crossJobId = cj.Id,
                                jobId = sel
                            };
                            var itemResult = _crossJobItemsApplication.Search(searchItem);
                            if (itemResult.Count == 0)
                            {
                                var createItem = new CreateCrossJobItems
                                {
                                    crossJobId = cj.Id,
                                    jobId = sel
                                };
                                var createResult = _crossJobItemsApplication.Create(createItem);
                                if (!createResult.IsSuccedded)
                                {
                                    return new JsonResult(createResult);
                                }
                            }
                        }
                    if (cj.jobItems != null)
                        foreach (var sel in cj.jobItems)
                        {
                            var searchItem = new CrossJobItemsSearchModel
                            {
                                crossJobId = cj.Id,
                                jobId = sel
                            };
                            var itemResult = _crossJobItemsApplication.Search(searchItem);
                            if (itemResult.Count == 0)
                            {
                                var createItem = new CreateCrossJobItems
                                {
                                    crossJobId = cj.Id,
                                    jobId = sel
                                };
                                var createResult = _crossJobItemsApplication.Create(createItem);
                                if (!createResult.IsSuccedded)
                                {
                                    return new JsonResult(createResult);
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
            detail.crossJobItemsList = _crossJobItemsApplication.GetCrossJobItems(id);
            if (!string.IsNullOrWhiteSpace(detail.EconomicCode))
            {
                var economicCodeList = detail.EconomicCode.Split(Separator);
                detail.economicCodeList = economicCodeList.ToList();
            }
            return Partial("Details", detail);
        }

        public IActionResult OnPostRemove(long id)
        {
            var result = new OperationResult();
            var searchModel = new CrossJobSearchModel
            {
                CrossJobGuildId = id
            };
            var query_crossJob = _crossJobApplication.Search(searchModel);
            foreach (var op in query_crossJob)
            {
                var searchModel_crossJobItem = new CrossJobItemsSearchModel
                {
                    crossJobId = op.Id
                };
                var items = _crossJobItemsApplication.Search(searchModel_crossJobItem);
                var res = _crossJobItemsApplication.RemoveRange(op.Id);
                if (!res.IsSuccedded)
                {
                    return new JsonResult(res);
                }

            }
            if (query_crossJob.Count > 0)
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

        public JsonResult OnGetJob(long id)
        {
            var res = _crossJobGuildApplication.GetJob();
            return new JsonResult(res);
        }



    }

}
