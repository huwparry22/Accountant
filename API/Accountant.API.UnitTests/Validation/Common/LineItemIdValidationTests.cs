using Accountant.API.Validation.Common;
using Accountant.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Validation.Common
{
    public class LineItemIdValidationTests
    {
        private readonly Mock<ILineItemLogic> _mockLineItemLogic;

        private readonly LineItemIdValidation _objectToTest;

        public LineItemIdValidationTests()
        {
            _mockLineItemLogic = new Mock<ILineItemLogic>();
            
            _objectToTest = new LineItemIdValidation(_mockLineItemLogic.Object);
        }
    }
}
