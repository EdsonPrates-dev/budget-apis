using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Models.Entities.Contractors;
using Orcamento.Api.Service;

namespace Orcamento.Api.Controllers
{
    [Route("contractor")]
    [ApiController]
    [Authorize]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorService _contractorService;
        private readonly IValidator<Contractor> _validator;

        public ContractorController(IContractorService contractorService, IValidator<Contractor> validator)
        {
            _contractorService = contractorService;
            _validator = validator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateConstractor([FromBody] Contractor contractor)
        {
            var validate = await _validator.ValidateAsync(contractor);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _contractorService.CreateContractor(contractor);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateContractor([FromBody] Contractor contractor)
        {
            var validate = await _validator.ValidateAsync(contractor);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _contractorService.UpdateContractor(contractor);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetContractor(int id)
        {
            if (id == 0)
                return BadRequest();

            var result = await _contractorService.GetContractor(id);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{cpf}")]
        public async Task<IActionResult> DeleteContractor(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return BadRequest();

            var result = await _contractorService.DeleteContractor(cpf);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return NoContent();
        }
    }
}
