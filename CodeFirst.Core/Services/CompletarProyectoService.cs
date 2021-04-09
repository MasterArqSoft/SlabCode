using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class CompletarProyectoService : ICompletarProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public CompletarProyectoService(
            IUnitOfWork unitOfWork,
            IEmailService emailService
            )
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<bool> UpdateCambioEstadoProyecto(int idProyecto)
        {
            if (idProyecto == 0)
            {
                throw new ApiException("El proecto ingresado no existe.");
            }
            Proyecto proyecto = _unitOfWork.ProyectoRepository.GetAll().Where(x => x.Id == idProyecto).FirstOrDefault() ;
            proyecto.Estado = _unitOfWork.EstadoProyectoRepository.GetById(proyecto.IdEstadoProyecto).Result;

            if (proyecto == null)
            {
                throw new ApiException("El proyecto ingresado no existe el sistema.");
            }

            if (!string.Equals(proyecto.Estado.Nombre.Trim().ToUpper(), "En Proceso".Trim().ToUpper(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ApiException("El proyecto no se encuentra en estado en proceso.");
            }

            IEnumerable<Tarea> listTarea = _unitOfWork.TareaRepository.SearchIdProyecto(idProyecto).Result;


            int proyectoCantidadTareaFinalizada = listTarea.Count(t => !string.Equals(t.IdEstadoTarea, _unitOfWork.EstadoTareaRepository.GetByNombre("Realizada").Result.Id));

            if (!(proyectoCantidadTareaFinalizada <= 0))
            {
                throw new ApiException("El proyecto tiene tareas por finalizar.");
            }

            IEnumerable<Seguridad> users = _unitOfWork.SeguridadRepository.GetAll().Where(x => x.Role == Domain.Enums.RoleType.Administrator);


            foreach (var user in users)
            {
                _emailService.Send(user.Email, "Notificación de proyecto", "<p>Proyecto finalizado</p>");
            }


            proyecto.IdEstadoProyecto = _unitOfWork.EstadoProyectoRepository.GetByNombre("Finalizado").Result.Id;

            _unitOfWork.ProyectoRepository.Update(proyecto);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}