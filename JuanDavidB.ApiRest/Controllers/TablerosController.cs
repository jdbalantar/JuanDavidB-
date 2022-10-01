using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using JuanDavidB.Application;
using JuanDavidB.Application.Tablero;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JuanDavidB.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablerosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TablerosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TableroDto>>> TableroList() =>
            await _mediator.Send(new GetAll.QueryGetAllTableros());


        [HttpGet("{id:int}")]
        public async Task<ActionResult<TableroDto>> Tablero(int id) =>
            await _mediator.Send(new GetById.QueryGetTablero {Id = id});

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateTablero(Create.CommandCreateTablero data) =>
            await _mediator.Send(data);

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unit>> UpdateTableror(int id, Edit.CommandEditTablero data)
        {
            data.Id = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unit>> DeleteTablero(int id) =>
            await _mediator.Send(new DeleteTablero.CommandDeleteTablero {Id = id});
    }
}