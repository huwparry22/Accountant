using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Processes.LineItem;
using Accountant.Core.Interfaces;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Processes.LineItem
{
    public class CreateLineItemProcessTests
    {
        private readonly CreateLineItemProcess _objectToTest;

        private readonly Mock<IValidator<CreateLineItemRequest>> _mockValidator;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<ILineItemLogic> _mockLineItemLogic;

        public CreateLineItemProcessTests()
        {
            _mockValidator = new Mock<IValidator<CreateLineItemRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockLineItemLogic = new Mock<ILineItemLogic>();

            _objectToTest = new CreateLineItemProcess(
                _mockValidator.Object,
                _mockValidationResultMapper.Object,
                _mockLineItemLogic.Object);
        }
    }
}
