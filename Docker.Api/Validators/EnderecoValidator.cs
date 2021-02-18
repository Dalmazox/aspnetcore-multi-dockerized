using Docker.Domain.Entities;
using FluentValidation;

namespace Docker.Api.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.Rua).NotEmpty().WithMessage("Rua inválida");
            RuleFor(x => x.Numero).NotEmpty().WithMessage("Número inválido").GreaterThan(0).WithMessage("Número inválido");
        }
    }
}
