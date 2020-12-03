using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Infrastructure.Repository;
using Orcamento.Api.Models.Entities.Clients;

namespace TestBudget.ClientAddress
{
    [TestFixture]
    public class ClientAddressTest
    {
        private Mock<IClientAddressRepository> _clientAddressRepository;
        private Mock<IValidator<ClientsAddress>> _validator;

        public ClientAddressTest()
        {
            _clientAddressRepository = new Mock<IClientAddressRepository>();
            _validator = new Mock<IValidator<ClientsAddress>>();
        }
        
        [Test]
        public void CreateAddress_Ok()
        {
            var addressExpected = ClientAddressStub._1StubClientAddressOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<ClientsAddress>()));
            _clientAddressRepository.Setup(c => c.CreateClientAddress(It.IsAny<ClientsAddress>())).ReturnsAsync(addressExpected.Value);
            var addressObtained = _clientAddressRepository.Object.CreateClientAddress(addressExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(addressObtained.IsSuccess);
            Assert.AreEqual(addressExpected.Value, addressObtained.Value);
        }

        [Test]
        public void UpdateAddress_Ok()
        {
            var addressExpected = ClientAddressStub._1StubClientAddressOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<ClientsAddress>()));
            _clientAddressRepository.Setup(c => c.UpdateClientAddress(It.IsAny<ClientsAddress>())).ReturnsAsync(addressExpected.Value);
            var addressObtained = _clientAddressRepository.Object.UpdateClientAddress(addressExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(addressObtained.IsSuccess);
            Assert.AreEqual(addressExpected.Value, addressObtained.Value);
        }

        [Test]
        public void DeleteAddress_Ok()
        {
            var addressExpected = ClientAddressStub._1StubClientAddressOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<ClientsAddress>()));
            _clientAddressRepository.Setup(c => c.DeleteClientAddress(It.IsAny<int>())).ReturnsAsync(addressExpected);
            var addressObtained = _clientAddressRepository.Object.DeleteClientAddress(addressExpected.Value.IdAddress).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(addressObtained.IsSuccess);
        }

        [Test]
        public void GetAddress_Ok()
        {
            var addressExpected = ClientAddressStub._1StubClientAddressOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<ClientsAddress>()));
            _clientAddressRepository.Setup(c => c.GetClientAddress(It.IsAny<int>())).ReturnsAsync(addressExpected);
            var addressObtained = _clientAddressRepository.Object.GetClientAddress(addressExpected.Value.IdAddress).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(addressObtained.IsSuccess);
            Assert.AreEqual(addressExpected.Value, addressObtained.Value);
        }

        [Test]
        public void GetAddressFromCep_Ok()
        {
            var addressExpected = ClientAddressStub._1StubClientAddressFromCepOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<ClientsAddress>()));
            _clientAddressRepository.Setup(c => c.GetAddressFromCep(It.IsAny<string>())).ReturnsAsync(addressExpected);
            var addressObtained = _clientAddressRepository.Object.GetAddressFromCep(addressExpected.Value.Cep).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(addressObtained.IsSuccess);
            Assert.AreEqual(addressExpected.Value, addressObtained.Value);
        }
    }
}
