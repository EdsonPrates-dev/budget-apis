using CSharpFunctionalExtensions;
using Orcamento.Api.Models.Entities.Budget;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBudget.LaborBudgetStub
{
    public static class LaborBudgetStub
    {
        public static Result<Orcamento.Api.Models.Entities.Budget.LaborBudget> _1StubLaborBudgetsOk()
        {
            return new Orcamento.Api.Models.Entities.Budget.LaborBudget
            {
                IdClient = 1,
                IdLabor = 2,
                CostPrice = 450,
                Description = "Quebrar parede"
            };
        }
    }
}
