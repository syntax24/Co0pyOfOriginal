
using Company.Domain.ModuleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace CompanyManagment.EFCore.Mapping
{
    public class ModuleMaspping : IEntityTypeConfiguration<EntityModule>
    {
        public void Configure(EntityTypeBuilder<EntityModule> builder)
        {
            builder.ToTable("TextManager_Module");
            builder.HasKey(x => x.id);
            builder.Property(x => x.NameSubModule).IsRequired();
 

        }
    }
}