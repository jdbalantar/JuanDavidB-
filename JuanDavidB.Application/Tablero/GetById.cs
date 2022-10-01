using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using JuanDavidB.Persistence;
using MediatR;

namespace JuanDavidB.Application.Tablero
{
    public class GetById
    {
        public class QueryGetTablero : IRequest<TableroDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<QueryGetTablero, TableroDto>
        {
            private readonly JuanDavidBContext _context;
            private readonly IMapper _mapper;

            public Handler(JuanDavidBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<TableroDto> Handle(QueryGetTablero request, CancellationToken cancellationToken)
            {
                var tablero = await _context.Tableros.FindAsync(request.Id);
                if (tablero == null)
                    throw new Exception("No existe el tablero");

                var tableroDto = _mapper.Map<TableroDto>(tablero);
                return tableroDto;
            }
        }
    }
}