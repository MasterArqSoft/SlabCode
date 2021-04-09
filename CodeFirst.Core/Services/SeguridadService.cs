using CodeFirst.Core.DTOs;
using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Enums;
using CodeFirst.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Core.Services
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IPasswordService _passwordService;

        public SeguridadService(
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            IPasswordService passwordService
            )
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _passwordService = passwordService;
        }

        public async Task<Seguridad> GetLoginByCredentials(Login userLogin)
        {
            return await _unitOfWork.SeguridadRepository.GetLoginByCredentials(userLogin).ConfigureAwait(false);
        }

        public async Task RegisterUser(SeguridadDto seguridadDto)
        {
            Seguridad _seguridad = new();
            Usuario usuario = new();
            string password = Helper.STDFunctions.GenerarContraseña();
            _seguridad.UserName = seguridadDto.Nombres;
            _seguridad.User = seguridadDto.User;
            _seguridad.Password = _passwordService.Hash(password);
            _seguridad.Activo = seguridadDto.IsActive;
            _seguridad.Email = seguridadDto.Email;
            _seguridad.Role = seguridadDto.Role;

            usuario.Nombres = seguridadDto.Nombres;
            usuario.Apellidos = seguridadDto.Apellidos;
            usuario.Email = seguridadDto.Email;
            usuario.IsActive = true;


            await _unitOfWork.SeguridadRepository.Add(_seguridad).ConfigureAwait(false);
            await _unitOfWork.UsuarioRepository.Add(usuario).ConfigureAwait(false);

            _emailService.Send(seguridadDto.Email, "Password usuario", $"<p>Contraseña: {password} </p>");

            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

        }

        public async Task UpdateUser(UserDto user)
        {
            Seguridad security = _unitOfWork.SeguridadRepository.GetAll().Where(x => x.User == user.Usuario).FirstOrDefault();
            if (security == null)
            {
                throw new ApiException("El usuario no existe en el sistema.");
            }

            if (user.Estado)
            {
                security.Activo = Estado.Habilitado;
            }
            else
            {
                security.Activo = Estado.inhabilitado;
            }

            _unitOfWork.SeguridadRepository.Update(security);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}