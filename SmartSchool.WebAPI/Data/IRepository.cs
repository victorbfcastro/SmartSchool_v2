using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //ALUNOS
        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoId(int alunoId, bool includeProfessor = false);

        //PROFESSORES
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplinaId();
        Professor GetProfessorById();

    }
}