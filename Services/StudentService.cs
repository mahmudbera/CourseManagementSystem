using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class StudentService : IStudentService
	{
		private readonly IRepositoryManager _manager;

        public StudentService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateStudent(Student student)
        {
            _manager.Student.CreateStudent(student);
            _manager.Save();
        }

        public void DeleteStudent(int id)
        {
            var student = _manager.Student.GetStudentById(id, true);
            student.Status = "Deactive";
            _manager.Save();
        }

        public IQueryable<Student> GetAllStudents(bool trackChanges)
        {
            return _manager.Student.GetAllStudents(trackChanges);
        }

        public Student GetStudentById(int id, bool trackChanges)
        {
            return _manager.Student.GetStudentById(id, trackChanges);
        }
    }
}