using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBudget.MaterialsBudget
{
    [TestFixture]
    public class MaterialsBudgetTest
    {
        private Mock<IMaterialsBudgetRepository> _materialsBudgetRepository;
        private Mock<IValidator<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>> _validator;

        public MaterialsBudgetTest()
        {
            _materialsBudgetRepository = new Mock<IMaterialsBudgetRepository>();
            _validator = new Mock<IValidator<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>>();
        }

        [Test]
        public void CreateMaterialsBudget_Ok()
        {
            var materialsBudgetExpected = MaterialsBudgetStub._1StubMaterialsBudgetOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>()));
            _materialsBudgetRepository.Setup(c => c.CreateMaterialsBudget(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>(), string.Empty)).ReturnsAsync(materialsBudgetExpected.Value);
            var materialsBudgetrObtained = _materialsBudgetRepository.Object.CreateMaterialsBudget(materialsBudgetExpected.Value, "").Result;

            Assert.NotNull(validate);
            Assert.IsTrue(materialsBudgetrObtained.IsSuccess);
            Assert.AreEqual(materialsBudgetExpected.Value, materialsBudgetrObtained.Value);
        }

        [Test]
        public void UpdateMaterialsBudget_Ok()
        {
            var materialsBudgetExpected = MaterialsBudgetStub._1StubMaterialsBudgetOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>()));
            _materialsBudgetRepository.Setup(c => c.UpdateMaterialsBudget(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>(), string.Empty)).ReturnsAsync(materialsBudgetExpected.Value);
            var materialsBudgetrObtained = _materialsBudgetRepository.Object.UpdateMaterialsBudget(materialsBudgetExpected.Value, "").Result;

            Assert.NotNull(validate);
            Assert.IsTrue(materialsBudgetrObtained.IsSuccess);
            Assert.AreEqual(materialsBudgetExpected.Value, materialsBudgetrObtained.Value);
        }

        [Test]
        public void DeleteMaterialsBudget_Ok()
        {
            var materialsBudgetExpected = MaterialsBudgetStub._1StubMaterialsBudgetOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>()));
            _materialsBudgetRepository.Setup(c => c.DeleteMaterialsBudget(It.IsAny<int>()));
            var materialsBudgetrObtained = _materialsBudgetRepository.Object.DeleteMaterialsBudget(materialsBudgetExpected.Value.IdClient).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(materialsBudgetrObtained.IsSuccess);
        }

        [Test]
        public void GetMaterialsBudget_Ok()
        {
            var materialsBudgetExpected = MaterialsBudgetStub._1StubMaterialsBudgetOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.MaterialsBudget>()));
            _materialsBudgetRepository.Setup(c => c.GetMaterialsBudget(It.IsAny<int>())).ReturnsAsync(materialsBudgetExpected);
            var materialsBudgetrObtained = _materialsBudgetRepository.Object.GetMaterialsBudget(materialsBudgetExpected.Value.IdClient).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(materialsBudgetrObtained.IsSuccess);
            Assert.AreEqual(materialsBudgetrObtained.Value, materialsBudgetExpected.Value);
        }
    }
}
