using CSharpFunctionalExtensions;

namespace TestBudget.Contractor
{
    public static class ContractorStub
    {
        public static Result<Orcamento.Api.Models.Entities.Contractors.Contractor> _1StubContractorsOk()
        {
            return new Orcamento.Api.Models.Entities.Contractors.Contractor
            {
                IdContractor = 1,
                Cpf = "3223423423",
                Name = "José Teste",
                Phone = 13981554124
            };
        }
    }
}
