using Accountant.API.Models.Requests.LineItem;
using Accountant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.Core.Interfaces
{
    public interface ILineItemMapper
    {
        LineItem MapToLineItem(CreateLineItemRequest createLineItemRequest);
    }
}
