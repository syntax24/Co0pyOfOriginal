using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.JobAgg;
using CompanyManagment.App.Contracts.Job;

namespace CompanyManagment.Application
{
    public class JobApplication : IJobApplication
    {
        private readonly IJobRepository _jobRepository;

        public JobApplication(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public OperationResult Create(CreateJob command)
        {
            var operation = new OperationResult();
            if (_jobRepository.Exists(x =>
                x.JobName == command.JobName || x.JobCode == command.JobCode))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            var job = new Job(command.JobName, command.JobCode);
            _jobRepository.Create(job);
            _jobRepository.SaveChanges();

            return operation.Succcedded();
        }

        public OperationResult Edit(EditJob command)
        {
            var operation = new OperationResult();
            var jobEdit = _jobRepository.Get(command.Id);
            if (jobEdit == null)
                operation.Failed("رکورد مورد نظر وجود ندارد");

            if (_jobRepository.Exists(x => x.JobName == command.JobName  && x.id != command.Id))
                return operation.Failed(" شغل وارد شده تکراری است");
            if (_jobRepository.Exists(x => x.JobCode == command.JobCode && x.id != command.Id))
                return operation.Failed(" کد شغل وارد شده تکراری است");
            jobEdit.Edit(command.JobName,command.JobCode);
            _jobRepository.SaveChanges();


            return operation.Succcedded();
        }

        public EditJob GetDetails(long id)
        {
            return _jobRepository.GetDetails(id);
        }

        public List<JobViewModel> GetJob()
        {
            return _jobRepository.GetJob();
        }

        public List<JobViewModel> Search(JobSearchModel searchModel)
        {
            return _jobRepository.Search(searchModel);
        }
    }
}
