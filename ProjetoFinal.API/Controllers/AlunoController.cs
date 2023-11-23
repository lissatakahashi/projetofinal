using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        {
            return Ok(context.Alunos!.ToList());
        }

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var alunoModel = context.Alunos!.FirstOrDefault(x => x.Id == id);
            if (alunoModel == null) {
                return NotFound();
            }
            return Ok(alunoModel);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] AlunoModel alunoModel, [FromServices] AppDbContext context)
        {
            context.Alunos!.Add(alunoModel);
            context.SaveChanges();
            return Created($"{alunoModel.Id}", alunoModel);
        }

        [HttpPut("/")]
        public IActionResult Put([FromRoute] int id, [FromBody] AlunoModel alunoModel, [FromServices] AppDbContext context)
        {
            var model = context.Alunos!.FirstOrDefault(x => x.Id == id);
            if (model == null) {
                return NotFound();
            }

            model.Nome = alunoModel.Nome;
            model.Telefone = alunoModel.Telefone;
            model.DataNascimento = alunoModel.DataNascimento;
            model.Diagnostico = alunoModel.Diagnostico;

            context.Alunos!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var model = context.Alunos!.FirstOrDefault(x => x.Id == id);
            if (model == null) {
                return NotFound();
            }

            context.Alunos!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}