using Accountant.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accountant.Data.Entities.Enums;

namespace Accountant.Core.Mappers
{
    public class SubLineItemTypeMapper : ISubLineItemTypeMapper
    {
        public SubLineItemType GetEntitySubLineItemType(API.Models.Requests.SubLineItemType? subLineItemTypeModel)
        {
            if (subLineItemTypeModel == null)
                throw new ArgumentNullException((nameof(subLineItemTypeModel)));

            switch (subLineItemTypeModel)
            {
                case API.Models.Requests.SubLineItemType.Income:
                    return SubLineItemType.Income;
                case API.Models.Requests.SubLineItemType.Expenditure:
                    return SubLineItemType.Expenditure;
                default:
                    throw new InvalidEnumArgumentException(nameof(subLineItemTypeModel));
            }
        }
    }
}
