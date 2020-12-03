using CSharpFunctionalExtensions;

namespace TestBudget.Client
{
    public static class ClientStub
    {
        public static Result<Orcamento.Api.Models.Entities.Clients.Client> _1StubClientOk()
        {
            return new Orcamento.Api.Models.Entities.Clients.Client
            {
                IdClient = 1,
                Cpf = "456166816451",
                Email = "teste@teste.com",
                Name = "Teste",
                Phone = 13984845151
            };
        }
        public static Result<Orcamento.Api.Models.Entities.Clients.Client> _2StubClientWithAddressOk()
        {
            return new Orcamento.Api.Models.Entities.Clients.Client
            {
                Cpf = "456166816451",
                Email = "teste@teste.com",
                Name = "Teste",
                Phone = 13984845151,
                ClientAddress = new Orcamento.Api.Models.Entities.Clients.ClientsAddress
                {
                    Cep = "11651561",
                    City = "Brasilandia",
                    Country = "Brasil",
                    Neighborhood = "Santo Antônio",
                    Number = 12321,
                    Street = "Rua das Catracas"
                }
            };
        }

        public static Result<Orcamento.Api.Models.Entities.Clients.Client> _3StubClientWithBudgetsOk()
        {
            return new Orcamento.Api.Models.Entities.Clients.Client
            {
                IdClient = 1,
                Cpf = "456166816451",
                Email = "teste@teste.com",
                Name = "Teste",
                Phone = 13984845151,
                LaborBudget = new Orcamento.Api.Models.Entities.Budget.LaborBudget
                {
                    IdLabor = 1,
                    IdClient = 1,
                    CostPrice = 199,
                    Description = "Levantar parede do banheiro",
                },
                MaterialsBudget = new Orcamento.Api.Models.Entities.Budget.MaterialsBudget
                {
                    IdMaterials = 1,
                    IdClient = 1,
                    CostPrice = 300,
                    Description = "Fardo de tijolos",
                    Quantity = 500
                },
                ClientAddress = new Orcamento.Api.Models.Entities.Clients.ClientsAddress
                {
                    Cep = "11651561",
                    City = "Brasilandia",
                    Country = "Brasil",
                    Neighborhood = "Santo Antônio",
                    Number = 12321,
                    Street = "Rua das Catracas"
                }
            };
        }
    }
}

