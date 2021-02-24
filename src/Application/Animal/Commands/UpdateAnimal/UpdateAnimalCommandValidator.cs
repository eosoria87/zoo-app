using FluentValidation;

namespace ZooApp.Application.Animal.Commands.UpdateAnimal
{
    public class UpdateAnimalCommandValidator : AbstractValidator<UpdateAnimalCommand>
    {
        public UpdateAnimalCommandValidator()
        {
            RuleFor(v => v.Nombre)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}
