using FluentValidation;

namespace Sprencia_Api.Entities.API.Actividades.Requests.Update
{
    public class UpdateActividadRequestValidator : AbstractValidator<UpdateActividadRequest>
    {
        int caracterDescription = 10;
        public UpdateActividadRequestValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El campo nombre no puede estar vacio")
                .NotNull().WithMessage("El campo nombre debe tener un formato correcto")
                .MinimumLength(3).WithMessage("El campo nombre debe tener como mínimo 3 caracteres")
                .MaximumLength(50).WithMessage("El campo no nombre no puede tener más de 30 caracteres");
            RuleFor(x => x.Precio)
                .NotEmpty().WithMessage("La actividad debe contener algún precio")
                .NotNull().WithMessage("El precio no puede ser nulo")
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Resumen)
                .NotEmpty().WithMessage("La descripción no puede estar vacia")
                .NotNull().WithMessage("La descripción debe tener un valor valido")
                .MinimumLength(caracterDescription).WithMessage($"La descripción debe tener como minimo {caracterDescription} caracteres");
        }
    }
}
