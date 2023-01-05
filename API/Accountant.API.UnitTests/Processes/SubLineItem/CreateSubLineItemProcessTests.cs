using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Core.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Accountant.API.Processes.SubLineItem;

namespace Accountant.API.UnitTests.Processes.SubLineItem
{
    public class CreateSubLineItemProcessTests
    {
        private readonly Mock<IValidator<CreateSubLineItemRequest>> _mockValidator;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<ISubLineItemLogic> _mockSubLineItemLogic;

        private readonly CreateSubLineItemProcess _objectToTest;

        public CreateSubLineItemProcessTests()
        {
            _mockValidator = new Mock<IValidator<CreateSubLineItemRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockSubLineItemLogic = new Mock<ISubLineItemLogic>();

            _objectToTest = new CreateSubLineItemProcess(_mockValidator.Object, _mockValidationResultMapper.Object, _mockSubLineItemLogic.Object);
        }
    }
}
