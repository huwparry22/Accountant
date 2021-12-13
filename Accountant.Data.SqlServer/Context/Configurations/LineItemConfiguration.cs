using Accountant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountant.Data.SqlServer.Context.Configurations
{
    internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.ToTable("LineItem");

            builder.HasKey(e => e.LineItemId);
            builder.Property(e => e.LineItemId).UseIdentityColumn();

            builder.HasOne<User>().WithMany().HasForeignKey(e => e.UserId);
        }
    }
}
