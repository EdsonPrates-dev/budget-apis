using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Models.Entities.Budget;
using Orcamento.Api.Service;

namespace Orcamento.Api.Controllers.Budgets
{
    [Route("materialsBudget")]
    [ApiController]
    [Authorize]
    public class MaterialsBudgetController : Controller
    {
        private readonly IMaterialsBudgetService _materialsBudgetService;
        private readonly IValidator<MaterialsBudget> _validator;

        public MaterialsBudgetController(IMaterialsBudgetService materialsBudgetService, IValidator<MaterialsBudget> validator)
        {
            _materialsBudgetService = materialsBudgetService;
            _validator = validator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMaterialsBudget([FromBody] MaterialsBudget materialsBudget, string cpfClient)
        {
            if (string.IsNullOrEmpty(cpfClient))
                return BadRequest("Cpf não pode ser nulo! ");

            var validate = await _validator.ValidateAsync(materialsBudget);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _materialsBudgetService.CreateMaterialsBudget(materialsBudget, cpfClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{cpfClient}")]
        public async Task<IActionResult> UpdateMaterialsBudget([FromBody] MaterialsBudget materialsBudget, string cpfClient)
        {
            if (string.IsNullOrEmpty(cpfClient))
                return BadRequest("Cpf não pode ser nulo! ");

            var validate = await _validator.ValidateAsync(materialsBudget);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var result = await _materialsBudgetService.UpdateMaterialsBudget(materialsBudget, cpfClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{idClient}")]
        public async Task<IActionResult> GetMaterialsBudget(int idClient)
        {
            if (idClient == 0)
                return BadRequest();

            var result = await _materialsBudgetService.GetMaterialsBudget(idClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{idClient}")]
        public async Task<IActionResult> DeleteMaterialsBudget(int idClient)
        {
            if (idClient == 0)
                return BadRequest();

            var result = await _materialsBudgetService.DeleteMaterialsBudget(idClient);

            if (result.IsFailure)
                return NotFound(result.Error);

            return NoContent();
        }
    }
}
