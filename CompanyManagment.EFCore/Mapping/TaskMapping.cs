
using Company.Domain.Evidence;
using Company.Domain.Petition;
using Company.Domain.Task;
using Company.Domain.TaskStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class TaskMapping : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.id);

            //TODO
            //add validations
            
            builder.HasOne(x => x.TaskTitle).WithMany(x => x.TasksList).HasForeignKey(x => x.TaskTitle_Id);
            builder.HasOne(x => x.TaskStatus).WithOne(x => x.Task).HasForeignKey<TaskStatus>(x => x.Task_Id);
        }
    }
}
