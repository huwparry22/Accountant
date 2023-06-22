using Accountant.API.Models.Requests.User;
using Accountant.API.Validation.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Validation.User
{
    public class CreateUserValidationTests
    {
        private readonly CreateUserValidation _objectToTest;

        public CreateUserValidationTests()
        {
            _objectToTest = new CreateUserValidation();
        }

        public class CreateUserValidationTestData : TheoryData<CreateUserRequest>
        {
            public CreateUserValidationTestData()
            {

            }
        }
    }
}
