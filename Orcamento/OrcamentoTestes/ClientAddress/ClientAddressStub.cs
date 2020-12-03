using CSharpFunctionalExtensions;
using Orcamento.Api.Models.Entities.Address;

namespace TestBudget.ClientAddress
{
    public static class ClientAddressStub
    {
        public static Result<Orcamento.Api.Models.Entities.Clients.ClientsAddress> _1StubClientAddressOk()
        {
            return new Orcamento.Api.Models.Entities.Clients.ClientsAddress
            {
                IdAddress = 1,
                IdClient = 1,
                Cep = "410410",
                City = "Teste",
                Country = "Teste Country",
                Neighborhood = "Teste Neighborhood",
                Number = 23,
                Street = "Teste Street"
            };
        }
        public static Result<Address> _1StubClientAddressFromCepOk()
        {
            return new Address
            {
                Cep = "410410",
                Localidade = "Teste",
                Uf = "Teste Country",
                Bairro = "Teste Neighborhood",
                Logradouro = "Teste Street"
            };
        }
    }
}
