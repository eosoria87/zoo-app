using ZooApp.Application.Common.Exceptions;
using ZooApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.Commands.DeleteAnimal
{
    public class DeleteAnimalCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteAnimalCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Animals.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Animal), request.Id);
            }

            _context.Animals.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
