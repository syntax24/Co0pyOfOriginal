using System;
using System.Collections.Generic;

using _0_Framework.InfraStructure;
using CompanyManagment.EFCore;
using _0_Framework.Application;
using CompanyManagment.App.Contracts.CrossJobGuild;
using Company.Domain.CrossJobGuildAgg;
using CompanyManagment.App.Contracts.Job;
using Company.Domain.JobAgg;

namespace CompanyManagment.Application
{
    public class CrossJobGuildApplication : RepositoryBase<long, CrossJobGuild>, ICrossJobGuildApplication
    {
        private readonly ICrossJobGuildRepository _CrossJobGuildRepository;
        private readonly CompanyContext _context;
        public bool nationalCodValid = false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool StatCity = true;
        public bool city = true;
        public bool address = true;

        public CrossJobGuildApplication(ICrossJobGuildRepository crossJobGuildRepository, CompanyContext context) : base(context)
        {
            _context = context;
            _CrossJobGuildRepository = crossJobGuildRepository;
        }

        public OperationResult Create(CreateCrossJobGuild command)
        {
            var opration = new OperationResult();
            if (_CrossJobGuildRepository.Exists(x =>
                x.Year == command.Year && x.Title == command.Title && x.EconomicCode == command.EconomicCode))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            foreach (var it in command.crossJobsList)
            {
                //if (string.IsNullOrWhiteSpace(it.Title))
                //{
                //    return opration.Failed("نام شفل را وارد کنید");
                //}
                if (it.SalaryRatioOver == 0 || it.SalaryRatioUnder == 0 || it.EquivalentRialOver == 0 || it.EquivalentRialUnder == 0)
                {
                    return opration.Failed("لطفا اطلاعات را کامل وارد کنید");
                }
            }


            if (command.Year == 0)
            {
                return opration.Failed("لطفا سال را وارد کنید");
            }

            if (string.IsNullOrWhiteSpace(command.Title))
            {
                nationalCodValid = false;
                return opration.Failed("نام واحد صنفی را وارد کنید");
            }

            var crossJobGuildData = new CrossJobGuild(
                 command.Year, command.Title, command.EconomicCode);

            _CrossJobGuildRepository.Create(crossJobGuildData);
            _CrossJobGuildRepository.SaveChanges();

            return opration.Succcedded();


        }

