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
        Aluno GetAlunoById(int alunoId, bool includeProfessor);

        //PROFESSORES
        Professor[] GetAllProfessores(bool includeDisciplina);
        Professor GetProfessorById(int professorId, bool includeDisciplina);

        //DISCIPLINAS
        Disciplina[] GetAllDisciplinas(bool includeProfessor);
        Disciplina GetDisciplinaById(int disciplinaId, bool includeProfessor);

    }
}