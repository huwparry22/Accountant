using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Core.Interfaces;
using Accountant.Data.Entities;

namespace Accountant.Core.Mappers
{
    public class SubLineItemMapper : ISubLineItemMapper
    {
        private readonly ISubLineItemTypeMapper _subLineItemTypeMapper;

        public SubLineItemMapper(ISubLineItemTypeMapper subLineItemTypeMapper)
        {
            _subLineItemTypeMapper = subLineItemTypeMapper;
        }

        public SubLineItem GetSubLineItem(CreateSubLineItemRequest subLineItemRequest)
        {
            if (subLineItemRequest == null)
                throw new ArgumentNullException(nameof(subLineItemRequest));

            if (subLineItemRequest.LineItemId == null)
                throw new ArgumentException(message: $"{nameof(CreateSubLineItemRequest.LineItemId)} property cannot be null", paramName: nameof(subLineItemRequest));

            if (subLineItemRequest.Amount == null)
                throw new ArgumentException(message: $"{nameof(CreateSubLineItemRequest.Amount)} property cannot be null", paramName: nameof(subLineItemRequest));

            return new SubLineItem
            {
                LineItemId = subLineItemRequest.LineItemId.Value,
                Description = subLineItemRequest.Description,
                Amount = subLineItemRequest.Amount.Value,
                SubLineItemTypeId = _subLineItemTypeMapper.GetEntitySubLineItemType(subLineItemRequest.SubLineItemType)
            };
        }
    }
}
