using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Service;

namespace TestBudget.User
{
    [TestFixture]
    public class UserTest
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IValidator<Orcamento.Api.Models.User.User>> _validator;

        public UserTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _validator = new Mock<IValidator<Orcamento.Api.Models.User.User>>();
        }

        [Test]
        public void CreateUser_Ok()
        {
            var userExpected = UserStub._1StubUserOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.User.User>()));
            _userRepository.Setup(c => c.CreateLoginFromContractor(It.IsAny<Orcamento.Api.Models.User.User>(), string.Empty));
            var userObtained = _userRepository.Object.CreateLoginFromContractor(userExpected.Value, "");

            Assert.NotNull(validate);
        }

        [Test]
        public void GetUser_Ok()
        {
            var userExpected = UserStub._1StubUserOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.User.User>()));
            _userRepository.Setup(c => c.GetUser(It.IsAny<Orcamento.Api.Models.User.User>()));
            var userObtained = _userRepository.Object.GetUser(userExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(userObtained.IsSuccess);
            Assert.AreEqual(userObtained.Value, userExpected.Value);
        }
    }
}
