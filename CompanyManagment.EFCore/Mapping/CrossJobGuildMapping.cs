using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.CrossJobGuildAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class CrossJobGuildMapping : IEntityTypeConfiguration<CrossJobGuild>
    {
        public void Configure(EntityTypeBuilder<CrossJobGuild> builder)
        {
            builder.ToTable("CrossJobGuilds");
            builder.HasKey(x => x.id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Year).HasMaxLength(4).IsRequired();
            builder.Property(x => x.EconomicCode).HasMaxLength(255);



            builder.HasMany(x => x.CrossJobList)
                .WithOne(x => x.CrossJobGuild)
                .HasForeignKey(x => x.CrossJobGuildId);


        }

       
    }
}
