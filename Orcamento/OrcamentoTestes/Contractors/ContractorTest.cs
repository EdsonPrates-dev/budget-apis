using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Infrastructure.Repository;
using TestBudget.Contractor;

namespace TestBudget.Contractors
{
    [TestFixture]
    public class ContractorTest
    {
        private Mock<IContractorRepository> _contractorRepository;
        private Mock<IValidator<Orcamento.Api.Models.Entities.Contractors.Contractor>> _validator;

        public ContractorTest()
        {
            _contractorRepository = new Mock<IContractorRepository>();
            _validator = new Mock<IValidator<Orcamento.Api.Models.Entities.Contractors.Contractor>>();
        }


        [Test]
        public void CreateContractor_Ok()
        {
            var contractorExpected = ContractorStub._1StubContractorsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>()));
            _contractorRepository.Setup(c => c.CreateContractor(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>())).ReturnsAsync(contractorExpected.Value);
            var contractorObtained = _contractorRepository.Object.CreateContractor(contractorExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(contractorObtained.IsSuccess);
            Assert.AreEqual(contractorExpected.Value, contractorObtained.Value);
        }

        [Test]
        public void UpdateContractor_Ok()
        {
            var contractorExpected = ContractorStub._1StubContractorsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>()));
            _contractorRepository.Setup(c => c.UpdateContractor(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>())).ReturnsAsync(contractorExpected.Value);
            var contractorObtained = _contractorRepository.Object.UpdateContractor(contractorExpected.Value).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(contractorObtained.IsSuccess);
            Assert.AreEqual(contractorExpected.Value, contractorObtained.Value);
        }


        [Test]
        public void DeleteContractor_Ok()
        {
            var contractorExpected = ContractorStub._1StubContractorsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>()));
            _contractorRepository.Setup(c => c.DeleteContractor(It.IsAny<string>())).ReturnsAsync(contractorExpected);
            var contractorObtained = _contractorRepository.Object.DeleteContractor(contractorExpected.Value.Cpf).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(contractorObtained.IsSuccess);
        }

        [Test]
        public void GetContractor_Ok()
        {
            var contractorExpected = ContractorStub._1StubContractorsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Contractors.Contractor>()));
            _contractorRepository.Setup(c => c.GetContractor(It.IsAny<int>())).ReturnsAsync(contractorExpected);
            var contractorObtained = _contractorRepository.Object.GetContractor(contractorExpected.Value.IdContractor).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(contractorObtained.IsSuccess);
            Assert.AreEqual(contractorExpected.Value, contractorObtained.Value);
        }
    }
}
