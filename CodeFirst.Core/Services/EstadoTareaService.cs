using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class EstadoTareaService : IEstadoTareaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoTareaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstadoTarea> GetEstadoTarea(int id)
        {
            return await _unitOfWork.EstadoTareaRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task InsertEstadoTarea(EstadoTarea estadoPoryecto)
        {
            await _unitOfWork.EstadoTareaRepository.Add(estadoPoryecto).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateEstadoTarea(EstadoTarea estadoPoryecto)
        {
            EstadoTarea existingEstadoTarea = await _unitOfWork.EstadoTareaRepository.GetById(estadoPoryecto.Id).ConfigureAwait(false);
            existingEstadoTarea.Nombre = estadoPoryecto.Nombre;

            _unitOfWork.EstadoTareaRepository.Update(existingEstadoTarea);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteTarea(int id)
        {
            await _unitOfWork.EstadoTareaRepository.Delete(id).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<EstadoTarea> GetByNombre(string nombreEstadoTarea)
        {
            return await _unitOfWork.EstadoTareaRepository.GetByNombre(nombreEstadoTarea).ConfigureAwait(false);
        }
    }
}