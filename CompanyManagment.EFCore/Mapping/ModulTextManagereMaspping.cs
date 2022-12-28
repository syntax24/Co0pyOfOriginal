using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Company.Domain.ModuleTextManagerAgg;

namespace CompanyManagment.EFCore.Mapping
{
    public class ModuleTextManagerMaspping : IEntityTypeConfiguration<EntityModuleTextManager>
    {
     
            public void Configure(EntityTypeBuilder<EntityModuleTextManager> builder)
            {
                builder.ToTable("TextManager_ModuleTextManager");
                builder.HasKey(x => new { x.TextManagerId, x.ModuleId });

                builder.HasOne(x => x.TextManager)
                    .WithMany(x => x.EntityModuleTextManagers)
                    .HasForeignKey(x => x.TextManagerId);
                builder.HasOne(x => x.Module)
                    .WithMany(x => x.EntityModuleTextManagers)
                    .HasForeignKey(x => x.ModuleId);
            }

      }
}
