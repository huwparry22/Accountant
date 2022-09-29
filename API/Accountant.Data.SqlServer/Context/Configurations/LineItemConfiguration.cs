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

            builder.HasKey(li => li.LineItemId);
            builder.Property(li => li.LineItemId).UseIdentityColumn();

            builder.HasOne<User>().WithMany().HasForeignKey(li => li.UserId);
        }
    }
}
