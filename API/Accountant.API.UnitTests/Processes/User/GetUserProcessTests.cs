using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Processes.User;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Processes.User
{
    public class GetUserProcessTests
    {
        private readonly Mock<IValidator<GetUserRequest>> _mockGetUserValidation;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;

        private readonly GetUserProcess _objectToTest;

        public GetUserProcessTests()
        {
            _mockGetUserValidation = new Mock<IValidator<GetUserRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();

            _objectToTest = new GetUserProcess(_mockGetUserValidation.Object, _mockValidationResultMapper.Object);
        }
    }
}
