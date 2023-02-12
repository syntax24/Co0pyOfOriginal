
using Company.Domain.Evidence;
using Company.Domain.Petition;
using Company.Domain.TaskTitle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class TaskTitleMapping : IEntityTypeConfiguration<TaskTitle>
    {
        public void Configure(EntityTypeBuilder<TaskTitle> builder)
        {
            builder.ToTable("TaskTitles");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasMany(x => x.TasksList).WithOne(x => x.TaskTitle).HasForeignKey(x => x.TaskTitle_Id);
        }
    }
}
