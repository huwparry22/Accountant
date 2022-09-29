using Accountant.Data.Entities;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Data.SqlServer.EntityProviders
{
    public class LineItemProvider : EntityProvider<LineItem>, ILineItemProvider
    {
        public LineItemProvider(AccountantContext accountantContext) : base(accountantContext) { }

        public async Task<LineItem> GetByLineItemIdAsync(int lineItemId)
        {
            return await _accountantContext
                .LineItems
                .SingleOrDefaultAsync(li => li.LineItemId == lineItemId)
                .ConfigureAwait(false);
        }
    }
}
