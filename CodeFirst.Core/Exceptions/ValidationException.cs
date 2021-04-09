using CodeFirst.Domain.Settings;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CodeFirst.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Se han producido uno o más errores de validación.")
        {
            Errors = new List<ErrorSetting>();
        }

        public List<ErrorSetting> Errors { get; }

        public ValidationException(List<ErrorSetting> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(new ErrorSetting()
                {
                    PropertyName = failure.PropertyName,
                    ErrorMessage = failure.ErrorMessage,
                });
            }
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
