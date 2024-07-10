using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Core.Interfaces;
using Accountant.Data.EntityProviders;

namespace Accountant.Core.Logic
{
    public class SubLineItemLogic : ISubLineItemLogic
    {
        private readonly ISubLineItemMapper _subLineItemMapper;
        private readonly ISubLineItemProvider _subLineItemProvider;

        public SubLineItemLogic(ISubLineItemMapper subLineItemMapper, ISubLineItemProvider subLineItemProvider)
        {
            _subLineItemMapper = subLineItemMapper;
            _subLineItemProvider = subLineItemProvider;
        }

        public async Task<int> CreateSubLineItem(CreateSubLineItemRequest createSubLineItemRequest)
        {
            var entity = _subLineItemMapper.GetSubLineItem(createSubLineItemRequest);

            await _subLineItemProvider.SaveAsync(entity).ConfigureAwait(false);

            return entity.SubLineItemId;
        }
    }
}
