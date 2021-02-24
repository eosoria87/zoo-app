using FluentValidation;

namespace ZooApp.Application.Animal.Queries.GetAnimalWithFilterAndPagination
{
    public class GetAnimalWithFilterAndPaginationQueryValidator : AbstractValidator<GetAnimalWithFilterAndPaginationQuery>
    {
        public GetAnimalWithFilterAndPaginationQueryValidator()
        {
            //RuleFor(x => x.Nombre).Empty().WithMessage("Nombre is not Empty.");
            //RuleFor(x => x.Genero).Empty().WithMessage("Genero is not Empty.");
            //RuleFor(x => x.Raza).Empty().WithMessage("Raza is not Empty.");
            //RuleFor(x => x.Edad).GreaterThanOrEqualTo(1).WithMessage("Edad at least greater than or equal to 1.");
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
