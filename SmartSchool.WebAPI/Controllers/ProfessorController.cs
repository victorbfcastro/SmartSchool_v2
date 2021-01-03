using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly SmartContext _context;

        public ProfessorController(SmartContext context)    //Recebe nosso banco de dados como context
        {
            _context = context;
        }

        //Rota /api/professor
        [HttpGet]   //Pega todos os professores
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        //Rota /api/professor/byid/1
        [HttpGet("byId/{id}")]  //Pega um professor pelo Id
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest($"'{professor.Nome}' não encontrado!");

            return Ok(professor);
        }
        //Rota /api/aluno/byname?name=Paulo
        [HttpGet("byName")] //Pega um professor pelo nome
        public IActionResult GetByName(string nome)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            if (professor == null) return BadRequest($"'{professor.Nome}' não encontrado!");

            return Ok(professor);
        }

        // Rota /api/aluno
        [HttpPost]   //Adiciona ao banco de dados
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok($"'{professor.Nome}' adicionado com sucesso!");
        }

        // Rota /api/professor/1
        [HttpPut("{id}")]   //Atualiza o banco de dados
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest($"'{professor.Nome}' não encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok($"Professor atualizado com sucesso!");
        }

        // Rota /api/professor/1
        [HttpPatch("{id}")]   //Atualiza o banco de dados
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest($"'{prof.Nome}' não foi encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok("Professor foi atualizado com sucesso!");
        }
        
        // Rota /api/professor/1
        [HttpDelete("{id}")]   //Pega todos os professores
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(professor == null) return BadRequest($"Aluno não foi encontrado!");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok($"'{professor.Nome}' deletado com sucesso!");

        }
    }
}