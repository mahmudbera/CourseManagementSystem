using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
	public class StudentRepository : RepositoryBase<Student>, IStudentRepository
	{
		public StudentRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{
		}

        public void CreateStudent(Student student)
        {
			Create(student);
        }

        public IQueryable<Student> GetAllStudents(bool trackChanges)
        {
            return FindAll(trackChanges);
        }

        public Student GetStudentById(int id, bool trackChanges)
        {
            return FindByCondition(s => s.StudentId.Equals(id), trackChanges).SingleOrDefault();
        }

        public void UpdateOneStudent(Student student) => Update(student);
    }
}