using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Interfaces;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class EstadoProyectoService : IEstadoProyectoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadoProyectoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EstadoProyecto> GetEstadoProyecto(int id)
        {
            return await _unitOfWork.EstadoProyectoRepository.GetById(id).ConfigureAwait(false);
        }

        public async Task InsertEstadoProyecto(EstadoProyecto estadoPoryecto)
        {
            await _unitOfWork.EstadoProyectoRepository.Add(estadoPoryecto).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> UpdateEstadoProyecto(EstadoProyecto estadoPoryecto)
        {
            EstadoProyecto existingEstadoProyecto = await _unitOfWork.EstadoProyectoRepository.GetById(estadoPoryecto.Id).ConfigureAwait(false);
            existingEstadoProyecto.Nombre = estadoPoryecto.Nombre;

            _unitOfWork.EstadoProyectoRepository.Update(existingEstadoProyecto);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteProyecto(int id)
        {
            await _unitOfWork.EstadoProyectoRepository.Delete(id).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<EstadoProyecto> GetByNombre(string nombreEstadoProyecto)
        {
            return await _unitOfWork.EstadoProyectoRepository.GetByNombre(nombreEstadoProyecto).ConfigureAwait(false);
        }
    }
}