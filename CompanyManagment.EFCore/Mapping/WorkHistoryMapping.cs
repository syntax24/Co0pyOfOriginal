using Company.Domain.WorkHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class WorkHistoryMapping : IEntityTypeConfiguration<WorkHistory>
    {
        public void Configure(EntityTypeBuilder<WorkHistory> builder)
        {
            builder.ToTable("WorkHistories");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.Petition).WithMany(x => x.WorkHistoriesList).HasForeignKey(x => x.Petition_Id);
        }
    }
}
