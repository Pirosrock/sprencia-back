using FluentValidation;
using System.Text.RegularExpressions;

namespace Sprencia_Api.Entities.API.Usuarios.Requests.Create
{
    public class RegisterUsersRequestValidator : AbstractValidator<RegisterUsersRequest>
    {
        const int PasswordMinLength = 8;
        public RegisterUsersRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("El campo username no puede estar vacio")
                .NotNull().WithMessage("El campo username no puede ser nulo")
                .MinimumLength(3).WithMessage("El campo username debe tener como mínimo 3 caracteres");
            RuleFor(x => x.Contraseña)
                .Equal(x => x.RepiteContraseña)
                .MinimumLength(PasswordMinLength)
                .WithMessage($"El password no cumple los criterios de longitud {PasswordMinLength} uso de mayúsculas, minusculas y un digito")
                .Must(HasValidPassword);

        }
        private static bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");

            return lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw);
        }
    }

}
