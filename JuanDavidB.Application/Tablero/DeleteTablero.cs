using JuanDavidB.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JuanDavidB.Application.Tablero
{
    public class DeleteTablero
    {
        public class CommandDeleteTablero : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<CommandDeleteTablero>
        {
            private readonly JuanDavidBContext _context;

            public Handler(JuanDavidBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CommandDeleteTablero request, CancellationToken cancellationToken)
            {
                var tablero = await _context.Tableros.FindAsync(request.Id);
                if (tablero == null)
                    throw new Exception("El tablero no existe");

                _context.Tableros.Remove(tablero);
                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0)
                    return Unit.Value;
                throw new Exception("No se pudo eliminar el tablero");
            }
        }
    }
}