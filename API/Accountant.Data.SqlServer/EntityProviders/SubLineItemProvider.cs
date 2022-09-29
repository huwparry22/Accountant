using Accountant.Data.Entities;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Data.SqlServer.EntityProviders
{
    public class SubLineItemProvider : EntityProvider<SubLineItem>, ISubLineItemProvider
    {
        public SubLineItemProvider(AccountantContext accountantContext) : base(accountantContext) { }

        public async Task<SubLineItem> GetBySubLineItemIdAsync(int subLineItemId)
        {
            return await _accountantContext
                .SubLineItems
                .SingleOrDefaultAsync(sli => sli.SubLineItemId == subLineItemId)
                .ConfigureAwait(false);
        }
    }
}
