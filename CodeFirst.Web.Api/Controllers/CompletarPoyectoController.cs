using CodeFirst.Core.Interfaces;
using CodeFirst.Web.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [Authorize(Roles = "Administrator, Operador")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompletarPoyectoController : ControllerBase
    {
        private readonly ICompletarProyectoService _completarProyectoService;

        public CompletarPoyectoController(
            ICompletarProyectoService completarProyectoService
            )
        {
            _completarProyectoService = completarProyectoService;
        }

        [HttpPut]
        public async Task<IActionResult> Put(int idProyecto)
        {
            bool result = await _completarProyectoService.UpdateCambioEstadoProyecto(idProyecto).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;
            response.Message = result ? "Proyecto Finalizado" : response.Message;
            return Ok(response);
        }
    }
}