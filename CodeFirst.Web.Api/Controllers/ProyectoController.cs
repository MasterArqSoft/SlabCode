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
    public class ProyectoController : ControllerBase
    {
        private readonly IProyectoService _proyectoService;
        private readonly IEstadoProyectoService _estadoProyectoService;
        private readonly IMapper _mapper;

        public ProyectoController(
            IProyectoService proyectoService,
            IMapper mapper,
            IEstadoProyectoService estadoProyectoService)
        {
            _proyectoService = proyectoService;
            _estadoProyectoService = estadoProyectoService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProyecto(int id)
        {
            Proyecto proyecto = await _proyectoService.GetProyecto(id).ConfigureAwait(false);
            ProyectoDto proyectoDto = _mapper.Map<ProyectoDto>(proyecto);
            ApiResponse<ProyectoDto> response = new(proyectoDto);
            response.Succeeded = true;

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProyectoDto proyectoDto)
        {
            Proyecto proyecto = _mapper.Map<Proyecto>(proyectoDto);
            proyecto.IdEstadoProyecto = _estadoProyectoService.GetByNombre("En Proceso").Result.Id;

            await _proyectoService.InsertProyecto(proyecto).ConfigureAwait(false);

            proyectoDto = _mapper.Map<ProyectoDto>(proyecto);
            ApiResponse<ProyectoDto> response = new(proyectoDto);
            response.Succeeded = true;

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ProyectoDto proyectotDto)
        {
            Proyecto proyecto = _mapper.Map<Proyecto>(proyectotDto);
            proyecto.Id = id;

            bool result = await _proyectoService.UpdateProyecto(proyecto).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _proyectoService.DeleteProyecto(id).ConfigureAwait(false);
            ApiResponse<bool> response = new(result);
            response.Succeeded = true;
            return Ok(response);
        }
    }
}