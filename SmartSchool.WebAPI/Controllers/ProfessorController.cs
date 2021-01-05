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
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)    //Recebe nosso banco de dados como context
        {
            _repo = repo;
        }

        
        [HttpGet]   
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        
        [HttpGet("{id}")]  
        public IActionResult GetById(int id)
        {
            var result = _repo.GetProfessorById(id, true);
            if(result == null) return BadRequest("O professor não foi encontrado!");

            return Ok(result);
        }

        [HttpGet("disciplinaid/{id}")]  
        public IActionResult GetDisciplinaById(int id)
        {
            var result = _repo.GetProfessorByDisciplinaId(id, true);
            if(result == null) return BadRequest("O professor não foi encontrado!");

            return Ok(result);
        }

        [HttpPost]   
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            };

            return BadRequest($"Professor não cadastrado!");
        }

        
        [HttpPut("{id}")]   
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado!");
            
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            };

            return BadRequest($"Professor não cadastrado!");
        }

        
        [HttpPatch("{id}")]   
        public IActionResult Patch(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest($"Professor não foi encontrado!");
            
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            };

            return BadRequest($"Professor não cadastrado!");
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest($"Professor não foi encontrado!");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok(prof);
            };

            return BadRequest($"Professor não cadastrado!");

        }
    }
}