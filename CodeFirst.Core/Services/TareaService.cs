using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class TareaService : ITareaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TareaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tarea> GetTarea(int id)
        {
            return await _unitOfWork.TareaRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task InsertTarea(Tarea tarea)
        {
            if (tarea.IdProyecto.Equals(0))
            {
                throw new ApiException("Debe seleccionar un proyecto");
            }
            if (await _unitOfWork.ProyectoRepository.RagonFecha(tarea.FechaEjecucion).ConfigureAwait(false))
            {
                throw new ApiException("La Fecha Ejecucion debe estar en el rango de fechas de inicio y final del proyecto");
            }

            await _unitOfWork.TareaRepository.Add(tarea).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateTarea(Tarea tarea)
        {
            Tarea existingTarea = await _unitOfWork.TareaRepository.GetById(tarea.Id).ConfigureAwait(false);
            existingTarea.Nombre = tarea.Nombre;
            existingTarea.Descripcion = tarea.Descripcion;
            existingTarea.FechaEjecucion = tarea.FechaEjecucion;

            if (await _unitOfWork.ProyectoRepository.RagonFecha(existingTarea.FechaEjecucion).ConfigureAwait(false))
            {
                throw new ApiException("La Fecha Ejecucion debe estar en el rango de fechas de inicio y final del proyecto");
            }

            _unitOfWork.TareaRepository.Update(existingTarea);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteTarea(int id)
        {
            await _unitOfWork.TareaRepository.Delete(id).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> QueryMayorbyFechaEjecucion(DateTime fecha)
        {
            return await _unitOfWork.TareaRepository.QueryMayorbyFechaEjecucion(fecha).ConfigureAwait(false);
        }

        public Task<IEnumerable<Tarea>> SearchIdProyecto(int idProyecto)
        {
            return _unitOfWork.TareaRepository.SearchIdProyecto(idProyecto);
        }
    }
}