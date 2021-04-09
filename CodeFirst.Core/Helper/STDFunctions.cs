using CodeFirst.Core.Exceptions;
using System;

namespace CodeFirst.Core.Helper
{
    public static class STDFunctions
    {
        public static bool FechaMayorOIgualActual(DateTime? datetime)
        {
            if (!string.IsNullOrEmpty(datetime.ToString()))
            {
                return datetime >= DateTime.Now;
            }

            throw new ApiException("La fecha no puede vacioo nulo.");
        }

        public static bool FechaMayorAlActual(DateTime? datetime)
        {
            if (!string.IsNullOrEmpty(datetime.ToString()))
            {
                return datetime > DateTime.Now;
            }

            throw new ApiException("La fecha no puede vacio nulo.");
        }

        public static string GenerarContraseña()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }
    }
}