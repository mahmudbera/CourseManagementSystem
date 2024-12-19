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

        public IQueryable<Student> GetAllStudents(bool trackChanges)
        {
            return _manager.Student.GetAllStudents(trackChanges);
        }

        public Student GetStudentById(int id, bool trackChanges)
        {
            return _manager.Student.GetStudentById(id, trackChanges);
        }

        public int GetActiveStudentsCount()
        {
            int activeStudentsCount = _manager.Student.GetAllStudents(false).Where(s => s.Status == "Active").Count();
            return activeStudentsCount;
        }

        public (bool isSuccess, string message) CreateStudent(Student student)
        {
            var existingStudent = _manager.Student
                .GetAllStudents(false)
                .FirstOrDefault(s => s.Email == student.Email);

            if (existingStudent != null)
                return (false, "A student with the same email already exists.");

            _manager.Student.CreateStudent(student);
            bool result = _manager.Save();

            if (result)
                return (true, "Student successfully created.");
            else
                return (false, "Failed to create student.");
        }

        public (bool isSuccess, string message) DeactivateStudent(int id)
        {
            var student = _manager.Student.GetStudentById(id, false);
            if (student == null)
                return (false, "Student not found.");

            bool hasEnrollments = checkEnrollments(id);
            if (!hasEnrollments)
                return (false, "The student has incomplete grades in their enrollments.");

            var studentDto = new StudentDtoForDeactivate
            {
                StudentId = id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Status = "Inactive"
            };
            var entity = _mapper.Map<Student>(studentDto);
            _manager.Student.UpdateOneStudent(entity);
            _manager.Save();

            return (true, "Student successfully deactivated.");
        }

        public (bool isSuccess, string message) UpdateOneStudent(StudentDtoForUpdate studentDto)
        {
            var student = _manager.Student.GetStudentById(studentDto.StudentId, false);

            var existingStudent = _manager.Student
                .GetAllStudents(false)
                .FirstOrDefault(s => s.StudentId != studentDto.StudentId && s.Email == studentDto.Email);

            if (existingStudent != null)
                return (false, "A student with the same email already exists.");

            bool hasEnrollments = checkEnrollments(student.StudentId);
            if (!hasEnrollments)
                return (false, "The student has incomplete grades in their enrollments.");

            var entity = _mapper.Map<Student>(studentDto);
            _manager.Student.UpdateOneStudent(entity);

            bool result = _manager.Save();
            if (result)
                return (true, "Student successfully updated.");
            else
                return (false, "Failed to update student.");
        }
    
        private bool checkEnrollments(int id)
        {
            var student = _manager.Student.GetStudentById(id, false);
            var enrollments = student.Enrollments;
            if (enrollments != null && enrollments.Any(e => e.Grade == null))
                return false;
            return true;
        }
    }
}