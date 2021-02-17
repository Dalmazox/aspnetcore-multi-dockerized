using Docker.Domain.Entities;
using FluentValidation;

namespace Docker.Api.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail inválido").EmailAddress();
            RuleFor(x => x.Nascimento).NotEmpty().WithMessage("Data de nascimento inválida");
        }
    }
}
