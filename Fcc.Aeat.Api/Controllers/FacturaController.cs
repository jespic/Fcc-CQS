using AutoMapper;
using Fcc.Aeat.Api.Models;
using Fcc.Aeat.Factura.Contracts.Commands;
using Fcc.Aeat.Factura.Contracts.Models;
using Fcc.Aeat.Factura.Queries.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fcc.Aeat.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IMediator _mediator; //para las transacciones. Funciona con eventos.
        private readonly IFacturaQueries _facturaQueries; //para las queries. Sin eventos en esta implementación
        private readonly IMapper _mapper;

        public FacturaController(IFacturaQueries facturaQueries, IMediator mediator, IMapper mapper)
        {
            _facturaQueries = facturaQueries;
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var factura = await _facturaQueries.GetById(id);
                    return Ok(_mapper.Map<FacturaResponse>(factura));
            }
            catch(System.Exception ex)
            {
                return BadRequest(new ProblemDetails
                {
                    Status = 500,
                    Detail = ex.Message
                });
            }
        }


        // POST api/<FacturaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FacturaRequestDto facturaRequestDto)
        {
            var facturaAddCommand = FacturaRequestDto.MapToFacturaAddCommand(facturaRequestDto);
            var facturaResponse = await _mediator.Send(facturaAddCommand);

            return Ok(_mapper.Map<FacturaResponseDto>(facturaResponse));
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FacturaRequestDto facturaRequestDto)
        {
            var facturaUpdateCommand = _mapper.Map<FacturaUpdateCommand>(facturaRequestDto);
            facturaUpdateCommand.Id = id;
            var facturaResponse = await _mediator.Send(facturaUpdateCommand);

            return Ok(_mapper.Map<FacturaResponseDto>(facturaResponse));
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var facturaDeleteCommand = FacturaRequestDto.MapToFacturaDeleteCommand(id);
            var deleted = await _mediator.Send(facturaDeleteCommand);

            return Ok(deleted);
        }
    }
}
