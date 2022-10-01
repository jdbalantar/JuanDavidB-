using JuanDavidB.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JuanDavidB.Application.Tablero
{
    public class Edit
    {
        public class CommandEditTablero : IRequest
        {
            public int Id { get; set; }
            public string Deportista { get; set; }
            public string Pais { get; set; }
            public int? Arranque { get; set; }
            public int? Envion { get; set; }
        }

        public class Handler : IRequestHandler<CommandEditTablero>
        {
            private readonly JuanDavidBContext _context;

            public Handler(JuanDavidBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandEditTablero request, CancellationToken cancellationToken)
            {
                var tablero = await _context.Tableros.FindAsync(request.Id);
                if (tablero == null)
                    throw new Exception("El tablero no existe");

                tablero.Deportista = request.Deportista ?? tablero.Deportista;
                tablero.Pais = request.Pais ?? tablero.Pais;
                tablero.Arranque = request.Arranque ?? tablero.Arranque;
                tablero.Envion = request.Envion ?? tablero.Envion;
                tablero.TotalPeso = (request.Envion + request.Arranque) ?? tablero.TotalPeso;

                var value = await _context.SaveChangesAsync(cancellationToken);

                if (value > 0)
                    return Unit.Value;

                throw new Exception("No se pudieron guardar los cambios");
            }
        }
    }
}