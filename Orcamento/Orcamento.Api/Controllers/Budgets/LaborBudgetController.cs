using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Service;

namespace Orcamento.Api.Controllers.Budgets
{
    [Route("laborBudget")]
    [ApiController]
    [Authorize]
    public class LaborBudgetController : Controller
    {
        private readonly ILaborBudgetService _laborBudgetService;
        private readonly IValidator<LaborBudget> _validator;

        public LaborBudgetController(ILaborBudgetService laborBudgetService, IValidator<LaborBudget> validator)
        {
            _laborBudgetService = laborBudgetService;
            _validator = validator;
        }

        [HttpPost]
        [Route("create/{cpfClient}")]
        public async Task<IActionResult> CreateLaborBudget([FromBody] LaborBudget laborBudget, string cpfClient)
        {
            if (string.IsNullOrEmpty(cpfClient))
                return BadRequest("Cpf não pode ser nulo! ");

            var validate = await _validator.ValidateAsync(laborBudget);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _laborBudgetService.CreateLaborBudget(laborBudget, cpfClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{cpfClient}")]
        public async Task<IActionResult> UpdateLaborBudget([FromBody] LaborBudget laborBudget, string cpfClient)
        {
            if (string.IsNullOrEmpty(cpfClient))
                return BadRequest("Cpf não pode ser nulo! ");

            var validate = await _validator.ValidateAsync(laborBudget);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _laborBudgetService.UpdateLaborBudget(laborBudget, cpfClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{idClient}")]
        public async Task<IActionResult> GetLaborBudget(int idClient)
        {
            if (idClient == 0)
                return BadRequest("IdClient não pode ser nulo! ");

            var result = await _laborBudgetService.GetLaborBudget(idClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{idClient}")]
        public async Task<IActionResult> DeleteLaborBudget(int idClient)
        {
            if (idClient == 0)
                return BadRequest("IdClient não pode ser nulo! ");

            var result = await _laborBudgetService.DeleteLaborBudget(idClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}
