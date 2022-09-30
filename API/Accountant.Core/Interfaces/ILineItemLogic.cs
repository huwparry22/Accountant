using Accountant.API.Models.Requests.LineItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.Core.Interfaces
{
    public interface ILineItemLogic
    {
        int CreateLineItem(CreateLineItemRequest request);
    }
}
