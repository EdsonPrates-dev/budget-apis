using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;

namespace TestBudget.Client
{
    [TestFixture]
    public class ClientTest
    {
        private Mock<IClientRepository> _clientRepository;
        private Mock<IValidator<Orcamento.Api.Models.Entities.Clients.Client>> _validator;

        public ClientTest()
        {
            _clientRepository = new Mock<IClientRepository>();
            _validator = new Mock<IValidator<Orcamento.Api.Models.Entities.Clients.Client>>();
        }

        [Test]
        public void CreateClient_Ok()
        {
            var clientExpected = ClientStub._1StubClientOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.CreateClient(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>())).ReturnsAsync(clientExpected.Value);
            var clientObtained = _clientRepository.Object.CreateClient(clientExpected.Value).Result; 

            Assert.NotNull(validate);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected.Value, clientObtained.Value);
        }

        [Test]
        public void UpdateClient_Ok()
        {
            var clientExpected = ClientStub._1StubClientOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.UpdateClient(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>())).ReturnsAsync(clientExpected.Value);
            var clientObtained = _clientRepository.Object.UpdateClient(clientExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected.Value, clientObtained.Value);
        }

        [Test]
        public void GetClient_Ok()
        {
            var clientExpected = ClientStub._1StubClientOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.GetClient(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(clientExpected.Value);
            var clientObtained = _clientRepository.Object.GetClient(clientExpected.Value.Cpf, false).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected.Value, clientObtained.Value);
        }

        [Test]
        public void GetClientBudgets_Ok()
        {
            var clientExpected = ClientStub._3StubClientWithBudgetsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.GetClient(It.IsAny<string>(), It.IsAny<bool>())).ReturnsAsync(clientExpected.Value);
            var clientObtained = _clientRepository.Object.GetClient(clientExpected.Value.Cpf, true).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected.Value, clientObtained.Value);
        }

        [Test]
        public void GetAllClients_Ok()
        {
            var clientExpected = ClientStub._1StubClientOk().Value;
            
            var listExpected = new List<Orcamento.Api.Models.Entities.Clients.Client>();
            listExpected.Add(clientExpected);

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.GetAllClients()).ReturnsAsync(listExpected);
            var clientObtained = _clientRepository.Object.GetAllClients().Result;

            Assert.NotNull(validate);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected, clientObtained.Value.First());
        }

        [Test]
        public void DeleteClient_Ok()
        {
            var clientExpected = ClientStub._1StubClientOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.DeleteClient(It.IsAny<string>())).ReturnsAsync(clientExpected);
            var clientObtained = _clientRepository.Object.DeleteClient(clientExpected.Value.Cpf).Result;

            Assert.NotNull(clientObtained);
            Assert.IsTrue(clientObtained.IsSuccess);
        }

        [Test]
        public void GetClientWithAddress_Ok()
        {
            var clientExpected = ClientStub._2StubClientWithAddressOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Clients.Client>()));
            _clientRepository.Setup(c => c.GetClientWithAddress(It.IsAny<string>())).ReturnsAsync(clientExpected);
            var clientObtained = _clientRepository.Object.GetClientWithAddress(clientExpected.Value.Cpf).Result;

            Assert.NotNull(clientObtained);
            Assert.IsTrue(clientObtained.IsSuccess);
            Assert.AreEqual(clientExpected.Value, clientObtained.Value);
        }
    }
}