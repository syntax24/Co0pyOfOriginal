using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.TaskStatus;
using CompanyManagment.App.Contracts.TaskStatus;


namespace CompanyManagment.EFCore.Repository
{
    public class TaskStatusRepository : RepositoryBase<long, TaskStatus>, ITaskStatusRepository
    {
        private readonly CompanyContext _context;
        public TaskStatusRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditTaskStatus GetDetails(long id)
        {
            return null;
        }

        public EditTaskStatus GetDetails(long fileId, int boardTypeId)
        {
            return null;
        }

        public void Remove(long id)
        {
        }

        public List<EditTaskStatus> Search(TaskStatusSearchModel searchModel)
        {
            var query = _context.TaskStatuses.Select(x => new EditTaskStatus
            {
                Id = x.id,
                ReferralStatus = x.ReferralStatus,
                ReferralUserId = x.ReferralUserId,
                ReferralRegDate = x.ReferralRegDate,
                ReferralRegUserId = x.ReferralRegUserId,
                DeadlineExtentionStatus = x.DeadlineExtentionStatus,
                DeadlineExtentionDate = x.DeadlineExtentionDate,
                DeadlineExtentionRegDate = x.DeadlineExtentionDate,
                DeadlineExtentionRegUserId = x.DeadlineExtentionRegUserId,
                ImpossibilityStatus = x.ImpossibilityStatus,
                ImpossibilityDescription = x.ImpossibilityDescription,
                ImpossibilityRegDate = x.ImpossibilityRegDate,
                ImpossibilityRegUserId = x.ImpossibilityRegUserId,
                DoneStatus = x.DoneStatus,
                DoneRegDate = x.DoneRegDate,
                DoneRegUserId = x.DoneRegUserId,
                Task_Id = x.Task_Id
            });

            if (searchModel.TaskId != 0)
            {
                query = query.Where(x => x.Task_Id == searchModel.TaskId);
            }

            return query.ToList();

        }

        public void CreateOrUpdateTaskStatus(EditTaskStatus editTaskStatus)
        {
            if (editTaskStatus.Id == 0)
            {
                var taskStatus = new TaskStatus
                (
                    editTaskStatus.ReferralStatus,
                    editTaskStatus.ReferralUserId,
                    editTaskStatus.ReferralRegDate,
                    editTaskStatus.ReferralRegUserId,
                    editTaskStatus.DeadlineExtentionStatus,
                    editTaskStatus.DeadlineExtentionDate,
                    editTaskStatus.DeadlineExtentionRegDate,
                    editTaskStatus.DeadlineExtentionRegUserId,
                    editTaskStatus.ImpossibilityStatus,
                    editTaskStatus.ImpossibilityDescription,
                    editTaskStatus.ImpossibilityRegDate,
                    editTaskStatus.ImpossibilityRegUserId,
                    editTaskStatus.DoneStatus,
                    editTaskStatus.DoneRegDate,
                    editTaskStatus.DoneRegUserId,
                    editTaskStatus.Task_Id
                );

                Create(taskStatus);
            }
            else
            {
                var savedTaskStatus = Get(editTaskStatus.Id);

                savedTaskStatus.Edit
                (
                    editTaskStatus.ReferralStatus,
                    editTaskStatus.ReferralUserId,
                    editTaskStatus.ReferralRegDate,
                    editTaskStatus.ReferralRegUserId,
                    editTaskStatus.DeadlineExtentionStatus,
                    editTaskStatus.DeadlineExtentionDate,
                    editTaskStatus.DeadlineExtentionRegDate,
                    editTaskStatus.DeadlineExtentionRegUserId,
                    editTaskStatus.ImpossibilityStatus,
                    editTaskStatus.ImpossibilityDescription,
                    editTaskStatus.ImpossibilityRegDate,
                    editTaskStatus.ImpossibilityRegUserId,
                    editTaskStatus.DoneStatus,
                    editTaskStatus.DoneRegDate,
                    editTaskStatus.DoneRegUserId,
                    editTaskStatus.Task_Id
                );
            }
            SaveChanges();    
        }
    }
}
