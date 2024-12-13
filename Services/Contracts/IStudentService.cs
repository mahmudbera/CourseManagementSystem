using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IStudentService
	{
		IQueryable<Student> GetAllStudents(bool trackChanges);
		void CreateStudent(Student student);
		Student GetStudentById(int id, bool trackChanges);
		void DeactivateStudent(int id);

		void UpdateOneStudent(StudentDtoForUpdate studentDto);
	}
}