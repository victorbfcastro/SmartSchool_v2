// using System.Collections.Generic;
// using System.Linq;
// using AutoMapper;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using SmartSchool.WebAPI.Data;
// using SmartSchool.WebAPI.V1.Dtos;
// using SmartSchool.WebAPI.Models;

// namespace SmartSchool.WebAPI.V1.Controllers
// {
//     /// <summary>
//     /// Versão 1.0
//     /// </summary>
//     [ApiController]
//     [ApiVersion("1.0")]
//     [Route("api/v{version:apiVersion}/[controller]")]
//     public class ProfessorController : ControllerBase
//     {

//         private readonly IRepository _repo;
//         private readonly IMapper _mapper;
//         /// <summary>
//         /// 
//         /// </summary>
//         /// <param name="repo"></param>
//         /// <param name="mapper"></param>
//         public ProfessorController(IRepository repo, IMapper mapper)
//         {
//             _mapper = mapper;
//             _repo = repo;
//         }

//         /// <summary>
//         /// Método responsável por retornar todos os professores
//         /// </summary>
//         /// <returns></returns>
//         [HttpGet]
//         public IActionResult Get()
//         {
//             var professor = _repo.GetAllProfessores(true);
//             return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professor));
//         }

//         /// <summary>
//         /// Método responsável por retornar um professor identificado pelo ID
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         [HttpGet("{id}")]
//         public IActionResult GetById(int id)
//         {
//             var professor = _repo.GetProfessorById(id, false);
//             if (professor == null) return BadRequest("O professor não foi encontrado!");

//             var professorDto = _mapper.Map<ProfessorDto>(professor);

//             return Ok(professorDto);
//         }

//         /// <summary>
//         /// Método responsável por retornar um professor através do ID de um Aluno
//         /// </summary>
//         /// <param name="alunoId"></param>
//         /// <returns></returns>
//         [HttpGet("byaluno/{alunoId}")]
//         public IActionResult GetByAlunoId(int alunoId)
//         {
//             var Professores = _repo.GetProfessoresByAlunoId(alunoId, true);
//             if (Professores == null) return BadRequest("Professores não encontrados!");

//             return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(Professores));
//         }

//         /// <summary>
//         /// Método responsável por adicionar um professor
//         /// </summary>
//         /// <param name="model"></param>
//         /// <returns></returns>
//         [HttpPost]
//         public IActionResult Post(ProfessorRegistrarDto model)
//         {

//             var professor = _mapper.Map<Professor>(model);

//             _repo.Add(professor);
//             if (_repo.SaveChanges())
//             {
//                 return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
//             };

//             return BadRequest($"Professor não cadastrado!");
//         }

//         /// <summary>
//         /// Método responsável por atualizar um professor identificado pelo ID
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="model"></param>
//         /// <returns></returns>
//         [HttpPut("{id}")]
//         public IActionResult Put(int id, ProfessorRegistrarDto model)
//         {
//             var professor = _repo.GetProfessorById(id, false);
//             if (professor == null) return BadRequest("Professor não encontrado!");

//             _mapper.Map(model, professor);

//             _repo.Update(professor);
//             if (_repo.SaveChanges())
//             {
//                 return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
//             };

//             return BadRequest($"Professor não atualizado!");
//         }

//         /// <summary>
//         /// Método responsável por atualizar um professor identificado pelo ID
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="model"></param>
//         /// <returns></returns>
//         [HttpPatch("{id}")]
//         public IActionResult Patch(int id, ProfessorRegistrarDto model)
//         {
//             var professor = _repo.GetProfessorById(id, false);
//             if (professor == null) return BadRequest("Professor não encontrado!");

//             _mapper.Map(model, professor);

//             _repo.Update(professor);
//             if (_repo.SaveChanges())
//             {
//                 return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
//             };

//             return BadRequest($"Professor não atualizado!");
//         }

//         /// <summary>
//         /// Método responsável por remover um professor identificado pelo ID
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             var professor = _repo.GetProfessorById(id, false);
//             if (professor == null) return BadRequest($"Professor não foi encontrado!");

//             _repo.Delete(professor);
//             if (_repo.SaveChanges())
//             {
//                 return Ok("Professor removido!");
//             };

//             return BadRequest($"Professor não removido!");

//         }
//     }
// }

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.V1.Controllers
{
    /// <summary>
    /// Versão 1 do meu controlador de Professores
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Professor = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(Professor));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }

        // api/Professor
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _repo.GetProfessorById(id, true);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(Professor);

            return Ok(Professor);
        }

        // api/Professor
        [HttpGet("byaluno/{alunoId}")]
        public IActionResult GetByAlunoId(int alunoId)
        {
            var Professores = _repo.GetProfessoresByAlunoId(alunoId, true);
            if (Professores == null) return BadRequest("Professores não encontrados");

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(Professores));
        }

        // api/Professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var prof = _mapper.Map<Professor>(model);

            _repo.Add(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não cadastrado");
        }

        // api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não Atualizado");
        }

        // api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }

            return BadRequest("Professor não Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id, false);
            if (prof == null) return BadRequest("Professor não encontrado");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("professor deletado");
            }

            return BadRequest("professor não deletado");
        }
    }
}