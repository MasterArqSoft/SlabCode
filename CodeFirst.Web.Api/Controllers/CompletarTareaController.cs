using CodeFirst.Core.Interfaces;
using CodeFirst.Web.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [Authorize(Roles = "Administrator, Operador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompletarTareaController : ControllerBase
    {
        private readonly ICompletarTareaService _completarTareaService;

        public CompletarTareaController(
            ICompletarTareaService completarTareaService
        )
        {
            _completarTareaService = completarTareaService;
        }

        [HttpPut]
        public async Task<IActionResult> Put(int idTarea)
        {
            bool result = await _completarTareaService.UpdateCambioEstadoTarea(idTarea).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;
            response.Message = result ? "Tarea Finalizado" : response.Message;
            return Ok(response);
        }
    }
}