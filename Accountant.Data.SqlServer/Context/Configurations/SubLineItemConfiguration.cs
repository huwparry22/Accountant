using Accountant.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accountant.Data.SqlServer.Context.Configurations
{
    internal class SubLineItemConfiguration : IEntityTypeConfiguration<SubLineItem>
    {
        public void Configure(EntityTypeBuilder<SubLineItem> builder)
        {
            builder.ToTable("SubLineItem");

            builder.HasKey(ei => ei.SubLineItemId);
            builder.Property(ei => ei.SubLineItemId).UseIdentityColumn();

            builder.HasOne<LineItem>().WithMany().HasForeignKey(ei => ei.LineItemId);

            builder.Property(ei => ei.SubLineItemTypeId).HasConversion<int>();
        }
    }
}
