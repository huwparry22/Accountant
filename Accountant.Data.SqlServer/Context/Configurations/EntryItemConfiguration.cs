using Accountant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountant.Data.SqlServer.Context.Configurations
{
    internal class EntryItemConfiguration : IEntityTypeConfiguration<EntryItem>
    {
        public void Configure(EntityTypeBuilder<EntryItem> builder)
        {
            builder.ToTable("EntryItem");

            builder.HasKey(ei => ei.EntryItemId);
            builder.Property(ei => ei.EntryItemId).UseIdentityColumn();

            builder.HasOne<Entry>().WithMany().HasForeignKey(ei => ei.EntryId);
        }
    }
}
