using Entities.Models;

namespace Services.Contracts
{
	public interface IStudentService
	{
		IQueryable<Student> GetAllStudents(bool trackChanges);
		void CreateStudent(Student student);
		Student GetStudentById(int id, bool trackChanges);
		void DeleteStudent(int id);
	}
}