using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Api.Infrastructure.Authentication;
using Orcamento.Api.Models.User;
using Orcamento.Api.Service;
using System;
using System.Threading.Tasks;

namespace Orcamento.Api.Controllers.Token
{
    [Route("api/authToken")]
    public class AuthTokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IValidator<User> _validator;

        public AuthTokenController(ITokenService tokenService, 
                               IUserService userService, 
                               IValidator<User> validator)
        {
            _tokenService = tokenService;
            _validator = validator;
            _userService = userService;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]User user)
        {
            var validate = await _validator.ValidateAsync(user);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            var userRegistered = await _userService.GetUser(user);         

            if (userRegistered.IsFailure)
                return NotFound(userRegistered.Error);

            var response = _tokenService.GenerateToken(user);

            userRegistered.Value.Token = response.Token;
            userRegistered.Value.ExpirationDate = response.ExpirationDate;

            return Ok(userRegistered);
        }

        [HttpPost]
        [Route("createLogin/{cpfContractor}")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateLoginFromContractor([FromBody]User user, string cpfContractor)
        {
            if (string.IsNullOrEmpty(cpfContractor))
                return BadRequest("Cpf do empreiteiro não pode ser nulo. ");

            var validate = await _validator.ValidateAsync(user);

            if (!validate.IsValid)
                return BadRequest(validate.Errors);

            await _userService.CreateLoginFromContractor(user, cpfContractor);

            return Ok(
                new
                {
                    message = "Login criado para esse empreiteiro. "
                });
        }
    }
}