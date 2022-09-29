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

            builder.HasKey(sli => sli.SubLineItemId);
            builder.Property(sli => sli.SubLineItemId).UseIdentityColumn();

            builder.HasOne<LineItem>().WithMany().HasForeignKey(ei => ei.LineItemId);

            builder.Property(sli => sli.SubLineItemTypeId).HasConversion<int>();
            builder.Property(sli => sli.Amount).HasColumnType("money").HasPrecision(18, 2);
        }
    }
}
