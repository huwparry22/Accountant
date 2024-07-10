using Accountant.API.Models.Requests.LineItem;
using Accountant.Core.Interfaces;
using Accountant.Data.Entities;
using Accountant.Data.EntityProviders;

namespace Accountant.Core.Logic
{
    public class LineItemLogic : ILineItemLogic
    {
        private readonly ILineItemMapper _lineItemMapper;
        private readonly ILineItemProvider _lineItemProvider;

        public LineItemLogic(ILineItemMapper lineItemMapper, ILineItemProvider lineItemProvider)
        {
            _lineItemMapper = lineItemMapper;
            _lineItemProvider = lineItemProvider;
        }

        public async Task<int> CreateLineItem(CreateLineItemRequest request)
        {
            var entity = _lineItemMapper.MapToLineItem(request);

            await _lineItemProvider.SaveAsync(entity).ConfigureAwait(false);

            return entity.LineItemId;
        }

        public async Task<LineItem> GetLineItemByLineItemId(int lineItemId) => await _lineItemProvider.GetByLineItemIdAsync(lineItemId).ConfigureAwait(false);
    }
}
