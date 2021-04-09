using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class CompletarTareaService : ICompletarTareaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEmailService _emailService;


        public CompletarTareaService(IUnitOfWork unitOfWork, IEmailService emailService )
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<bool> UpdateCambioEstadoTarea(int idTarea)
        {
            if (idTarea == 0)
            {
                throw new ApiException("La tarea ingresada no existe.");
            }
            Tarea tarea = _unitOfWork.TareaRepository.GetById(idTarea).Result;
            tarea.Estado = _unitOfWork.EstadoTareaRepository.GetById(tarea.IdEstadoTarea).Result;

            if (string.IsNullOrEmpty(tarea.Estado.Nombre))
            {
                throw new ApiException("La tarea ingresada no existe el sistema.");
            }

            if (!string.Equals(tarea.Estado.Nombre.Trim().ToUpper(), "En Proceso".Trim().ToUpper(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ApiException("La tarea no se encuentra en estado En Proceso.");
            }

            tarea.IdEstadoTarea = _unitOfWork.EstadoTareaRepository.GetByNombre("Finalizado").Result.Id;

            _unitOfWork.TareaRepository.Update(tarea);

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}