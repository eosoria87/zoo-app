using AutoMapper;
using AutoMapper.QueryableExtensions;
using ZooApp.Application.Common.Interfaces;
using ZooApp.Application.Common.Mappings;
using ZooApp.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.Queries.GetAnimalWithFilterAndPagination
{
    public class GetAnimalWithFilterAndPaginationQuery : IRequest<PaginatedList<AnimalFilterDto>>
    {
        public string Nombre { get; set; }
        public string Raza { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAnimalWithFilterAndPaginationQueryHandler : IRequestHandler<GetAnimalWithFilterAndPaginationQuery, PaginatedList<AnimalFilterDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAnimalWithFilterAndPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AnimalFilterDto>> Handle(GetAnimalWithFilterAndPaginationQuery request, CancellationToken cancellationToken)
        {
            var animalFilter = _context.Animals.AsQueryable();

            if (!string.IsNullOrEmpty(request.Nombre))
                animalFilter = animalFilter.Where(o => o.Nombre.ToUpper().Equals(request.Nombre.ToUpper())).OrderBy(on => on.Nombre);

            if (!string.IsNullOrEmpty(request.Genero))
                animalFilter = animalFilter.Where(o => o.Genero.ToUpper().Equals(request.Genero.ToUpper())).OrderBy(on => on.Nombre);

            if (!string.IsNullOrEmpty(request.Raza))
                animalFilter = animalFilter.Where(o => o.Raza.ToUpper().Equals(request.Raza.ToUpper())).OrderBy(on => on.Nombre);

            if (request.Edad > 0)
                animalFilter = animalFilter.Where(o => o.Edad >= request.Edad && o.Edad <= request.Edad)
                                                 .OrderBy(on => on.Nombre);

            return await animalFilter
                .OrderBy(x => x.Nombre)
                .ProjectTo<AnimalFilterDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
