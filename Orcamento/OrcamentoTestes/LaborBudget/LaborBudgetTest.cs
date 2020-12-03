using FluentValidation;
using Moq;
using NUnit.Framework;
using Orcamento.Api.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBudget.LaborBudget
{
    [TestFixture]
    public class LaborBudgetTest
    {
        private Mock<ILaborBudgetRepository> _laborBudgetRepository;
        private Mock<IValidator<Orcamento.Api.Models.Entities.Budget.LaborBudget>> _validator;

        public LaborBudgetTest()
        {
            _laborBudgetRepository = new Mock<ILaborBudgetRepository>();
            _validator = new Mock<IValidator<Orcamento.Api.Models.Entities.Budget.LaborBudget>>();
        }

        [Test]
        public void CreateLaborBudget_Ok()
        {
            var laborBudgetExpected = LaborBudgetStub.LaborBudgetStub._1StubLaborBudgetsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>()));
            _laborBudgetRepository.Setup(c => c.CreateLaborBudget(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>(), string.Empty)).ReturnsAsync(laborBudgetExpected.Value);
            var laborBudgetrObtained = _laborBudgetRepository.Object.CreateLaborBudget(laborBudgetExpected.Value, "").Result;

            Assert.NotNull(validate);
            Assert.IsTrue(laborBudgetrObtained.IsSuccess);
            Assert.AreEqual(laborBudgetExpected.Value, laborBudgetrObtained.Value);
        }

        [Test]
        public void UpdateLaborBudget_Ok()
        {
            var laborBudgetExpected = LaborBudgetStub.LaborBudgetStub._1StubLaborBudgetsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>()));
            _laborBudgetRepository.Setup(c => c.UpdateLaborBudget(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>(), string.Empty)).ReturnsAsync(laborBudgetExpected.Value);
            var laborBudgetrObtained = _laborBudgetRepository.Object.UpdateLaborBudget(laborBudgetExpected.Value, "").Result;

            Assert.NotNull(validate);
            Assert.IsTrue(laborBudgetrObtained.IsSuccess);
            Assert.AreEqual(laborBudgetExpected.Value, laborBudgetrObtained.Value);
        }

        [Test]
        public void DeleteLaborBudget_Ok()
        {
            var laborBudgetExpected = LaborBudgetStub.LaborBudgetStub._1StubLaborBudgetsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>()));
            _laborBudgetRepository.Setup(c => c.DeleteLaborBudget(It.IsAny<int>()));
            var laborBudgetrObtained = _laborBudgetRepository.Object.DeleteLaborBudget(laborBudgetExpected.Value.IdClient).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(laborBudgetrObtained.IsSuccess);
        }

        [Test]
        public void GetLaborBudget_Ok()
        {
            var laborBudgetExpected = LaborBudgetStub.LaborBudgetStub._1StubLaborBudgetsOk();

            var validate = _validator.Setup(v => v.Validate(It.IsAny<Orcamento.Api.Models.Entities.Budget.LaborBudget>()));
            _laborBudgetRepository.Setup(c => c.GetLaborBudget(It.IsAny<int>())).ReturnsAsync(laborBudgetExpected);
            var laborBudgetrObtained = _laborBudgetRepository.Object.GetLaborBudget(laborBudgetExpected.Value.IdClient).Result;

            Assert.NotNull(validate);
            Assert.IsTrue(laborBudgetrObtained.IsSuccess);
            Assert.AreEqual(laborBudgetrObtained.Value, laborBudgetExpected.Value);
        }
    }
}
