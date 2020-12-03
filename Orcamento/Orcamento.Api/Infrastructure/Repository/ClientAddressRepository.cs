using System;
using System.Net.Http;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Orcamento.Api.Infrastructure.Context;
using Orcamento.Api.Models.Entities.Address;
using Orcamento.Api.Models.Entities.Clients;

namespace Orcamento.Api.Infrastructure.Repository
{
    public class ClientAddressRepository : IClientAddressRepository
    {
        private readonly ProjectBudgetContext _projectBudgetContext;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;

        public ClientAddressRepository(IConfiguration configuration, ProjectBudgetContext projectBudgetContext)
        {
            _projectBudgetContext = projectBudgetContext;
            _configuration = configuration;
            baseUrl = _configuration.GetSection("ExternalUrls")["BaseUrlCep"];
        }

        public async Task<Result<ClientsAddress>> CreateClientAddress(ClientsAddress clientAddress)
        {
            var client = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.IdClient == clientAddress.IdClient);

            if (client is null)
                return Result.Failure<ClientsAddress>("Cliente não está cadastrado na base de dados. ");

            _projectBudgetContext.ClientAddress.Add(clientAddress);
            await _projectBudgetContext.SaveChangesAsync();

            return clientAddress;
        }

        public async Task<Result> DeleteClientAddress(int id)
        {
            var clientsAddress = await _projectBudgetContext.ClientAddress.FirstOrDefaultAsync(c => c.IdAddress == id);

            if (clientsAddress is null)
                return Result.Failure("Endereço desse cliente não está cadastrado. ");

            _projectBudgetContext.Remove(clientsAddress);
            await _projectBudgetContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<ClientsAddress>> GetClientAddress(int id)
        {
            var result = await _projectBudgetContext.ClientAddress.FirstOrDefaultAsync(c => c.IdAddress == id);

            if (result is null)
                return Result.Failure<ClientsAddress>("Endereço desse cliente não está cadastrado. ");

            return result;
        }


        public async Task<Result<ClientsAddress>> UpdateClientAddress(ClientsAddress clientAddress)
        {
            var client = await _projectBudgetContext.Client.FirstOrDefaultAsync(c => c.IdClient == clientAddress.IdClient);

            if (client is null)
                return Result.Failure<ClientsAddress>("Cliente não está cadastrado na base de dados. ");

            var clientsAddressDb = await _projectBudgetContext.ClientAddress.FirstOrDefaultAsync(c => c.IdClient == client.IdClient);

            if (clientsAddressDb == null)
                return Result.Failure<ClientsAddress>("Endereço não cadastrado para esse cliente. ");

            clientsAddressDb.Street = clientAddress.Street;
            clientsAddressDb.Number = clientAddress.Number;
            clientsAddressDb.Neighborhood = clientAddress.Neighborhood;
            clientsAddressDb.Cep = clientAddress.Cep;
            clientsAddressDb.City = clientAddress.City;
            clientsAddressDb.Country = clientAddress.Country;

            _projectBudgetContext.ClientAddress.Update(clientsAddressDb);
            await _projectBudgetContext.SaveChangesAsync();
            return clientsAddressDb;
        }

        public async Task<Result<Address>> GetAddressFromCep(string cep)
        {
            string url = string.Concat(baseUrl, $"{cep}/json/");

            try
            {
                using (var _client = new HttpClient())
                {
                    var response = await _client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                        return Result.Failure<Address>("Endereço não encontrado para o CEP informado! ");

                    var content = await response.Content.ReadAsStringAsync();
                    var address = JsonConvert.DeserializeObject<Address>(content);

                    return address;
                }
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}
