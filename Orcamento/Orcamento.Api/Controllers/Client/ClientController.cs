using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Service;

namespace Orcamento.Api.Controllers.Clients
{
    [Route("client")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IValidator<Client> _validator;

        public ClientController(IClientService clientService, IValidator<Client> validator)
        {
            _clientService = clientService;
            _validator = validator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateClient([FromBody] Client client)
        {
            var validate = await _validator.ValidateAsync(client);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _clientService.CreateClient(client);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);

        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateClient([FromBody] Client client)
        {
            var validate = await _validator.ValidateAsync(client);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _clientService.UpdateClient(client);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{cpf}")]
        public async Task<IActionResult> GetClient(string cpf, bool budgets = false)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var result = await _clientService.GetClient(cpf, budgets);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientService.GetAllClients();

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{cpf}")]
        public async Task<IActionResult> DeleteClient(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var result = await _clientService.DeleteClient(cpf);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }

        [HttpGet]
        [Route("getClientAddress/{cpf}")]
        public async Task<IActionResult> GetClientWithAddress(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var result = await _clientService.GetClientWithAddress(cpf);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }
    }
}
