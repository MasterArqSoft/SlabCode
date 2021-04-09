using CodeFirst.Core.DTOs;
using CodeFirst.Core.Interfaces;
using CodeFirst.Domain.Entities;
using CodeFirst.Domain.Enums;
using CodeFirst.Domain.Interfaces;
using CodeFirst.Web.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISeguridadService _seguridadService;
        private readonly IPasswordService _passwordService;
        private readonly IUnitOfWork _unitOfWork;

        public TokenController(
            IConfiguration configuration,
            ISeguridadService seguridadService,
            IPasswordService passwordService,
            IUnitOfWork unitOfWork
            )
        {
            _configuration = configuration;
            _seguridadService = seguridadService;
            _passwordService = passwordService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(Login login)
        {
            //if it is a valid user
            (bool, Seguridad) validation = await IsValidUser(login).ConfigureAwait(false);
            if (validation.Item1)
            {
                string token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool, Seguridad)> IsValidUser(Login login)
        {
            Seguridad user = await _seguridadService.GetLoginByCredentials(login).ConfigureAwait(false);
            bool habilitado = user.Activo == Estado.Habilitado;
            bool isValid = false;
            if (habilitado)
            {
                isValid = _passwordService.Check(user.Password, login.Password);
            }
            return (isValid, user);
        }

        private string GenerateToken(Seguridad security)
        {
            //Header
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(signingCredentials);

            //Claims
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("User", security.User),
                new Claim(ClaimTypes.Role, security.Role.ToString()),
            };

            //Payload
            JwtPayload payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            JwtSecurityToken token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut]
        public async Task<IActionResult> CambiarPassword(CambioPasswordDto nuevoLogin)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            Login login = new();

            login.Usuario = nuevoLogin.Usuario;
            login.Password = nuevoLogin.Password;

            Seguridad user = await _seguridadService.GetLoginByCredentials(login).ConfigureAwait(false);
            bool isValid = _passwordService.Check(user.Password, login.Password);

            if (!isValid)
            {
                response.Succeeded = false;
                response.Message = "Contraseña actual no coincide";
            }
            else
            {
                user.Password = _passwordService.Hash(nuevoLogin.NuevoPassword);
                _unitOfWork.SeguridadRepository.Update(user);
                await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);

                response.Succeeded = true;
                response.Message = "Contraseña actualizada";
            }
            return Ok(response);
        }
    }
}