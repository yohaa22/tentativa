using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LojaAPI.Data;
using LojaAPI.Dto;
using LojaAPI.Models;
using System;
using System.Linq;

namespace LojaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContratosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostContrato([FromBody] ContratoDto contratoDto)
        {
            var contrato = new Contrato
            {
                ClienteId = contratoDto.ClienteId,
                ServicoId = contratoDto.ServicoId,
                PrecoCobrado = contratoDto.PrecoCobrado,
                DataContratacao = contratoDto.DataContratacao
            };

            _context.Contratos.Add(contrato);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetContrato), new { id = contrato.Id }, contrato);
        }

        [HttpGet("{id}")]
        public IActionResult GetContrato(int id)
        {
            var contrato = _context.Contratos.Find(id);
            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        [HttpGet("cliente/{clienteId}")]
        public IActionResult GetContratosByCliente(int clienteId)
        {
            var contratos = _context.Contratos
                .Where(c => c.ClienteId == clienteId)
                .ToList();

            return Ok(contratos);
        }
    }
}
