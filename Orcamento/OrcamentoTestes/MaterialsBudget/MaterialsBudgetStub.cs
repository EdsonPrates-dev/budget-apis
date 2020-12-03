using CSharpFunctionalExtensions;

namespace TestBudget.MaterialsBudget
{
    public static class MaterialsBudgetStub
    {
        public static Result<Orcamento.Api.Models.Entities.Budget.MaterialsBudget> _1StubMaterialsBudgetOk()
        {
            return new Orcamento.Api.Models.Entities.Budget.MaterialsBudget()
            {
                IdClient = 1,
                IdMaterials = 2,
                CostPrice = 500,
                Quantity = 50,
                Description = "Sacos de cimento"
            };
        }
    }
}
