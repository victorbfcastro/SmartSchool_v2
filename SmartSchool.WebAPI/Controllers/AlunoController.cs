using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)    //Recebe nosso banco de dados como context
        {
            _mapper = mapper;
            _repo = repo;

        }

        //Rota /api/aluno
        [HttpGet]   //Pega todos os alunos
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        //Rota /api/aluno/byid/1
        [HttpGet("{id}")]  //Pega um aluno pelo Id
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            return Ok(aluno);
        }

        [HttpGet("disciplinaid/{id}")]  //Pega um aluno pelo Id
        public IActionResult GetByDisciplinaId(int id)
        {
            var aluno = _repo.GetAllAlunosByDisciplinaId(id, true);
            if (aluno == null) return BadRequest("Aluno não encontrado!");

            return Ok(aluno);
        }

        // Rota /api/aluno
        [HttpPost]   //Adiciona ao banco de dados
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };

            return BadRequest($"Aluno não cadastrado!");
        }

        // Rota /api/aluno/1
        [HttpPut("{id}")]   //Atualiza o banco de dados
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não foi encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };

            return BadRequest($"Aluno não atualizado!");
        }

        // Rota /api/aluno/1
        [HttpPatch("{id}")]   //Atualiza o banco de dados
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não foi encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            };

            return BadRequest($"Aluno não atualizado!");
        }

        // Rota /api/aluno/1
        [HttpDelete("{id}")]   //Pega todos os alunos
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não foi encontrado!");

            _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
                return Ok(alu);
            };

            return BadRequest($"Aluno não removido!");
        }
    }
}