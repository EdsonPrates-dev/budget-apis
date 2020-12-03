using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Models.Entities.Clients;
using Orcamento.Api.Service.Interfaces;

namespace Orcamento.Api.Controllers.Clients
{
    [Route("clientAddress")]
    [Authorize]
    public class ClientAddressController : ControllerBase
    {
        private readonly IClientAddressService _clientAddressService;
        private readonly IValidator<ClientsAddress> _validator;

        public ClientAddressController(IClientAddressService clientAddressService, IValidator<ClientsAddress> validator)
        {
            _clientAddressService = clientAddressService;
            _validator = validator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateClientAddress([FromBody] ClientsAddress clientAddress)
        {
            var validate = await _validator.ValidateAsync(clientAddress);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _clientAddressService.CreateClientAddress(clientAddress);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateClientAddress([FromBody] ClientsAddress clientAddress)
        {
            var validate = await _validator.ValidateAsync(clientAddress);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _clientAddressService.UpdateClientAddress(clientAddress);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetClientAddress(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _clientAddressService.GetClientAddress(id);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteClientAddress(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _clientAddressService.DeleteClientAddress(id);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }

        [HttpGet]
        [Route("getAddress/{cep}")]
        public async Task<IActionResult> GetAddressFromCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return BadRequest();

            var result = await _clientAddressService.GetAddressFromCep(cep);

            if (result.IsFailure)
                return NotFound(result.Error);
           
            return Ok(result);
        }
    }
}
