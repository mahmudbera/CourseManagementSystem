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

        public void AddEnrollment(Enrollment enrollment)
        {
            _manager.Enrollment.CreateEnrollment(enrollment);
            _manager.Save();
        }

        public IQueryable<Enrollment> GetAllEnrollments(bool trackChanges)
        {
            return _manager.Enrollment.GetAllEnrollments(trackChanges);
        }

        public void UpdateOneEnrollmentGrade(EnrollmentDtoForGrade enrollmentDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
            _manager.Enrollment.UpdateOneEnrollment(enrollment);
            _manager.Save();   
        }
    }
}