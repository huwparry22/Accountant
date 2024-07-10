using Accountant.Data.Entities.Enums;

namespace Accountant.Core.Interfaces
{
    public interface ISubLineItemTypeMapper
    {
        SubLineItemType GetEntitySubLineItemType(API.Models.Requests.SubLineItemType? subLineItemTypeModel);
    }
}
