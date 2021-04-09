using CodeFirst.Core.DTOs;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Enums;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Web.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ISeguridadService _seguridadService;

        public SeguridadController( ISeguridadService seguridadService )
        {
            _seguridadService = seguridadService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SeguridadDto seguridadDto)
        {
            await _seguridadService.RegisterUser(seguridadDto).ConfigureAwait(false);

            ApiResponse<string> response = new ApiResponse<string>() { Succeeded = true, Message = "Usuario Registrado" };
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDto user)
        {
            await _seguridadService.UpdateUser(user).ConfigureAwait(false);

            ApiResponse<string> response = new ApiResponse<string>() { Succeeded = true, Message = "Cambio  de estado del usuario" };
            return Ok(response);
        }
    }
}