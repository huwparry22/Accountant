using Accountant.API.Models.Requests.LineItem;
using Accountant.Core.Interfaces;
using Accountant.Data.EntityProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
