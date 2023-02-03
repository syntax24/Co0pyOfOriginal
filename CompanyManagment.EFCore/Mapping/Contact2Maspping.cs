
using Company.Domain.Contact2Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace CompanyManagment.EFCore.Mapping
{
    public class Contact2Maspping : IEntityTypeConfiguration<EntityContact>
    {
        public void Configure(EntityTypeBuilder<EntityContact> builder)
        {
            builder.ToTable("TextManager_Contact");
            builder.HasKey(x => x.id);
            builder.Property(x => x.NameContact);
 

        }
    }
}