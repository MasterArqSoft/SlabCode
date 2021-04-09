using CodeFirst.Core.DTOs;
using FluentValidation;
using System;

namespace CodeFirst.Core.Validator
{
    public class ProyectoValidator : AbstractValidator<ProyectoDto>
    {
        public ProyectoValidator()
        {
            RuleFor(Proyecto => Proyecto.Nombre)
                .NotNull()
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es requerido");
            

            RuleFor(Proyecto => Proyecto.Descripcion)
                .NotNull()
                .NotEmpty()
                .WithMessage("El campo {PropertyName} es requerido");

            RuleFor(Proyecto => Proyecto.FechaInicio)
                .NotNull()
                .NotEmpty()
                .WithMessage("La campo {PropertyName} es requerido")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("El campo {PorpertyName} debe ser igual o superior a la fecha actual.");

            RuleFor(Proyecto => Proyecto.FechaFinalizacion)
                .NotNull()
                .NotEmpty()
                .WithMessage("La campo {PropertyName} es requerido")
                .GreaterThan(DateTime.Today).WithMessage("El campo {PorpertyName} debe ser superior a la fecha actual.");
        }
    }
}