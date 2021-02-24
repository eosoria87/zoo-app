using AutoMapper;
using AutoMapper.QueryableExtensions;
using ZooApp.Application.Common.Interfaces;
using ZooApp.Application.Common.Mappings;
using ZooApp.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ZooApp.Application.Animal.Queries.GetAnimalWithPagination
{
    public class GetAnimalWithPaginationQuery : IRequest<PaginatedList<AnimalDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAnimalWithPaginationQueryHandler : IRequestHandler<GetAnimalWithPaginationQuery, PaginatedList<AnimalDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAnimalWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AnimalDto>> Handle(GetAnimalWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Animals
                .OrderBy(x => x.Nombre)
                .ProjectTo<AnimalDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
