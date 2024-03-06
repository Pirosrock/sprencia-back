using FluentValidation;

namespace Sprencia_Api.Entities.API.Opiniones.Create
{
    public class CreateOpinionRequestValidator : AbstractValidator<CreateOpinionRequest>
    {
        int caracterText = 10;
        public CreateOpinionRequestValidator()
        {
            RuleFor(x => x.Texto)
                .NotEmpty().WithMessage("Debe incluir alguna opinión")
                .NotNull().WithMessage("El campo texto debe tener un formato correcto")
                .MinimumLength(caracterText).WithMessage($"La opinión debe tener como mínimo {caracterText} caracteres");
            RuleFor(x => x.ActividadId)
                .NotEmpty().WithMessage("La opinión debe tener una actividad asociada")
                .NotNull().WithMessage("Debe ser un valor válido");
            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("Se debe incluir una fecha para la opinión")
                .NotNull().WithMessage("Formato de fecha incorrecto");

        }
    }
}
