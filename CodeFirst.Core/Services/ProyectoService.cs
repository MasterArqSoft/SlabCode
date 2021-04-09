using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Helper;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class ProyectoService : IProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Proyecto> GetProyecto(int id)
        {
            return await _unitOfWork.ProyectoRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task InsertProyecto(Proyecto proyecto)
        {
            if (!STDFunctions.FechaMayorOIgualActual(proyecto.FechaInicio))
            {
                throw new ApiException("Fecha de incio debe ser igual o superior a la fecha actual.");
            }

            if (string.IsNullOrEmpty(proyecto.FechaFinalizacion.ToString()))
            {
                proyecto.FechaFinalizacion = proyecto.FechaInicio.AddDays(1);
            }

            if (!(proyecto.FechaFinalizacion > proyecto.FechaInicio))
            {
                throw new ApiException("Fecha de finalización debe ser posterior al día inicial.");
            }

            await _unitOfWork.ProyectoRepository.Add(proyecto).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateProyecto(Proyecto proyecto)
        {
            Proyecto existingProyecto = await _unitOfWork.ProyectoRepository.GetById(proyecto.Id).ConfigureAwait(false);
            existingProyecto.Nombre = proyecto.Nombre;
            existingProyecto.Descripcion = proyecto.Descripcion;

            if (await _unitOfWork.TareaRepository.QueryMayorbyFechaEjecucion(proyecto.FechaFinalizacion ?? DateTime.MinValue).ConfigureAwait(false))
            {
                throw new ApiException("No se puede modificar la Fecha Finalizacion si existen tareas con fechas de ejecución posteriores a la nueva fecha de finalización.");
            }
            existingProyecto.FechaFinalizacion = proyecto.FechaFinalizacion;

            _unitOfWork.ProyectoRepository.Update(existingProyecto);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteProyecto(int id)
        {
            await _unitOfWork.ProyectoRepository.Delete(id).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> RagonFecha(DateTime fecha)
        {
            return await _unitOfWork.ProyectoRepository.RagonFecha(fecha).ConfigureAwait(false);
        }
    }
}