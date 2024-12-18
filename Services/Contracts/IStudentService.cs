using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
	public interface IStudentService
	{
		IQueryable<Student> GetAllStudents(bool trackChanges);
		int GetActiveStudentsCount();
		Student GetStudentById(int id, bool trackChanges);
		(bool isSuccess, string message) CreateStudent(Student student);
		(bool isSuccess, string message) DeactivateStudent(int id);
		(bool isSuccess, string message) UpdateOneStudent(StudentDtoForUpdate studentDto);
	}
}