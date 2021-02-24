using ZooApp.Application.Common.Interfaces;
using ZooApp.Domain.Entities;
using ZooApp.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.Commands.CreateAnimal
{
    public class CreateAnimalCommand : IRequest<int>
    {
        //public  int Id { get; set; }
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Comida { get; set; }
    }

    public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAnimalCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = new AnimalEntity
            {
                Nombre = request.Nombre,
                Raza = request.Raza,
                Edad = request.Edad,
                Genero = request.Genero,
                Comida = request.Comida
            };

            entity.DomainEvents.Add(new AnimalCreatedEvent(entity));

            _context.Animals.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