        public OperationResult Edit(EditCrossJobGuild command)
        {
            var opration = new OperationResult();
            var crossjobGuild = _CrossJobGuildRepository.Get(command.Id);
            if (crossjobGuild == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            //if (_CrossJobGuildRepository.Exists(x =>
            //    x.Year == command.Year && x.Title == command.Title && x.EconomicCode != command.EconomicCode))
            //    return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            if (command.Year == 0)
            {
                return opration.Failed("لطفا سال را وارد کنید");
            }

            if (string.IsNullOrWhiteSpace(command.Title))
            {
                nationalCodValid = false;
                return opration.Failed("نام واحد صنفی را وارد کنید");
            }

            var crossJobGuildData = new CrossJobGuild(
                 command.Year, command.Title, command.EconomicCode);
            crossjobGuild.Edit(command.EconomicCode, command.Title, command.Year);
            _CrossJobGuildRepository.SaveChanges();

            return opration.Succcedded();


        }

        public EditCrossJobGuild GetDetails(long id)
        {
            return _CrossJobGuildRepository.GetDetails(id);
        }

        public List<CrossJobGuildViewModel> GetCrossJobGuild()
        {
            return _CrossJobGuildRepository.GetCrossJobGuild();
        }

        public List<CrossJobGuildViewModel> Search(CrossJobGuildSearchModel searchModel)
        {
            return _CrossJobGuildRepository.Search(searchModel);
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();

            _CrossJobGuildRepository.Remove(id);
            _CrossJobGuildRepository.SaveChanges();

            return operation.Succcedded("عنوان با موفقیت حذف شد");
        }


        public OperationResult Validation(CreateCrossJobGuild command)
        {
            var arr = new List<long>();
            
            var opration = new OperationResult();
            if (_CrossJobGuildRepository.Exists(x =>
                x.Year == command.Year && x.Title == command.Title && x.EconomicCode == command.EconomicCode))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            if (command.crossJobsList == null)
            {
                return opration.Failed("تمام سطرها را نمیتوانید حذف کنید");
            }
            foreach (var it in command.crossJobsList)
            {

                //if (string.IsNullOrWhiteSpace(it.Title))
                //{
                //    return opration.Failed("نام شفل را وارد کنید");
                //}
                if (it.SalaryRatioOver == 0 || it.SalaryRatioUnder == 0 || it.EquivalentRialOver == 0 || it.EquivalentRialUnder == 0)
                {
                    return opration.Failed("لطفا اطلاعات را کامل وارد کنید");
                }
                if (it.jobItems == null && it.SelectedValues == null)
                {
                    return opration.Failed("نام شغل نمیتواند خالی باشد");
                }
                if (it.jobItems != null)
                {
                    foreach (var val in it.jobItems)
                    {
                        arr.Add(val);
                    }
                    //    if( it.jobItems.Length == 0)
                    //        return opration.Failed("لطفا اطلاعات را کامل وارد کنید");

                }
                if (it.SelectedValues != null)
                {
                    //    if (it.SelectedValues.Count == 0)
                    //        return opration.Failed("لطفا اطلاعات را کامل وارد کنید");
                    foreach (var val in it.SelectedValues)
                    {
                        arr.Add(val);
                    }
                }
            }


            var d = new Dictionary<long, int>();
            foreach (var res in arr)
            {
                if (d.ContainsKey(res))
                    d[res]++;
                else
                    d[res] = 1;
            }
            foreach (var val in d)
            {
                if(val.Value > 1)
                {
                    return opration.Failed("یک یا چند شغل تکراری می باشد");

                }
            }



            if (command.Year == 0)
            {
                return opration.Failed("لطفا سال را وارد کنید");
            }

            if (string.IsNullOrWhiteSpace(command.Title))
            {
                return opration.Failed("نام واحد صنفی را وارد کنید");
            }


            return opration.Succcedded();


        }
        public OperationResult ValidationEdit(EditCrossJobGuild command)
        {
            var opration = new OperationResult();
            var arr = new List<long>();

            if (_CrossJobGuildRepository.Exists(x =>
                x.Year == command.Year && x.Title == command.Title && x.EconomicCode == command.EconomicCode))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            foreach (var it in command.crossJobsList)
            {
                //if (string.IsNullOrWhiteSpace(it.Title))
                //{
                //    return opration.Failed("نام شفل را وارد کنید");
                //}
                if (it.SalaryRatioOver == 0 || it.SalaryRatioUnder == 0 || it.EquivalentRialOver == 0 || it.EquivalentRialUnder == 0)
                {
                    return opration.Failed("لطفا اطلاعات را کامل وارد کنید");
                }
                if (it.jobItems == null && it.SelectedValues == null)
                {
                    return opration.Failed("نام شغل نمیتواند خالی باشد");
                }

                if (it.jobItems != null)
                {
                    foreach (var val in it.jobItems)
                    {
                        arr.Add(val);
                    }
                    //    if( it.jobItems.Length == 0)
                    //        return opration.Failed("لطفا اطلاعات را کامل وارد کنید");

                }
                if (it.SelectedValues != null)
                {
                    //    if (it.SelectedValues.Count == 0)
                    //        return opration.Failed("لطفا اطلاعات را کامل وارد کنید");
                    foreach (var val in it.SelectedValues)
                    {
                        arr.Add(val);
                    }
                }


            }

            var d = new Dictionary<long, int>();
            foreach (var res in arr)
            {
                if (d.ContainsKey(res))
                    d[res]++;
                else
                    d[res] = 1;
            }
            foreach (var val in d)
            {
                if (val.Value > 1)
                {
                    return opration.Failed("یک یا چند شغل تکراری می باشد");

                }
            }
            if (command.Year == 0)
            {
                return opration.Failed("لطفا سال را وارد کنید");
            }

            if (string.IsNullOrWhiteSpace(command.Title))
            {
                return opration.Failed("نام واحد صنفی را وارد کنید");
            }


            return opration.Succcedded();


        }

        public List<JobViewModel> GetJob()
        {
            return _CrossJobGuildRepository.GetJob();

        }

    }
}
