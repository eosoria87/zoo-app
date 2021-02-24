using ZooApp.Application.Common.Exceptions;
using ZooApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.Commands.UpdateAnimal
{
    public class UpdateAnimalCommand : IRequest
    {
        public  int Id { get; set; }
        public  string Nombre { get; set; }
        public  string Raza { get; set; }
        public  int Edad { get; set; }
        public  string Genero { get; set; }
        public  string Comida { get; set; }
    }

    public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAnimalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Animals.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Animal), request.Id);
            }
            entity.Nombre = request.Nombre;
            entity.Raza = request.Raza;
            entity.Edad = request.Edad;
            entity.Genero = request.Genero;
            entity.Comida = request.Comida;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
