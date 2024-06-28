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
    public class ServicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostServico([FromBody] ServicoDto servicoDto)
        {
            var servico = new Servico
            {
                Nome = servicoDto.Nome,
                Preco = servicoDto.Preco,
                Status = servicoDto.Status
            };

            _context.Servicos.Add(servico);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetServico), new { id = servico.Id }, servico);
        }

        [HttpGet("{id}")]
        public IActionResult GetServico(int id)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null)
            {
                return NotFound();
            }

            return Ok(servico);
        }

        [HttpPut("{id}")]
        public IActionResult PutServico(int id, [FromBody] ServicoDto servicoDto)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null)
            {
                return NotFound();
            }

            servico.Nome = servicoDto.Nome;
            servico.Preco = servicoDto.Preco;
            servico.Status = servicoDto.Status;

            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
