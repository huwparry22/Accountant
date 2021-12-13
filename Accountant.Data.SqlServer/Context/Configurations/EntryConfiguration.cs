using Accountant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountant.Data.SqlServer.Context.Configurations
{
    internal class EntryConfiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.ToTable("Entry");

            builder.HasKey(e => e.EntryId);
            builder.Property(e => e.EntryId).UseIdentityColumn();

            builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
