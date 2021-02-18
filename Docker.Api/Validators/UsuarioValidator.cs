using Docker.Domain.Entities;
using FluentValidation;

namespace Docker.Api.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator(IValidator<Endereco> enderecoValidator)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail inválido").EmailAddress();
            RuleFor(x => x.Nascimento).NotEmpty().WithMessage("Data de nascimento inválida");
            RuleFor(x => x.Endereco).SetValidator(enderecoValidator).When(x => x.Endereco is not null);
        }
    }
}
