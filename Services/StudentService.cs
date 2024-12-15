using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
	public class StudentService : IStudentService
	{
		private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public StudentService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateStudent(Student student)
        {
            _manager.Student.CreateStudent(student);
            _manager.Save();
        }

        public void DeactivateStudent(int id)
        {
            var student = _manager.Student.GetStudentById(id, false);
            var studentDto = new StudentDtoForDeactivate { StudentId = id , FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, Status = "Inactive" };
            var entity = _mapper.Map<Student>(studentDto);
            _manager.Student.UpdateOneStudent(entity);
            _manager.Save();
        }

        public int GetActiveStudentsCount()
        {
            int activeStudentsCount = _manager.Student.GetAllStudents(false).Where(s => s.Status == "Active").Count();
            return activeStudentsCount;
        }

        public IQueryable<Student> GetAllStudents(bool trackChanges)
        {
            return _manager.Student.GetAllStudents(trackChanges);
        }

        public Student GetStudentById(int id, bool trackChanges)
        {
            return _manager.Student.GetStudentById(id, trackChanges);
        }

        public void UpdateOneStudent(StudentDtoForUpdate studentDto)
        {
            var entity = _mapper.Map<Student>(studentDto);
            _manager.Student.UpdateOneStudent(entity);
            _manager.Save();
        }
    }
}