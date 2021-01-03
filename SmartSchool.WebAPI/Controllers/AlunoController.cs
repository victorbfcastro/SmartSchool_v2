using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly SmartContext _context;

        public AlunoController(SmartContext context)    //Recebe nosso banco de dados como context
        {
            _context = context;
        }

        //Rota /api/aluno
        [HttpGet]   //Pega todos os alunos
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //Rota /api/aluno/byid/1
        [HttpGet("byId/{id}")]  //Pega um aluno pelo Id
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest($"'{aluno.Nome}' não encontrado!");

            return Ok(aluno);
        }
        //Rota /api/aluno/byname?name=Paulo&sobrenome=José
        [HttpGet("byName")] //Pega um aluno pelo nome e sobrenome via querystring (?nome=Exemplo&sobrenome=Exemplo)
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest($"'{aluno.Nome}' não encontrado!");

            return Ok(aluno);
        }

        // Rota /api/aluno
        [HttpPost]   //Adiciona ao banco de dados
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok($"'{aluno.Nome}' adicionado com sucesso!");
        }

        // Rota /api/aluno/1
        [HttpPut("{id}")]   //Atualiza o banco de dados
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest($"'{aluno.Nome}' não encontrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok($"Aluno atualizado com sucesso!");
        }

        // Rota /api/aluno/1
        [HttpPatch("{id}")]   //Atualiza o banco de dados
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alu == null) return BadRequest($"'{aluno.Nome}' não foi encontrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok("Aluno foi atualizado com sucesso!");
        }
        
        // Rota /api/aluno/1
        [HttpDelete("{id}")]   //Pega todos os alunos
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest($"Aluno não foi encontrado!");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok($"'{aluno.Nome}' deletado com sucesso!");

        }
    }
}