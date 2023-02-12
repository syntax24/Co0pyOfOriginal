using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.TaskTitle;
using CompanyManagment.App.Contracts.TaskTitle;


namespace CompanyManagment.EFCore.Repository
{
    public class TaskTitleRepository : RepositoryBase<long, TaskTitle>, ITaskTitleRepository
    {
        private readonly CompanyContext _context;
        public TaskTitleRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditTaskTitle GetDetails(long id)
        {
            return _context.TaskTitles.Select(x => new EditTaskTitle 
            { 
                Id = x.id,
                Title = x.Title
            }).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
        }

        public List<TaskTitleViewModel> Search(TaskTitleSearchModel searchModel)
        {
            var query = _context.TaskTitles.Select(x => new TaskTitleViewModel
            {
                Id = x.id,
                Title = x.Title
            });

            //TODO if
            //if(!string.IsNullOrEmpty(searchModel.PetitionIssuanceDate))
            //{
            //    query = query.Where(x => x.PetitionIssuanceDate == searchModel.PetitionIssuanceDate);
            //}

            //if(!string.IsNullOrEmpty(searchModel.NotificationPetitionDate))
            //{
            //    query = query.Where(x => x.NotificationPetitionDate == searchModel.NotificationPetitionDate);
            //}

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
