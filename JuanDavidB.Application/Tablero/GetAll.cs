using AutoMapper;
using JuanDavidB.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JuanDavidB.Application.Tablero
{
    public class GetAll
    {
        public class QueryGetAllTableros : IRequest<List<TableroDto>>
        {
        }

        public class Handler : IRequestHandler<QueryGetAllTableros, List<TableroDto>>
        {
            private readonly JuanDavidBContext _context;
            private readonly IMapper _mapper;

            public Handler(JuanDavidBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<TableroDto>> Handle(QueryGetAllTableros request, CancellationToken cancellationToken)
            {
                var tableros = await _context.Tableros.ToListAsync(cancellationToken: cancellationToken);

                var tablerosFiltrados = _context.Tableros
                    .AsEnumerable()
                    .OrderByDescending(x => x.TotalPeso)
                    .GroupBy(x => x.Deportista)
                    .Select(x => x.FirstOrDefault())
                    .ToList();
                
                var tablerosDto = _mapper.Map<List<TableroDto>>(tablerosFiltrados);
                return tablerosDto;
            }
        }
    }
}