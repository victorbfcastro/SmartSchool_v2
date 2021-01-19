// using System.Threading.Tasks;
// using SmartSchool.WebAPI.Helpers;
// using SmartSchool.WebAPI.Models;

// namespace SmartSchool.WebAPI.Data
// {
//     public interface IRepository
//     {
//         void Add<T>(T entity) where T : class;
//         void Update<T>(T entity) where T : class;
//         void Delete<T>(T entity) where T : class;
//         bool SaveChanges();

//         //ALUNOS
//         Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
//         Aluno[] GetAllAlunos(bool includeProfessor);
//         Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor);
//         Aluno GetAlunoById(int alunoId, bool includeProfessor=false);
        
//         //PROFESSORES
//         Task<Professor[]> GetAllProfessoresAsync(bool includeDisciplina);
//         Professor[] GetAllProfessores(bool includeDisciplina);
//         Task<Professor> GetProfessorByIdAsync(int professorId, bool includeDisciplina);
//         Professor GetProfessorById(int professorId, bool includeDisciplina);
//         Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos);

//         //DISCIPLINAS
//         Task<Disciplina[]> GetAllDisciplinasAsync(bool includeProfessor);
//         Disciplina[] GetAllDisciplinas(bool includeProfessor);
//         Task<Disciplina> GetDisciplinaByIdAsync(int disciplinaId, bool includeProfessor);
//         Disciplina GetDisciplinaById(int disciplinaId, bool includeProfessor);

//     }
// }

using System.Collections.Generic;
using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Aluno
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);        
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Task<Aluno[]> GetAllAlunosByDisciplinaIdAsync(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        // professor
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);
        Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
    }
}