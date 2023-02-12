
using Company.Domain.Evidence;
using Company.Domain.Petition;
using Company.Domain.Task;
using Company.Domain.TaskStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class TaskStatusMapping : IEntityTypeConfiguration<TaskStatus>
    {
        public void Configure(EntityTypeBuilder<TaskStatus> builder)
        {
            builder.ToTable("TaskStatuses");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.Task).WithOne(x => x.TaskStatus).HasForeignKey<TaskStatus>(x => x.Task_Id);
        }
    }
}
