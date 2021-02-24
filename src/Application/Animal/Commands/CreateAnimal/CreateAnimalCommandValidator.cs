using FluentValidation;

namespace ZooApp.Application.Animal.Commands.CreateAnimal
{
    public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        public CreateAnimalCommandValidator()
        {
            RuleFor(v => v.Nombre)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}
