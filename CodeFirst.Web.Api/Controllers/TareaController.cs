using AutoMapper;
using CodeFirst.Core.DTOs;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
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
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;
        private readonly IEstadoTareaService _estadoTareaService;
        private readonly IMapper _mapper;

        public TareaController(
            ITareaService tareaService,
            IEstadoTareaService estadoTareaService,
            IMapper mapper)
        {
            _tareaService = tareaService;
            _estadoTareaService = estadoTareaService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarea(int id)
        {
            Tarea tarea = await _tareaService.GetTarea(id).ConfigureAwait(false);
            TareaDto tareaDto = _mapper.Map<TareaDto>(tarea);
            ApiResponse<TareaDto> response = new(tareaDto);
            response.Succeeded = true;
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TareaDto tareaDto)
        {
            Tarea tarea = _mapper.Map<Tarea>(tareaDto);
            tarea.IdEstadoTarea = _estadoTareaService.GetByNombre("Pendiente").Result.Id;

            await _tareaService.InsertTarea(tarea).ConfigureAwait(false);

            tareaDto = _mapper.Map<TareaDto>(tarea);
            ApiResponse<TareaDto> response = new(tareaDto);
            response.Succeeded = true;
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TareaDto tareaDto)
        {
            Tarea tarea = _mapper.Map<Tarea>(tareaDto);
            tarea.Id = id;

            bool result = await _tareaService.UpdateTarea(tarea).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _tareaService.DeleteTarea(id).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;
            return Ok(response);
        }
    }
}