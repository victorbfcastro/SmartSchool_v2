using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        
        public Repository(SmartContext context)
        {
            _context = context;
        }

        // Métodos HTML

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        // Métodos ALUNOS

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor){
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor){
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         //.OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        // Métodos PROFESSORES
        public Professor[] GetAllProfessores(bool includeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplina){
                query = query.Include(d => d.Disciplina)
                             .ThenInclude(a => a.AlunosDisciplinas)
                             .ThenInclude(al => al.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeDisciplina){
                query = query.Include(d => d.Disciplina);
            }

            query = query.AsNoTracking()
                         .Where(prof => prof.Id == professorId);

            return query.FirstOrDefault();
        }

        // Métodos DISCIPLINAS
         public Disciplina[] GetAllDisciplinas(bool includeProfessor = false)
        {
            IQueryable<Disciplina> query = _context.Disciplinas;

            // if(includeAlunos){
            //     query = query.Include(d => d.AlunosDisciplinas)
            //                  .ThenInclude(ad => ad.Aluno);
            // }

            if(includeProfessor){
                query = query.Include(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(d => d.Id);

            return query.ToArray();
        }

        public Disciplina GetDisciplinaById(int disciplinaId, bool includeProfessor)
        {
            IQueryable<Disciplina> query = _context.Disciplinas;

            if(includeProfessor){
                query = query.Include(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .Where(disc => disc.Id == disciplinaId);
                         
            return query.FirstOrDefault();
        }
    }
}