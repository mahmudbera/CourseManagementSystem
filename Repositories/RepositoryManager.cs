using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
		private readonly RepositoryContext _context;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _studentRepository;

        public RepositoryManager(RepositoryContext context, IClassroomRepository classroomRepository, ICourseRepository courseRepository, IEnrollmentRepository enrollmentRepository, IInstructorRepository instructorRepository, IStudentRepository studentRepository)
        {
            _context = context;
            _classroomRepository = classroomRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
        }

        public IClassroomRepository Classroom => _classroomRepository;
        public ICourseRepository Course => _courseRepository;
        public IEnrollmentRepository Enrollment => _enrollmentRepository;
        public IInstructorRepository Instructor => _instructorRepository;
        public IStudentRepository Student => _studentRepository;

        public void Save()
        {
			_context.SaveChanges();
        }
    }
}