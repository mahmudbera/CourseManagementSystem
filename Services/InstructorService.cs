using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public InstructorService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IQueryable<Instructor> GetAllInstructors(bool trackChanges)
        {
            return _manager.Instructor.GetAllInstructors(trackChanges);
        }

        public int GetTotalInstructorsCount()
        {
            var totalInstructors = _manager.Instructor.GetAllInstructors(false).Count();
            return totalInstructors;
        }

        public (bool isSuccess, string message) CreateInstructor(Instructor instructor)
        {
            bool instructorExists = _manager.Instructor
                .GetAllInstructors(false)
                .Any(i => i.Email == instructor.Email);

            if (instructorExists)
                return (false, "An instructor with the same email already exists.");

            _manager.Instructor.AddInstructor(instructor);
            bool result = _manager.Save();

            if (result)
                return (true, "Instructor successfully created.");
            else
                return (false, "An error occurred while creating instructor.");
        }

        public (bool isSuccess, string message) DeleteInstructor(int instructorId)
        {
            var instructor = _manager.Instructor.GetOneInstructor(instructorId, false);
            if (instructor == null)
                return (false, "Instructor not found.");

            var relatedCourses = _manager.Course.FindByCondition(c => c.InstructorId == instructorId, false).ToList();

            foreach (var course in relatedCourses)
            {
                var enrollments = _manager.Enrollment.FindByCondition(e => e.CourseId == course.CourseId, false).ToList();

                if (enrollments.Any(e => e.Grade == null))
                    return (false, "Instructor cannot be deleted as there are enrollments with missing grades.");
            }

            if (!relatedCourses.Any())
            {
                _manager.Instructor.RemoveInstructor(instructor);
                _manager.Save();
                return (true, "Instructor deleted successfully.");
            }

            return (false, "Instructor cannot be deleted as they are associated with courses.");
        }

        public (bool isSuccess, string message) UpdateOneInstructor(InstructorDtoForUpdate instructorDto)
        {
            var entity = _mapper.Map<Instructor>(instructorDto);

            bool instructorExists = _manager.Instructor
                .GetAllInstructors(false)
                .Any(i => i.FirstName == entity.FirstName && i.LastName == entity.LastName && i.Email == entity.Email && i.InstructorId != entity.InstructorId);

            if (instructorExists)
                return (false, "An instructor with the same name and email already exists.");

            _manager.Instructor.UpdateOneInstructor(entity);
            bool isSaved = _manager.Save();
            if (isSaved)
                return (true, "Instructor updated successfully.");
            else
                return (false, "An error occurred while updating the instructor.");
        }
    }
}