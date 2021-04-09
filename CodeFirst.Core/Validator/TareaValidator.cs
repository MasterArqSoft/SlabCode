using CodeFirst.Core.DTOs;
using FluentValidation;

namespace CodeFirst.Core.Validator
{
    public class TareaValidator : AbstractValidator<TareaDto>
    {
        public TareaValidator()
        {
            RuleFor(Tarea => Tarea.Nombre)
                .NotNull()
                .NotEmpty()
                .WithMessage("El nombre no puede ser nulo ó vacio");

            RuleFor(Tarea => Tarea.Descripcion)
                .NotNull()
                .NotEmpty()
                .WithMessage("La Descripcion no puede ser nulo ó vacio");

            RuleFor(Tarea => Tarea.IdProyecto)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Debe selecionar un proyecto");
        }
    }
}