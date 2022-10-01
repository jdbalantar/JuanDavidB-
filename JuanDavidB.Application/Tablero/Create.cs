using JuanDavidB.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JuanDavidB.Application.Tablero
{
    public class Create
    {
        public class CommandCreateTablero : IRequest
        {
            public string Deportista { get; set; }
            public int Arranque { get; set; }
            public int Envion { get; set; }
            public string Pais { get; set; }
        }

        public class Handler : IRequestHandler<CommandCreateTablero>
        {
            private readonly JuanDavidBContext _context;

            public Handler(JuanDavidBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandCreateTablero request, CancellationToken cancellationToken)
            {
                var tablero = new Domain.Tablero
                {
                    Deportista = request.Deportista,
                    Arranque = request.Arranque,
                    Envion = request.Envion,
                    TotalPeso = request.Envion + request.Arranque,
                    Pais = request.Pais,
                };

                _context.Tableros.Add(tablero);

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;
                throw new Exception("Error al crear el tablero");
            }
        }
    }
}