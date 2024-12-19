using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;

namespace Services.Contracts
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public EnrollmentService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public IQueryable<Enrollment> GetAllEnrollments(bool trackChanges)
        {
            return _manager.Enrollment.GetAllEnrollments(trackChanges);
        }

        public (bool isSuccess, string message) AddEnrollment(Enrollment enrollment)
        {
            var existingEnrollment = _manager.Enrollment.GetAllEnrollments(false)
                    .Where(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId)
                    .FirstOrDefault();

            if (existingEnrollment != null)
                return (false, "This student is already enrolled in this course.");

            _manager.Enrollment.CreateEnrollment(enrollment);
            bool result = _manager.Save();

            if (result)
                return (true, "Enrollment successfully added.");
            else
                return (false, "Failed to add enrollment.");
        }

        public (bool isSuccess, string message) UpdateOneEnrollmentGrade(EnrollmentDtoForGrade enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _manager.Enrollment.UpdateOneEnrollment(enrollment);
            bool result = _manager.Save();

            if (result)
                return (true, "Grade successfully updated.");
            else
                return (false, "Failed to update grade.");
        }
    }
}